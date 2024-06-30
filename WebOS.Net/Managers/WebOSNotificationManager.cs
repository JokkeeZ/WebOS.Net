﻿using WebOS.Net.Notification;

namespace WebOS.Net.Managers;

/// <summary>
/// Interacts with notification and related API calls on a webOS device through the provided <see cref="WebOSClient"/>.
/// </summary>
/// <param name="client">The webOS client used to communicate with the device.</param>
public class WebOSNotificationManager(WebOSClient client)
{
	/// <summary>
	/// Creates an toast notification on webOS device with prodived message.
	/// </summary>
	/// <param name="message">Toast message</param>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="CreateToast"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<CreateToast> CreateToastAsync(string message)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(message));

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
	/// Creates an alert notification on webOS device with prodived message.
	/// </summary>
	/// <param name="message">Alert message</param>
	/// <param name="buttons">List of <see cref="WebOSButton"/>s to display in the alert notification</param>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="CreateAlert"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<CreateAlert> CreateAlertAsync(string message, List<WebOSButton> buttons)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(message));
		ArgumentNullException.ThrowIfNull(nameof(buttons));

		if (buttons.Count < 1)
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

	public async Task<CloseToast> CloseToastAsync(string toastId)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(toastId));

		var request = new CloseToastRequest();
		request.Payload.ToastId = toastId;

		var response = await client
			.SendRequestAsync<CloseToastRequest, CloseToastResponse, CloseToast>(request);

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<CloseAlert> CloseAlertAsync(string alertId)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(alertId));

		var request = new CloseAlertRequest();
		request.Payload.AlertId = alertId;

		var response = await client
			.SendRequestAsync<CloseAlertRequest, CloseAlertResponse, CloseAlert>(request);

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
