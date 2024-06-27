namespace WebOS.Net.Auth;

public class HelloRequest : WebOSRequest
{
	[JsonPropertyName("id")]
	public new string Id { get; } = "hello";

	[JsonPropertyName("type")]
	public new string Type { get; } = "hello";
}
