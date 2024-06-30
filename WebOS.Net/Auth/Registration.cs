namespace WebOS.Net.Auth;

public class RegistrationRequest : WebOSRequest
{
	public new string Id { get; } = "register_0";

	public new string Type { get; } = "register";

	public RegistrationPayload Payload { get; } = new();

	[JsonIgnore]
	public override string Uri => null;
}

public class RegistrationPayload
{
	public bool ForcePairing { get; } = false;

	public RegistrationManifest Manifest { get; } = new();

	public string PairingType { get; } = "PROMPT";

	[JsonPropertyName("client-key")]
	public string ClientKey { get; set; } = string.Empty;
}

public class RegistrationManifest
{
	public string AppVersion { get; } = "1.0";

	public int ManifestVersion { get; } = 1;

	public List<string> Permissions { get; } =
	[
		"CONTROL_AUDIO",
		"CONTROL_DISPLAY",
		"CONTROL_INPUT_JOYSTICK",
		"CONTROL_INPUT_MEDIA_RECORDING",
		"CONTROL_INPUT_MEDIA_PLAYBACK",
		"CONTROL_INPUT_TV",
		"CONTROL_POWER",
		"CONTROL_TV_SCREEN",
		"CONTROL_TV_STANBY",
		"CONTROL_FAVORITE_GROUP",
		"CONTROL_USER_INFO",
		"CONTROL_BLUETOOTH",
		"CONTROL_TIMER_INFO",
		"CONTROL_RECORDING",
		"CONTROL_BOX_CHANNEL",
		"CONTROL_CHANNEL_BLOCK",
		"CONTROL_CHANNEL_GROUP",
		"CONTROL_TV_POWER",
		"CONTROL_WOL",
		"CONTROL_MOUSE_AND_KEYBOARD",
		"CONTROL_INPUT_TEXT",

		"READ_APP_STATUS",
		"READ_CURRENT_CHANNEL",
		"READ_INPUT_DEVICE_LIST",
		"READ_NETWORK_STATE",
		"READ_RUNNING_APPS",
		"READ_TV_CHANNEL_LIST",
		"READ_POWER_STATE",
		"READ_COUNTRY_INFO",
		"READ_SETTINGS",
		"READ_RECORDING_STATE",
		"READ_RECORDING_LIST",
		"READ_RECORDING_SCHEDULE",
		"READ_STORAGE_DEVICE_LIST",
		"READ_TV_PROGRAM_INFO",
		"READ_TV_ACR_AUTH_TOKEN",
		"READ_TV_CONTENT_STATE",
		"READ_TV_CURRENT_TIME",
		"READ_INSTALLED_APPS",

		"WRITE_NOTIFICATION_TOAST",
		"WRITE_RECORDING_LIST",
		"WRITE_RECORDING_SCHEDULE",

		"TEST_OPEN",
		"TEST_PROTECTED",

		"LAUNCH",
		"LAUNCH_WEBAPP",

		"APP_TO_APP",
		"CLOSE",
		"CHECK_BLUETOOTH_DEVICE",
		"STB_INTERNAL_CONNECTION",
		"ADD_LAUNCHER_CHANNEL",
		"SET_CHANNEL_SKIP",
		"RELEASE_CHANNEL_SKIP",
		"DELETE_SELECT_CHANNEL",
		"SCAN_TV_CHANNELS",
	];

	public List<RegistrationSignature> Signatures { get; } = [new()];

	public RegistrationSigned Signed { get; } = new();
}

public class RegistrationSignature
{
	public string Signature { get; } = "eyJhbGdvcml0aG0iOiAiUlNBLVNIQTI1NiIsICJrZXlJZCI6ICJ3ZWJvcy5uZXQuY2VydCIsICJzaWduYXR1cmVWZXJzaW9uIjoxIn0.RRsewqWqsiaw6aRLLaFW3lQ2IJDmooCOtWHkdROnzC5fPpoICLnPLoZaJkeGTLkw-n-_1NEuFZda2PWY2TQ83NZSdCdeBnyErzUNCaOSt8knA_7vWDs6OBYhQJj6lRIicO5hpE7wt4WdMIyFiWZs_mqYVD7g8U8qmOy6rbD1MG81rFcgq2JCRdlmEOTYr5Sld2TnFpVTZICyZY07FgxjPa-tD2WvHcrL_7VKrL_MfNe5uf1-SfR8sNuhFrML3Uethd_h8ESDCFYve5JyQQVaHpQ0QbMTCEd6bWUn-juezFyCsbb8nDg9pWR_tYlEVEYftVOIzPulmamrJoEermbzow";

	public int SignatureVersion { get; } = 1;
}

public class RegistrationSigned
{
	public string AppId { get; } = "com.lge.test";

	public string Created { get; } = "20140509";

	public Dictionary<string, string> LocalizedAppNames { get; } = new()
	{
		{ "", "LG Remote App" },
		{ "ko-KR", "리모컨 앱" },
		{ "zxx-XX", "ЛГ Rэмotэ AПП" }
	};

	public Dictionary<string, string> LocalizedVendorNames { get; } = new()
	{
		{ "", "LG Electronics" }
	};

	public List<string> Permissions { get; } =
	[
		"TEST_SECURE",
		"CONTROL_INPUT_TEXT",
		"CONTROL_MOUSE_AND_KEYBOARD",
		"READ_INSTALLED_APPS",
		"READ_LGE_SDX",
		"READ_NOTIFICATIONS",
		"SEARCH",
		"WRITE_SETTINGS",
		"WRITE_NOTIFICATION_ALERT",
		"CONTROL_POWER",
		"READ_CURRENT_CHANNEL",
		"READ_RUNNING_APPS",
		"READ_UPDATE_INFO",
		"UPDATE_FROM_REMOTE_APP",
		"READ_LGE_TV_INPUT_EVENTS",
		"READ_TV_CURRENT_TIME"
	];

	public string Serial { get; } = "2f930e2d2cfe083771f68e4fe7bb07";

	public string VendorId { get; } = "com.lge";
}

public class RegistrationResponse : WebOSResponse<Registration> { }

public class Registration : WebOSResponsePayload
{
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string PairingType { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonPropertyName("client-key")]
	public string ClientKey { get; set; }
}
