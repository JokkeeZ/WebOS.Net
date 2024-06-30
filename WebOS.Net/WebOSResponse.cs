using WebOS.Net.Utils;

namespace WebOS.Net;

/// <summary>
/// Base class for all responses from webOS.
/// </summary>
/// <typeparam name="TPayload">Response payload</typeparam>
public abstract class WebOSResponse<TPayload> where TPayload : WebOSResponsePayload, new()
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
	public TPayload Payload { get; set; } = new();

	/// <summary>
	/// Gets a value indicating whether the request succeeded.
	/// </summary>
	/// <remarks>
	/// The request is considered successful if all of the following conditions are true:
	/// <list type="bullet">
	/// <item><description>The response type is "response".</description></item>
	/// <item><description>The payload's return value is true.</description></item>
	/// <item><description>There is no error message.</description></item>
	/// </list>
	/// </remarks>
	public bool RequestSucceed => Type == "response" && Payload.ReturnValue && Error == null;
}

/// <summary>
/// Base class for all response payloads from webOS.
/// </summary>
public abstract class WebOSResponsePayload
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
	/// Serializes response to JSON string.
	/// </summary>
	/// <returns>JSON <see langword="string"/>.</returns>
	public override string ToString()
	{
		return JsonSerializer.Serialize(this, GetType(), new JsonSerializerOptions()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		});
	}
}
