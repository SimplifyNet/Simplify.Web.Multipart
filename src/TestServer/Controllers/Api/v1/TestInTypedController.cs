using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Simplify.Web;
using Simplify.Web.Attributes;
using Simplify.Web.Multipart.Model;
using TestServer.Requests;

namespace TestServer.Controllers.Api.v1;

[Post("/api/v1/testInTyped")]
public class TestInTypedController : Controller2<UploadModel>
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

		Trace.TraceInformation($"Title: '{Model.Title}'");
		Console.WriteLine($"Title: '{Model.Title}'");

		Trace.TraceInformation($"Count: '{Model.Count}'");
		Console.WriteLine($"Count: '{Model.Count}'");

		// Assert parameters were bound to the typed model

		if (Model.Title != "My title")
			return Content($"Wrong title, actual: '{Model.Title}'", 500);

		if (Model.Count != 42)
			return Content($"Wrong count, actual: '{Model.Count}'", 500);

		// Assert file is still accessible

		if (file.FileName != "MyFile.txt")
			return Content($"Wrong file name, actual: '{file.FileName}'", 500);

		if (fileData != "Hello World!!!")
			return Content($"Wrong file data, actual: '{fileData}'", 500);

		return NoContent();
	}
}
