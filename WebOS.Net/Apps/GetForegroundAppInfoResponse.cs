namespace WebOS.Net.Apps;

public class GetForegroundAppInfoResponse : WebOSResponse<GetForegroundAppInfoPayload> { }

public class GetForegroundAppInfoPayload : WebOSResponsePayload
{
	[JsonPropertyName("appId")]
	public string AppId { get; set; }

	[JsonPropertyName("processId")]
	public string ProcessId { get; set; }

	[JsonPropertyName("windowId")]
	public string WindowId { get; set; }

}