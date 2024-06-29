using WebOS.Net.Notification;

namespace WebOS.Net.Managers;

/// <summary>
/// Manages notifications on a webOS device through the provided <see cref="WebOSClient"/>.
/// </summary>
/// <param name="client">The webOS client used to communicate with the device.</param>
public class WebOSNotificationManager(WebOSClient client)
{
	/// <summary>
	/// Sends an toast notification with message to the webOS.
	/// </summary>
	/// <param name="message">Message to display in the notification.</param>
	/// <returns></returns>
	/// <exception cref="WebOSException">
	/// Exception that occurs when client is not connected/paired, or trying to send invalid message.
	/// </exception>
	public async Task<CreateToast> ToastAsync(string message)
	{
		if (!client.IsActive)
		{
			throw new WebOSException("Client is not connected or paired.");
		}

		if (string.IsNullOrEmpty(message))
		{
			throw new WebOSException("Toast message cannot be empty!");
		}

		var request = new CreateToastRequest();
		request.Payload.Message = message;

		var response = await client.SendRequestAsync<CreateToastRequest, ToastResponse, CreateToast>(request);

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	/// <summary>
	/// Sends an alert notification with message and buttons to the webOS.
	/// </summary>
	/// <param name="message">Message to display in the notification.</param>
	/// <param name="buttons">Buttons to display in the notification.</param>
	/// <returns></returns>
	/// <exception cref="WebOSException">
	/// Exception that occurs when client is not connected/paired, 
	/// trying to send invalid message or <paramref name="buttons"/> is null/empty.
	/// </exception>
	public async Task<CreateAlert> AlertAsync(string message, List<WebOSButton> buttons)
	{
		if (!client.IsActive)
		{
			throw new WebOSException("Client is not connected or paired.");
		}

		if (string.IsNullOrEmpty(message))
		{
			throw new WebOSException("Alert message cannot be empty!");
		}

		if (buttons == null || buttons.Count == 0)
		{
			throw new WebOSException("Alert needs to have at least 1 button!");
		}

		var request = new CreateAlertRequest();
		request.Payload.Message = message;
		request.Payload.Buttons = buttons;

		var response = await client.SendRequestAsync<CreateAlertRequest, AlertResponse, CreateAlert>(request);

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
