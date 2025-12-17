using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class CloseRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.Close;
	public CloseRequestPayload Payload { get; } = new();
}

public class CloseRequestPayload
{
	public string? Id { get; set; }
}
