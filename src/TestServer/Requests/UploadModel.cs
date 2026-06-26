using Simplify.Web.Model.Validation.Attributes;
using Simplify.Web.Multipart.Model;

namespace TestServer.Requests;

/// <summary>
/// Strongly typed multipart model: the parameters are bound to the model properties automatically.
/// </summary>
public class UploadModel : MultipartModel
{
	[Required]
	public string Title { get; set; }

	public int Count { get; set; }
}