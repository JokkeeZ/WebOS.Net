using WebOS.Net.Utils;

namespace WebOS.Net.Notification;

public class CloseAlertRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.CloseAlert;

	public CloseAlertRequestPayload Payload { get; } = new();
}

public class CloseAlertRequestPayload
{
	public string AlertId { get; set; }
}

public class CloseAlert : WebOSResponsePayload;
