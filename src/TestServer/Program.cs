using Microsoft.AspNetCore.Builder;
using Simplify.DI;
using Simplify.Web;
using Simplify.Web.Model;
using Simplify.Web.Multipart.Model.Binding;
using TestServer.Setup;

DIContainer.Current
	.RegisterAll()
	.Verify();

HttpModelHandler.RegisterModelBinder<HttpMultipartFormModelBinder>();

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseSimplifyWeb();

await app.RunAsync();