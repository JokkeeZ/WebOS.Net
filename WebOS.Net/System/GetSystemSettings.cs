using WebOS.Net.Utils;

namespace WebOS.Net.System;

/// <summary>
/// https://webostv.developer.lge.com/develop/references/settings-service#getsystemsettings
/// </summary>
public class GetSystemSettingsRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.GetSystemSettings;

	[JsonPropertyName("payload")]
	public Dictionary<string, List<string>> Payload { get; } = new()
	{
		{ "keys", ["localeInfo", "eulaStatus"] }
	};
}

public class GetSystemSettingsResponse : WebOSResponse<GetSystemSettings> { }

public class GetSystemSettings : WebOSResponsePayload
{
	[JsonPropertyName("settings")]
	public WebOSSystemSettings Settings { get; set; }
}

public class WebOSSystemSettings
{
	[JsonPropertyName("localeInfo")]
	public WebOSLocaleInfo LocaleInfo { get; set; }

	[JsonPropertyName("eulaStatus")]
	public WebOSEulaStatus EulaStatus { get; set; }
}

public class WebOSEulaStatus
{
	[JsonPropertyName("cookiesAllowed")]
	public bool CookiesAllowed { get; set; }

	[JsonPropertyName("takeOnAllowed")]
	public bool TakeOnAllowed { get; set; }

	[JsonPropertyName("additional3Allowed")]
	public bool Additional3Allowed { get; set; }

	[JsonPropertyName("additionalDataAllowed")]
	public bool AdditionalDataAllowed { get; set; }

	[JsonPropertyName("networkAllowed")]
	public bool NetworkAllowed { get; set; }

	[JsonPropertyName("chpAllowed")]
	public bool ChpAllowed { get; set; }

	[JsonPropertyName("voiceAllowed")]
	public bool VoiceAllowed { get; set; }

	[JsonPropertyName("marketingOnAllowed")]
	public bool MarketingOnAllowed { get; set; }

	[JsonPropertyName("veranceOnAllowed")]
	public bool VeranceOnAllowed { get; set; }

	[JsonPropertyName("acrAllowed")]
	public bool AcrAllowed { get; set; }

	[JsonPropertyName("additional4Allowed")]
	public bool Additional4Allowed { get; set; }

	[JsonPropertyName("additional1Allowed")]
	public bool Additional1Allowed { get; set; }

	[JsonPropertyName("acrGdprAllowed")]
	public bool AcrGdprAllowed { get; set; }

	[JsonPropertyName("voice2Allowed")]
	public bool Voice2Allowed { get; set; }

	[JsonPropertyName("remoteDiagAllowed")]
	public bool RemoteDiagAllowed { get; set; }

	[JsonPropertyName("acrAdAllowed")]
	public bool AcrAdAllowed { get; set; }

	[JsonPropertyName("additional5Allowed")]
	public bool Additional5Allowed { get; set; }

	[JsonPropertyName("generalTermsAllowed")]
	public bool GeneralTermsAllowed { get; set; }

	[JsonPropertyName("customAdAllowed")]
	public bool CustomAdAllowed { get; set; }

	[JsonPropertyName("additional2Allowed")]
	public bool Additional2Allowed { get; set; }

	[JsonPropertyName("shoppingOnAllowed")]
	public bool ShoppingOnAllowed { get; set; }

	[JsonPropertyName("acrOnAllowed")]
	public bool AcrOnAllowed { get; set; }

	[JsonPropertyName("customadsAllowed")]
	public bool CustomadsAllowed { get; set; }

	[JsonPropertyName("thirdPartySharingAllowed")]
	public bool ThirdPartySharingAllowed { get; set; }
}

public class WebOSLocaleInfo
{
	[JsonPropertyName("keyboards")]
	public List<string> Keyboards { get; set; }

	[JsonPropertyName("locales")]
	public WebOSLocales Locales { get; set; }

	[JsonPropertyName("clock")]
	public string Clock { get; set; }

	[JsonPropertyName("timezone")]
	public string Timezone { get; set; }
}

public class WebOSLocales
{
	[JsonPropertyName("UI")]
	public string UI { get; set; }

	[JsonPropertyName("FMT")]
	public string FMT { get; set; }

	[JsonPropertyName("NLP")]
	public string NLP { get; set; }

	[JsonPropertyName("AUD")]
	public string AUD { get; set; }

	[JsonPropertyName("AUD2")]
	public string AUD2 { get; set; }

	[JsonPropertyName("TV")]
	public string TV { get; set; }

	[JsonPropertyName("STT")]
	public string STT { get; set; }
}
