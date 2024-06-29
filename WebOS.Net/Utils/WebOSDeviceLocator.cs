using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace WebOS.Net.Utils;

public class WebOSDeviceLocator
{
	static readonly IPEndPoint multicast = new(IPAddress.Parse("239.255.255.250"), 1900);

	public static async Task<IPEndPoint> MSearchForDeviceAsync()
	{
		var request = Encoding.UTF8.GetBytes(string.Join("\r\n",
		[
			"M-SEARCH * HTTP/1.1",
			$"HOST: {multicast.Address}:{multicast.Port}",
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

			await udp.SendAsync(request, request.Length, new(multicast.Address, multicast.Port));

			var cts = new CancellationTokenSource(timeout);
			var result = await udp.ReceiveAsync(cts.Token);
			var response = Encoding.UTF8.GetString(result.Buffer);

			if (!response.Contains("HTTP/1.1 200 OK"))
			{
				throw new WebOSException($"Invalid M-SEARCH response.\n Response: {response}");
			}

			return new(result.RemoteEndPoint.Address, 3001);
		}
		catch (Exception ex)
		when (ex is OperationCanceledException or SocketException)
		{
			throw new WebOSException("Couldn't locate webOS from local network!", ex);
		}
	}

	public static async Task SendWakeOnLan(PhysicalAddress mac)
	{
		var magicPacket = MagicPacket(mac);

		using var client = new UdpClient();
		await client.SendAsync(magicPacket, magicPacket.Length, new(IPAddress.Broadcast, 9));
	}

	static byte[] MagicPacket(PhysicalAddress mac)
	{
		var header = Enumerable.Repeat(byte.MaxValue, 6);
		var data = Enumerable.Repeat(mac.GetAddressBytes(), 16).SelectMany(mac => mac);

		return header.Concat(data).ToArray();
	}
}
