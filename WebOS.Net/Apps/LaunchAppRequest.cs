using System.Diagnostics.CodeAnalysis;

namespace WebOS.Net.Apps;

public class LaunchAppRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = "ssap://system.launcher/launch";

	[JsonPropertyName("payload")]
	public LaunchAppPayload Payload { get; set; } = new();
}

public class LaunchAppPayload
{
	[JsonPropertyName("id")]
	[DisallowNull]
	public string Id { get; set; }

	[JsonPropertyName("params")]
	public string Params { get; set; }

	[JsonPropertyName("contentId")]
	public string ContentId { get; set; }
}
