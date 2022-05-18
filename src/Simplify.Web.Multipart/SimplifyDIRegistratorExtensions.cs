using Simplify.DI;
using Simplify.Web.Multipart.Model.Binding;

namespace Simplify.Web.Multipart;

/// <summary>
/// Provides Simplify.Web.Json default registration
/// </summary>
public static class SimplifyDIRegistratorExtensions
{
	/// <summary>
	/// Registers Simplify.Web.Json JsonModelBinder.
	/// </summary>
	/// <param name="registrator">The registrator.</param>
	public static IDIRegistrator RegisterHttpMultipartFormModelBinder(this IDIRegistrator registrator) =>
		registrator.Register<HttpMultipartFormModelBinder>(LifetimeType.Singleton);
}