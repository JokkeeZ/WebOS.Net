using WebOS.Net.Utils;

namespace WebOS.Net.Notification;

public class CreateAlertRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.CreateAlert;

	public AlertRequestPayload Payload { get; } = new();
}

public class WebOSButton(string label)
{
	public string Label { get; set; } = label;

	public bool Focus { get; set; }
}

public class AlertRequestPayload
{
	public string Message { get; set; } = string.Empty;

	public List<WebOSButton> Buttons { get; set; } = [];
}

public class CreateAlert : WebOSResponsePayload
{
	public string AlertId { get; set; }
}
