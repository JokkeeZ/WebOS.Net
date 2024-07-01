namespace WebOS.Net;

/// <summary>
/// Base class for all requests to webOS.
/// </summary>
public abstract class WebOSRequest
{
	/// <summary>
	/// Gets or sets the id associated with the request.
	/// </summary>
	public string Id { get; set; }

	/// <summary>
	/// Gets the type of the request, which is by default set to "request".
	/// </summary>
	public string Type { get; } = "request";

	/// <summary>
	/// Gets the <see cref="Utils.WebOSApiURL"/> for the request.
	/// </summary>
	public abstract string Uri { get; }
}
