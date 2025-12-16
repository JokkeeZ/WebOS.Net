using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class GetAppStateRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.GetAppState;

	public GetAppStateRequestPayload Payload { get; } = new();
}

public class GetAppStateRequestPayload
{
	public string Id { get; set; }
}

public class GetAppState : WebOSResponsePayload
{
	public bool Running { get; set; }

	public bool Visible { get; set; }
}
