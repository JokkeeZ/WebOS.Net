namespace WebOS.Net.Notification;

public class ToastResponse
	: WebOSResponse<ToastResponsePayload>
{
}

public class ToastResponsePayload : WebOSResponsePayload
{
	[JsonPropertyName("toastId")]
	public string ToastId { get; set; }
}
