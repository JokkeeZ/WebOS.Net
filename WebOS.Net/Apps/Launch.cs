﻿using System.Diagnostics.CodeAnalysis;
using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class LaunchRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.Launch;

	[JsonPropertyName("payload")]
	public LaunchRequestPayload Payload { get; set; } = new();
}

public class LaunchRequestPayload
{
	[JsonPropertyName("id")]
	[DisallowNull]
	public string Id { get; set; }

	[JsonPropertyName("params")]
	public string Params { get; set; }

	[JsonPropertyName("contentId")]
	public string ContentId { get; set; }
}

public class LaunchResponse : WebOSResponse<Launch> { }

public class Launch : WebOSResponsePayload
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("sessionId")]
	public string SessionId { get; set; }
}
