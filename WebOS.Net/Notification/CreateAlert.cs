using WebOS.Net.Utils;

namespace WebOS.Net.Notification;

public class CreateAlertRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.CreateAlert;
	public AlertRequestPayload Payload { get; } = new();
}

public class WebOSButton(string label, bool focus = false)
{
	public string Label { get; } = label;
	public bool Focus { get; } = focus;
}

public class AlertRequestPayload
{
	public string? Message { get; set; }
	public List<WebOSButton>? Buttons { get; set; }
}

public class CreateAlert : WebOSResponsePayload
{
	public string? AlertId { get; set; }
}
