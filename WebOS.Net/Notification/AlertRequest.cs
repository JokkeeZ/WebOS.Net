namespace WebOS.Net.Notification;

public class AlertRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = "ssap://system.notifications/createAlert";

	[JsonPropertyName("payload")]
	public AlertRequestPayload Payload { get; } = new();
}

public class WebOSButton(string label)
{
	[JsonPropertyName("label")]
	public string Label { get; set; } = label;
}

public class AlertRequestPayload
{
	[JsonPropertyName("title")]
	public string Title { get; set; } = string.Empty;

	[JsonPropertyName("message")]
	public string Message { get; set; } = string.Empty;

	[JsonPropertyName("buttons")]
	public List<WebOSButton> Buttons { get; set; } = [];
}
