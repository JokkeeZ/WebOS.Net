namespace WebOS.Net;

/// <summary>
/// Base class for all requests from WebOS.Net to webOS
/// </summary>
public abstract class WebOSRequest
{
	/// <summary>
	/// Gets or sets the id associated with the request.
	/// </summary>
	[JsonPropertyName("id")]
	public int Id { get; set; }

	/// <summary>
	/// Gets the type of the request, which is by default set to "request".
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; } = "request";
}
