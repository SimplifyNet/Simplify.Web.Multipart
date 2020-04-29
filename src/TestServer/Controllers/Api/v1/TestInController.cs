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
			var file = Model.Files.FirstOrDefault() ?? throw new ArgumentException("No files in model");
			using var stream = new StreamReader(file.Data);
			var fileData = await stream.ReadToEndAsync();

			Trace.WriteLine($"Files count: {Model.Files}");
			Trace.WriteLine($"File name: {file.FileName}");
			Trace.WriteLine($"File content: {fileData}");

			// Assert

			if (file.FileName != "test file")
				throw new InvalidDataException($"Wrong name, actual: '{file.Name}'");

			if (file.FileName != "MyFile.txt")
				throw new InvalidDataException($"Wrong file name, actual: '{file.FileName}'");

			if (fileData != "Hello World!!!")
				throw new InvalidDataException($"Wrong file data, actual: '{fileData}'");

			return NoContent();
		}
	}
}