namespace WebOS.Net.Notification;

public class ToastRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = "ssap://system.notifications/createToast";

	[JsonPropertyName("payload")]
	public ToastRequestPayload Payload { get; } = new();
}

public class ToastRequestPayload
{
	[JsonPropertyName("message")]
	public string Message { get; set; } = string.Empty;
}
