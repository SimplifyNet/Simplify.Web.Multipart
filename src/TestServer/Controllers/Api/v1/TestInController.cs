using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Simplify.Web;
using Simplify.Web.Attributes;
using Simplify.Web.Multipart.Model;

namespace TestServer.Controllers.Api.v1
{
	[Post("/api/v1/testIn")]
	public class TestInController : AsyncController<MultipartViewModel>
	{
		public override async Task<ControllerResponse> Invoke()
		{
			var file = Model.Files.FirstOrDefault() ?? throw new ArgumentNullException("No files in model");

			Trace.WriteLine($"Files count: {Model.Files}");
			Trace.WriteLine($"File name: {file.FileName}");

			using var stream = new StreamReader(file.Data);

			var fileData = await stream.ReadToEndAsync();

			Trace.WriteLine($"File content: {fileData}");

			return NoContent();
		}
	}
}