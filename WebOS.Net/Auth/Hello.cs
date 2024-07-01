namespace WebOS.Net.Auth;

public class HelloRequest : WebOSRequest
{
	public new string Type { get; } = "hello";

	[JsonIgnore]
	public override string Uri => null;
}

public class HelloResponse : WebOSResponse<Hello> { }

public class Hello : WebOSResponsePayload
{
	public int ProtocolVersion { get; set; }

	public string DeviceType { get; set; }

	public string DeviceOS { get; set; }

	public string DeviceOSVersion { get; set; }

	public string DeviceOSReleaseVersion { get; set; }

	public string DeviceUUID { get; set; }

	public List<string> PairingTypes { get; set; }
}
