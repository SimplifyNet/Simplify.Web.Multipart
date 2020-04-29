using System;
using RestSharp;
using Simplify.Extensions;

namespace TestClient
{
	internal class Program
	{
		private static void Main()
		{
			var client = new RestClient("http://localhost:5000/");

			var request = new RestRequest("api/v1/testIn", Method.POST)
			{
				AlwaysMultipartFormData = true,
				Files = { FileParameter.Create("test file", "Hello world!!!".ToBytesArray(), "MyFile.txt") }
			};

			var result = client.Execute(request);

			if (result.IsSuccessful != true)
				throw new InvalidOperationException("Error sending file");

			Console.WriteLine("HTTP status: " + result.StatusCode);
			Console.ReadLine();
		}
	}
}