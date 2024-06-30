using WebOS.Net.Utils;

namespace WebOS.Net.Notification;

public class CloseToastRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.CloseToast;

	public CloseToastRequestPayload Payload { get; } = new();
}

public class CloseToastRequestPayload
{
	public string ToastId { get; set; }
}

public class CloseToastResponse : WebOSResponse<CloseToast> { }

public class CloseToast : WebOSResponsePayload { }
