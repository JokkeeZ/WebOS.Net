using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class GetAppStatusRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.GetAppStatus;

	public GetAppStatusRequestPayload Payload { get; set; } = new();
}

public class GetAppStatusRequestPayload
{
	public string Id { get; set; }
}

public class GetAppStatusResponse : WebOSResponse<GetAppStatus> { }
public class GetAppStatus : WebOSResponsePayload { }
