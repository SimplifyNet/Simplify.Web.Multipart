using System.Collections.Generic;
using HttpMultipartParser;

namespace Simplify.Web.Multipart.ModelBinding
{
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
		public List<FilePart> Files { get; set; }

		/// <summary>
		/// HTTP multipart form data parameters
		/// </summary>
		/// <value>
		/// The parameters.
		/// </value>
		public List<ParameterPart> Parameters { get; set; }
	}
}