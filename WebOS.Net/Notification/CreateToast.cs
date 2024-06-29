using WebOS.Net.Utils;

namespace WebOS.Net.Notification;

public class CreateToastRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.CreateToast;

	[JsonPropertyName("payload")]
	public ToastRequestPayload Payload { get; } = new();
}

public class ToastRequestPayload
{
	[JsonPropertyName("message")]
	public string Message { get; set; } = string.Empty;
}

public class ToastResponse : WebOSResponse<CreateToast> { }

public class CreateToast : WebOSResponsePayload
{
	[JsonPropertyName("toastId")]
	public string ToastId { get; set; }
}
