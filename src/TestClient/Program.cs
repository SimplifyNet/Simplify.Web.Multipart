using System;
using System.IO;
using Flurl.Http;

var result = await "http://localhost:5000/api/v1/testIn"
	.PostMultipartAsync(mp =>
		mp.AddFile("test file", new MemoryStream("Hello World!!!"u8.ToArray()), "MyFile.txt", "text/plain"));

Console.WriteLine("HTTP status: " + result.StatusCode);
Console.ReadLine();