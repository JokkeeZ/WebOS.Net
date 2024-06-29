using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class ConnectionManagerGetStatusRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.ConnectionManagerGetStatus;
}

public class ConnectionManagerGetStatusResponse : WebOSResponse<ConnectionManagerGetStatus> { }

public class ConnectionManagerGetStatus : WebOSResponsePayload
{
	[JsonPropertyName("wifiDirect")]
	public WebOSWifiDirect WifiDirect { get; set; }

	[JsonPropertyName("wifi")]
	public WebOSWifi Wifi { get; set; }

	[JsonPropertyName("wan")]
	public WebOSWan Wan { get; set; }

	[JsonPropertyName("offlineMode")]
	public string OfflineMode { get; set; }

	[JsonPropertyName("wired")]
	public WebOSWired Wired { get; set; }

	[JsonPropertyName("cellular")]
	public WebOSCellular Cellular { get; set; }

	[JsonPropertyName("bluetooth")]
	public WebOSBluetooth Bluetooth { get; set; }

	[JsonPropertyName("isInternetConnectionAvailable")]
	public bool IsInternetConnectionAvailable { get; set; }
}

public class WebOSBluetooth
{
	[JsonPropertyName("tetheringEnabled")]
	public bool TetheringEnabled { get; set; }

	[JsonPropertyName("state")]
	public string State { get; set; }
}

public class WebOSCellular
{
	[JsonPropertyName("enabled")]
	public bool Enabled { get; set; }
}

public class WebOSProxyInfo
{
	[JsonPropertyName("url")]
	public string Url { get; set; }

	[JsonPropertyName("method")]
	public string Method { get; set; }
}

public class WebOSWan
{
	[JsonPropertyName("connectedContexts")]
	public List<object> ConnectedContexts { get; set; }

	[JsonPropertyName("connected")]
	public bool Connected { get; set; }
}

public class WebOSWifi
{
	[JsonPropertyName("netmask")]
	public string Netmask { get; set; }

	[JsonPropertyName("connectedChannel")]
	public string ConnectedChannel { get; set; }

	[JsonPropertyName("method")]
	public string Method { get; set; }

	[JsonPropertyName("dns1")]
	public string Dns1 { get; set; }

	[JsonPropertyName("interfaceName")]
	public string InterfaceName { get; set; }

	[JsonPropertyName("gateway")]
	public string Gateway { get; set; }

	[JsonPropertyName("displayName")]
	public string DisplayName { get; set; }

	[JsonPropertyName("dns2")]
	public string Dns2 { get; set; }

	[JsonPropertyName("proxyinfo")]
	public WebOSProxyInfo Proxyinfo { get; set; }

	[JsonPropertyName("ipAddress")]
	public string IpAddress { get; set; }

	[JsonPropertyName("checkingInternet")]
	public bool CheckingInternet { get; set; }

	[JsonPropertyName("isWakeOnWifiEnabled")]
	public bool IsWakeOnWifiEnabled { get; set; }

	[JsonPropertyName("state")]
	public string State { get; set; }

	[JsonPropertyName("connectedFrequency")]
	public string ConnectedFrequency { get; set; }

	[JsonPropertyName("onInternet")]
	public string OnInternet { get; set; }

	[JsonPropertyName("ssid")]
	public string Ssid { get; set; }
}

public class WebOSWifiDirect
{
	[JsonPropertyName("state")]
	public string State { get; set; }
}

public class WebOSWired
{
	[JsonPropertyName("plugged")]
	public bool Plugged { get; set; }

	[JsonPropertyName("state")]
	public string State { get; set; }
}
