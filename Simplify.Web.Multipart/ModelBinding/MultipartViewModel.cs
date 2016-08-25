using System.Collections.Generic;
using HttpMultipartParser;

namespace Simplify.Web.Multipart.ModelBinding
{
	public class MultipartViewModel
	{
		public List<FilePart> Files { get; set; }

		public List<ParameterPart> Parameters { get; set; }
	}
}