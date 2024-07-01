using WebOS.Net.Utils;

namespace WebOS.Net;

/// <summary>
/// Base class for all responses from webOS that contain some additional data in the <typeparamref name="TPayload"/>.
/// </summary>
/// <typeparam name="TPayload">Response payload</typeparam>
public class WebOSResponse<TPayload> : WebOSDefaultResponse where TPayload : WebOSResponsePayload, new()
{
	/// <summary>
	/// Gets or sets the payload data associated with the response.
	/// </summary>
	public new TPayload Payload { get; set; } = new();
}

/// <summary>
/// Base class for all responses from webOS that do not contain any additional data in the payload.
/// </summary>
public class WebOSDefaultResponse
{
	/// <summary>
	/// Gets or sets the type of the response, indicating the nature of the response.
	/// </summary>
	public string Type { get; set; }

	/// <summary>
	/// Gets or sets the identifier associated with the response.
	/// </summary>
	[JsonConverter(typeof(ResponseIdConverter))]
	public string Id { get; set; }

	/// <summary>
	/// Gets or sets the error message associated with the response, if any.
	/// </summary>
	public string Error { get; set; }

	/// <summary>
	/// Gets or sets the payload data associated with the response.
	/// </summary>
	public WebOSResponsePayload Payload { get; set; } = new();
}

/// <summary>
/// Base class for all response payloads from webOS.
/// </summary>
public class WebOSResponsePayload
{
	/// <summary>
	/// Indicates whether the request succeeded.
	/// </summary>
	public bool ReturnValue { get; set; }

	/// <summary>
	/// Indicates whether client is subscribed to receiving callbacks about changes(?)
	/// TODO: Not sure about this one, have to lookup some documentation from somewhere.
	/// </summary>
	public bool Subscribed { get; set; }

	/// <summary>
	/// In some cases payload contains additional error text.
	/// </summary>
	public string ErrorText { get; set; }

	/// <summary>
	/// In some cases payload contains error code.
	/// </summary>
	public string ErrorCode { get; set; }

	/// <summary>
	/// Serializes response to JSON string.
	/// </summary>
	/// <returns>JSON <see langword="string"/>.</returns>
	public override string ToString()
	{
		return JsonSerializer.Serialize(this, GetType(), WebOSClient.JsonSerializeOptions);
	}
}
