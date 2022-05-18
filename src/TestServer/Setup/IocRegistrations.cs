using Simplify.DI;
using Simplify.Web.Multipart;

namespace TestServer.Setup;

public static class IocRegistrations
{
	public static void Register() => DIContainer.Current.RegisterHttpMultipartFormModelBinder();
}