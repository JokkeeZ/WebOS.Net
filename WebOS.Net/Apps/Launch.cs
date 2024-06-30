using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class LaunchRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.Launch;

	public LaunchRequestPayload Payload { get; set; } = new();
}

public class LaunchRequestPayload
{
	public string Id { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string Params { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string ContentId { get; set; }
}

public class LaunchResponse : WebOSResponse<Launch> { }

public class Launch : WebOSResponsePayload
{
	public string Id { get; set; }

	public string SessionId { get; set; }
}
