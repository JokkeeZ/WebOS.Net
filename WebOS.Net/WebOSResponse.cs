using WebOS.Net.Utils;

namespace WebOS.Net;

/// <summary>
/// Base class for all responses from webOS.
/// </summary>
/// <typeparam name="TPayload">Response payload</typeparam>
public abstract class WebOSResponse<TPayload> where TPayload : WebOSResponsePayload, new()
{
	[JsonPropertyName("type")]
	public string Type { get; set; }

	[JsonPropertyName("id")]
	[JsonConverter(typeof(ResponseIdConverter))]
	public string Id { get; set; }

	[JsonPropertyName("error")]
	public string Error { get; set; }

	[JsonPropertyName("payload")]
	public TPayload Payload { get; set; } = new();
}

/// <summary>
/// Base class for all response payloads from webOS
/// </summary>
public abstract class WebOSResponsePayload
{
	[JsonPropertyName("returnValue")]
	public bool ReturnValue { get; set; }

	[JsonPropertyName("subscribed")]
	public bool Subscribed { get; set; }
}
