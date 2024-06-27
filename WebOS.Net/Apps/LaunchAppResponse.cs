namespace WebOS.Net.Apps;

public class LaunchAppResponse : WebOSResponse<LaunchAppResponsePayload> { }

public class LaunchAppResponsePayload : WebOSResponsePayload
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("sessionId")]
	public string SessionId { get; set; }
}
