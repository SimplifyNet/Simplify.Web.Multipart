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

			var request = new RestRequest("api/v1/testIn", Method.POST)
			{
				AlwaysMultipartFormData = true,
				Files = { FileParameter.Create("test file", Encoding.UTF8.GetBytes("Hello World!!!"), "MyFile.txt", "text/plain") }
			};

			var result = client.Execute(request);

			if (result.IsSuccessful != true)
				throw new InvalidOperationException("Error sending file");

			Console.WriteLine("HTTP status: " + result.StatusCode);
			Console.ReadLine();
		}
	}
}