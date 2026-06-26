using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpMultipartParser;
using Simplify.Web.Model.Binding;
using Simplify.Web.Model.Binding.Parsers;

namespace Simplify.Web.Multipart.Model.Binding;

/// <summary>
/// Provides form multipart data to object binding
/// </summary>
/// <seealso cref="IModelBinder" />
public class HttpMultipartFormModelBinder : IModelBinder
{
	/// <summary>
	/// Binds the model.
	/// </summary>
	/// <typeparam name="T">Model type, should inherit from <see cref="MultipartModel" />.</typeparam>
	/// <param name="args">The <see cref="ModelBinderEventArgs{T}" /> instance containing the event data.</param>
	public async Task BindAsync<T>(ModelBinderEventArgs<T> args)
	{
		if (!args.Context.Request.ContentType.Contains("multipart/form-data"))
			return;

		if (!typeof(MultipartModel).IsAssignableFrom(typeof(T)))
			throw new ModelBindingException("For HTTP multipart form data the model type should inherit from: " + nameof(MultipartModel));

		var parser = await MultipartFormDataParser.ParseAsync(args.Context.Request.Body);

		// Bind the parameters to the strongly typed model properties reusing Simplify.Web parser.
		var model = ListToModelParser.Parse<T>(ToKeyValuePairs(parser.Parameters));

		var multipartModel = (MultipartModel)(object)model;

		multipartModel.Files = parser.Files;

		// Keep the raw parameters available for the backward compatible model.
		if (multipartModel is MultipartViewModel viewModel)
			viewModel.Parameters = parser.Parameters;

		args.SetModel(model);
	}

	private static IList<KeyValuePair<string, string[]>> ToKeyValuePairs(IEnumerable<ParameterPart> parameters) =>
		[.. parameters
			.GroupBy(x => x.Name)
			.Select(x => new KeyValuePair<string, string[]>(x.Key, [.. x.Select(p => p.Data)]))];
}
