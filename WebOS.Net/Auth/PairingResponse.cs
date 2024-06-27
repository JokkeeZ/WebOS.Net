namespace WebOS.Net.Auth;

public class PairingResponse
	: WebOSResponse<PairingResponsePayload>
{
}

public class PairingResponsePayload : WebOSResponsePayload
{
	[JsonPropertyName("client-key")]
	public string ClientKey { get; set; }
}
