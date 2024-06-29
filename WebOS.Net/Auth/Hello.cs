namespace WebOS.Net.Auth;

public class HelloRequest : WebOSRequest
{
	[JsonPropertyName("id")]
	public new string Id { get; } = "hello";

	[JsonPropertyName("type")]
	public new string Type { get; } = "hello";
}

public class HelloResponse : WebOSResponse<Hello> { }

public class Hello : WebOSResponsePayload
{
	[JsonPropertyName("protocolVersion")]
	public int ProtocolVersion { get; set; }

	[JsonPropertyName("deviceType")]
	public string DeviceType { get; set; }

	[JsonPropertyName("deviceOS")]
	public string DeviceOS { get; set; }

	[JsonPropertyName("deviceOSVersion")]
	public string DeviceOSVersion { get; set; }

	[JsonPropertyName("deviceOSReleaseVersion")]
	public string DeviceOSReleaseVersion { get; set; }

	[JsonPropertyName("deviceUUID")]
	public string DeviceUUID { get; set; }

	[JsonPropertyName("pairingTypes")]
	public List<string> PairingTypes { get; set; }
}
