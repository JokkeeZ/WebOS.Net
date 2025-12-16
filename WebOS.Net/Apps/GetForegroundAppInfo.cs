using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class GetForegroundAppInfoRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.GetForegroundAppInfo;
}

public class GetForegroundAppInfo : WebOSResponsePayload
{
	public string AppId { get; set; }

	public string ProcessId { get; set; }

	public string WindowId { get; set; }
}
