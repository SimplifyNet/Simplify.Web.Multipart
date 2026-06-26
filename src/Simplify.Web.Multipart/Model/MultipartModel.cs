using System.Collections.Generic;
using HttpMultipartParser;
using Simplify.Web.Model.Binding.Attributes;

namespace Simplify.Web.Multipart.Model;

/// <summary>
/// Base HTTP multipart form data model providing access to the uploaded files.
/// Inherit from this class and add your own properties to have the multipart form
/// parameters bound to them automatically (the same way as for a regular query/form/JSON model).
/// </summary>
public class MultipartModel
{
	/// <summary>
	/// HTTP multipart form data files
	/// </summary>
	/// <value>
	/// The files.
	/// </value>
	[Exclude]
	public IReadOnlyList<FilePart> Files { get; set; }
}
