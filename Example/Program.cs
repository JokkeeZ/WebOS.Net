using WebOS.Net;

using var client = new WebOSClient(
	// WebOS TV IPv4 address
	ipAddress: "192.168.0.11",

	// Port 3001 for wss.
	port: 3001,

	// Provide a client-key or leave empty to obtain a client-key.
	clientKey: string.Empty
);

// The TV will display a prompt if a client-key is not provided.
await client.ConnectAsync();

if (client.IsPaired)
{
	Console.WriteLine($"Client Key: {client.ClientKey}");

	// Send Toast notification to webOS TV
	await client.Notifications.CreateToastAsync("Hello! :)");
}
