namespace WebOS.Net.Apps;

public class CloseAppRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = "ssap://system.launcher/close";

	[JsonPropertyName("payload")]
	public CloseAppRequestPayload Payload { get; } = new();
}

public class CloseAppRequestPayload
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
}
