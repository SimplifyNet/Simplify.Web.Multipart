using System;
using System.Text;
using RestSharp;

namespace TestClient
{
	internal class Program
	{
		private static void Main()
		{
			var client = new RestClient("http://localhost:5000/");

			var request = new RestRequest("api/v1/testIn", Method.Post)
			{
				AlwaysMultipartFormData = true
			};

			request.AddFile("test file", Encoding.UTF8.GetBytes("Hello World!!!"), "MyFile.txt", "text/plain");

			var result = client.ExecuteAsync(request).Result;

			if (result.IsSuccessful != true)
				throw new InvalidOperationException("Error sending file: " + result.Content);

			Console.WriteLine("HTTP status: " + result.StatusCode);
			Console.ReadLine();
		}
	}
}