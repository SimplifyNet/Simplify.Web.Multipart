using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Simplify.DI;
using Simplify.Web;
using Simplify.Web.Model;
using Simplify.Web.Multipart.Model.Binding;
using TestServer.Setup;

namespace TestServer
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			IocRegistrations.Register();

			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			HttpModelHandler.RegisterModelBinder<HttpMultipartFormModelBinder>();

			app.UseSimplifyWeb();

			DIContainer.Current.Verify();
		}
	}
}