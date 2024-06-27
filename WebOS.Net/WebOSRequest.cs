namespace WebOS.Net;

/// <summary>
/// Base class for all requests from WebOS.Net to webOS
/// </summary>
public abstract class WebOSRequest
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("type")]
	public string Type { get; } = "request";
}
