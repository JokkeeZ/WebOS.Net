using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class CloseRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.Close;

	[JsonPropertyName("payload")]
	public CloseRequestPayload Payload { get; } = new();
}

public class CloseRequestPayload
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
}

public class CloseResponse : WebOSResponse<Close> { }

public class Close : WebOSResponsePayload { }
