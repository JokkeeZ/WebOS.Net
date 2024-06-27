namespace WebOS.Net.Auth;

public class RegistrationResponse
	: WebOSResponse<RegistrationResponsePayload>
{
}

public class RegistrationResponsePayload : WebOSResponsePayload
{
	[JsonPropertyName("pairingType")]
	public string PairingType { get; set; }
}
