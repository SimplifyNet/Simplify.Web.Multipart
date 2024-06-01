using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Simplify.Web;
using Simplify.Web.Attributes;
using Simplify.Web.Multipart.Model;

namespace TestServer.Controllers.Api.v1;

[Post("/api/v1/testIn")]
public class TestInController : Controller2<MultipartViewModel>
{
	public async Task<ControllerResponse> Invoke()
	{
		var file = Model.Files[0] ?? throw new ArgumentException("No files in model");
		using var stream = new StreamReader(file.Data);
		var fileData = await stream.ReadToEndAsync();

		Trace.TraceInformation($"Files count: '{Model.Files.Count}'");
		Console.WriteLine($"Files count: '{Model.Files.Count}'");

		Trace.TraceInformation($"File name: '{file.FileName}'");
		Console.WriteLine($"File name: '{file.FileName}'");

		Trace.TraceInformation($"File content: '{fileData}'");
		Console.WriteLine($"File content: '{fileData}'");

		// Assert

		if (file.Name != "test file")
			return Content($"Wrong name, actual: '{file.Name}'", 500);

		if (file.FileName != "MyFile.txt")
			return Content($"Wrong file name, actual: '{file.FileName}'", 500);

		if (fileData != "Hello World!!!")
			return Content($"Wrong file data, actual: '{fileData}'", 500);

		return NoContent();
	}
}