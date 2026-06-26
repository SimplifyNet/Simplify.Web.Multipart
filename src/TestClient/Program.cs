using System;
using System.IO;
using Flurl.Http;

var result = await "http://localhost:5000/api/v1/testIn"
	.PostMultipartAsync(mp =>
		mp.AddFile("test file", new MemoryStream("Hello World!!!"u8.ToArray()), "MyFile.txt", "text/plain"));

Console.WriteLine("Untyped model HTTP status: " + result.StatusCode);

var typedResult = await "http://localhost:5000/api/v1/testInTyped"
	.PostMultipartAsync(mp =>
	{
		mp.AddFile("test file", new MemoryStream("Hello World!!!"u8.ToArray()), "MyFile.txt", "text/plain");
		mp.AddString("Title", "My title");
		mp.AddString("Count", "42");
	});

Console.WriteLine("Typed model HTTP status: " + typedResult.StatusCode);

Console.ReadLine();
