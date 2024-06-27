using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;

namespace WebOS.Net;

/// <summary>
/// Represents the root element of an XML document compliant with the UPnP device architecture.
/// </summary>
[XmlRoot(ElementName = "root", Namespace = "urn:schemas-upnp-org:device-1-0")]
public class XmlUPnPRoot
{
	[XmlElement(ElementName = "device")]
	public WebOSDevice Device { get; set; }
}

/// <summary>
/// Represents a webOS device compliant with the UPnP device architecture.
/// </summary>
[XmlRoot(ElementName = "device", Namespace = "urn:schemas-upnp-org:device-1-0")]
public class WebOSDevice
{
	/// <summary>
	/// Gets or sets the host address of the webOS device.
	/// </summary>
	public string Host { get; set; }

	/// <summary>
	/// Gets or sets the port number for the webOS device.
	/// Default value is 3001 for wss.
	/// </summary>
	public int Port { get; set; } = 3001;

	/// <summary>
	/// Gets or sets the client key used for authentication with the webOS device.
	/// Use empty string if it's a first time connection.
	/// </summary>
	public string ClientKey { get; set; } = string.Empty;

	/// <summary>
	/// webOS device type.
	/// </summary>
	[XmlElement(ElementName = "deviceType")]
	public string DeviceType { get; set; }

	/// <summary>
	/// webOS device friendly name.
	/// </summary>
	[XmlElement(ElementName = "friendlyName")]
	public string FriendlyName { get; set; }

	/// <summary>
	/// webOS device manufacturer.
	/// </summary>
	[XmlElement(ElementName = "manufacturer")]
	public string Manufacturer { get; set; }

	/// <summary>
	/// webOS device manufacturer URL.
	/// </summary>
	[XmlElement(ElementName = "manufacturerURL")]
	public string ManufacturerURL { get; set; }

	/// <summary>
	/// webOS device model description.
	/// </summary>
	[XmlElement(ElementName = "modelDescription")]
	public string ModelDescription { get; set; }

	/// <summary>
	/// webOS device model name
	/// </summary>
	[XmlElement(ElementName = "modelName")]
	public string ModelName { get; set; }

	/// <summary>
	/// webOS device model URL.
	/// </summary>
	[XmlElement(ElementName = "modelURL")]
	public string ModelURL { get; set; }

	/// <summary>
	/// webOS device serial number.
	/// </summary>
	[XmlElement(ElementName = "serialNumber")]
	public string SerialNumber { get; set; }

	/// <summary>
	/// webOS device Unique Device Name (UDN).
	/// </summary>
	[XmlElement(ElementName = "UDN")]
	public string UDN { get; set; }

	/// <summary>
	/// webOS device WiFi MAC address.
	/// </summary>
	[XmlElement(ElementName = "wifiMac")]
	public string WifiMac { get; set; }

	/// <summary>
	/// webOS device wired MAC address.
	/// </summary>
	[XmlElement(ElementName = "wiredMac")]
	public string WiredMac { get; set; }

	static readonly JsonSerializerOptions opts = new()
	{
		WriteIndented = true
	};

	/// <summary>
	/// Saves the current instance of the <see cref="WebOSDevice"/> to a file in JSON format.
	/// </summary>
	/// <param name="filePath">The file path where the JSON representation of the device will be saved.</param>
	/// <exception cref="WebOSException">
	/// Thrown when the <see cref="ClientKey"/> is empty or unset.
	/// </exception>
	public void SaveToFile(string filePath)
	{
		if (string.IsNullOrEmpty(ClientKey))
		{
			throw new WebOSException("Trying to save a file with empty/unset ClientKey!");
		}

		File.WriteAllText(filePath, JsonSerializer.Serialize(this, opts));
	}

	/// <summary>
	/// Loads an instance of <see cref="WebOSDevice"/> from a file if it exists.
	/// </summary>
	/// <param name="filePath">The file path from which to load the JSON representation of the device.</param>
	/// <returns>
	/// An instance of <see cref="WebOSDevice"/> if the file exists; otherwise, <c>null</c>.
	/// </returns>
	public static WebOSDevice FromFileIfExists(string filePath)
	{
		if (!File.Exists(filePath))
		{
			return null;
		}

		return JsonSerializer.Deserialize<WebOSDevice>(File.ReadAllText(filePath));
	}

	/// <summary>
	/// Performs an SSDP M-SEARCH to discover a webOS device on the local network.
	/// </summary>
	/// <returns>
	/// A task representing the asynchronous operation. The task result contains an instance of <see cref="WebOSDevice"/> if the device is found.
	/// </returns>
	/// <exception cref="WebOSException">
	/// Thrown if the M-SEARCH response is invalid or if the device cannot be located on the local network.
	/// </exception>
	public static async Task<WebOSDevice> MSearchForDeviceAsync()
	{
		var request = Encoding.UTF8.GetBytes(string.Join("\r\n",
		[
			"M-SEARCH * HTTP/1.1",
			"HOST: 239.255.255.250:1900",
			"MAN: \"ssdp:discover\"",
			"MX: 1",
			"ST: urn:lge:service:virtualSvc:1\r\n\r\n"
		]));

		try
		{
			var timeout = TimeSpan.FromSeconds(5);

			using var udp = new UdpClient();
			udp.Client.SendTimeout = timeout.Milliseconds;
			udp.Client.ReceiveTimeout = timeout.Milliseconds;
			udp.Client.Bind(new IPEndPoint(IPAddress.Any, 0));

			await udp.SendAsync(request, request.Length, new(
				IPAddress.Parse("239.255.255.250"), 1900)
			);

			var cts = new CancellationTokenSource(timeout);
			var result = await udp.ReceiveAsync(cts.Token);
			var response = Encoding.UTF8.GetString(result.Buffer);
			var split = response.Split("\r\n");

			if (!split[0].Contains("HTTP/1.1 200 OK"))
			{
				throw new WebOSException($"Invalid M-SEARCH response.\n Response: {response}");
			}

			var location = split.First(x => x.Contains("Location: ")).Split(": ")[1];

			using var http = new HttpClient();
			var httpResponse = await http.GetStringAsync(location);

			var serializer = new XmlSerializer(typeof(XmlUPnPRoot));
			using var reader = new StringReader(httpResponse);
			var root = (XmlUPnPRoot)serializer.Deserialize(reader);
			root.Device.Host = result.RemoteEndPoint.Address.ToString();

			return root.Device;
		}
		catch (Exception ex)
		when (ex is OperationCanceledException or SocketException)
		{
			throw new WebOSException("Couldn't locate webOS from local network!", ex);
		}
	}
}
