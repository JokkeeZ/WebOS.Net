using WebOS.Net.Utils;

namespace WebOS.Net.TV;

public class SwitchInputRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.SwitchInput;

	public SwitchInputRequestPayload Payload { get; } = new();
}

public class SwitchInputRequestPayload
{
	public string InputId { get; set; }
}
