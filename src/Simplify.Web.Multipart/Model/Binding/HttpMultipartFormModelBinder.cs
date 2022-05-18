using System;
using System.Threading.Tasks;
using HttpMultipartParser;
using Simplify.Web.Model.Binding;

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
	/// <typeparam name="T">Model type</typeparam>
	/// <param name="args">The <see cref="ModelBinderEventArgs{T}" /> instance containing the event data.</param>
	public async Task BindAsync<T>(ModelBinderEventArgs<T> args)
	{
		if (!args.Context.Request.ContentType.Contains("multipart/form-data"))
			return;

		var multipartModelType = typeof(MultipartViewModel);

		if (typeof(T) != multipartModelType)
			throw new ModelBindingException("For HTTP multipart form data model type should be: " + multipartModelType.Name);

		var parser = await MultipartFormDataParser.ParseAsync(args.Context.Request.Body);
		var obj = Activator.CreateInstance<T>();

		var model = (MultipartViewModel)(object)obj;

		model.Files = parser.Files;
		model.Parameters = parser.Parameters;

		args.SetModel(obj);
	}
}