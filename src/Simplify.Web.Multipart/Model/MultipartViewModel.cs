using System.Collections.Generic;
using HttpMultipartParser;
using Simplify.Web.Model.Binding.Attributes;

namespace Simplify.Web.Multipart.Model;

/// <summary>
/// HTTP multipart form data model exposing the raw files and parameters lists.
/// Use it when you want to work with the parameters list directly; to bind the
/// parameters to a strongly typed model inherit from <see cref="MultipartModel" /> instead.
/// </summary>
public class MultipartViewModel : MultipartModel
{
	/// <summary>
	/// HTTP multipart form data parameters
	/// </summary>
	/// <value>
	/// The parameters.
	/// </value>
	[Exclude]
	public IReadOnlyList<ParameterPart> Parameters { get; set; }
}
