using Simplify.Web;
using Simplify.Web.Attributes;

namespace TestServer.Controllers;

[Get("status")]
public class StatusController : Controller2
{
	public ControllerResponse Invoke() => Content("Service is running!");
}