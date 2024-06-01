using Simplify.DI;
using Simplify.Web;
using Simplify.Web.Multipart;

namespace TestServer.Setup;

public static class IocRegistrations
{
	public static IDIContainerProvider RegisterAll(this IDIContainerProvider provider)
	{
		provider.RegisterHttpMultipartFormModelBinder()
			.RegisterSimplifyWeb();

		return provider;
	}
}