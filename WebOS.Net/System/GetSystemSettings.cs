using WebOS.Net.Utils;

namespace WebOS.Net.System;

/// <summary>
/// https://webostv.developer.lge.com/develop/references/settings-service#getsystemsettings
/// </summary>
public class GetSystemSettingsRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.GetSystemSettings;

	public Dictionary<string, List<string>> Payload { get; } = new()
	{
		{ "keys", ["localeInfo", "eulaStatus"] }
	};
}

public class GetSystemSettings : WebOSResponsePayload
{
	public WebOSSystemSettings? Settings { get; set; }
}

public class WebOSSystemSettings
{
	public WebOSLocaleInfo? LocaleInfo { get; set; }
	public WebOSEulaStatus? EulaStatus { get; set; }
}

public class WebOSEulaStatus
{
	public bool? CookiesAllowed { get; set; }
	public bool? TakeOnAllowed { get; set; }
	public bool? Additional3Allowed { get; set; }
	public bool? AdditionalDataAllowed { get; set; }
	public bool? NetworkAllowed { get; set; }
	public bool? ChpAllowed { get; set; }
	public bool? VoiceAllowed { get; set; }
	public bool? MarketingOnAllowed { get; set; }
	public bool? VeranceOnAllowed { get; set; }
	public bool? AcrAllowed { get; set; }
	public bool? Additional4Allowed { get; set; }
	public bool? Additional1Allowed { get; set; }
	public bool? AcrGdprAllowed { get; set; }
	public bool? Voice2Allowed { get; set; }
	public bool? RemoteDiagAllowed { get; set; }
	public bool? AcrAdAllowed { get; set; }
	public bool? Additional5Allowed { get; set; }
	public bool? GeneralTermsAllowed { get; set; }
	public bool? CustomAdAllowed { get; set; }
	public bool? Additional2Allowed { get; set; }
	public bool? ShoppingOnAllowed { get; set; }
	public bool? AcrOnAllowed { get; set; }
	public bool? CustomadsAllowed { get; set; }
	public bool? ThirdPartySharingAllowed { get; set; }
}

public class WebOSLocaleInfo
{
	public List<string>? Keyboards { get; set; }
	public WebOSLocales? Locales { get; set; }
	public string? Clock { get; set; }
	public string? Timezone { get; set; }
}

public class WebOSLocales
{
	[JsonPropertyName("UI")]
	public string? UI { get; set; }
	[JsonPropertyName("FMT")]
	public string? FMT { get; set; }
	[JsonPropertyName("NLP")]
	public string? NLP { get; set; }
	[JsonPropertyName("AUD")]
	public string? AUD { get; set; }
	[JsonPropertyName("AUD2")]
	public string? AUD2 { get; set; }
	[JsonPropertyName("TV")]
	public string? TV { get; set; }
	[JsonPropertyName("STT")]
	public string? STT { get; set; }
}
