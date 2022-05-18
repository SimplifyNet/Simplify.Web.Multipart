using System.Collections.Generic;
using HttpMultipartParser;

namespace Simplify.Web.Multipart.Model;

/// <summary>
/// HTTP multipart form data model
/// </summary>
public class MultipartViewModel
{
	/// <summary>
	/// HTTP multipart form data files
	/// </summary>
	/// <value>
	/// The files.
	/// </value>
	public IReadOnlyList<FilePart> Files { get; set; }

	/// <summary>
	/// HTTP multipart form data parameters
	/// </summary>
	/// <value>
	/// The parameters.
	/// </value>
	public IReadOnlyList<ParameterPart> Parameters { get; set; }
}