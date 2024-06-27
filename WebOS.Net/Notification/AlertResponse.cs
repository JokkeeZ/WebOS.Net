namespace WebOS.Net.Notification;

public class AlertResponse
	: WebOSResponse<AlertResponsePayload>
{
}


public class AlertResponsePayload : WebOSResponsePayload
{
	[JsonPropertyName("alertId")]
	public string AlertId { get; set; }
}
