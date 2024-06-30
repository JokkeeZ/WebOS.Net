using WebOS.Net.Utils;

namespace WebOS.Net.Notification;

public class CreateToastRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.CreateToast;

	public ToastRequestPayload Payload { get; } = new();
}

public class ToastRequestPayload
{
	public string Message { get; set; } = string.Empty;
}

public class ToastResponse : WebOSResponse<CreateToast> { }

public class CreateToast : WebOSResponsePayload
{
	public string ToastId { get; set; }
}
