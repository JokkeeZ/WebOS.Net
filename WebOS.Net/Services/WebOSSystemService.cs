using WebOS.Net.System;

namespace WebOS.Net.Services;

/// <summary>
/// Interacts with system and related API calls on a webOS device through the provided <see cref="WebOSClient"/>.
/// </summary>
/// <param name="client">The webOS client used to communicate with the device.</param>
public class WebOSSystemService(WebOSClient client)
{
	/// <summary>
	/// Gets system information such as model name, serial number etc.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="GetSystemInfo"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<GetSystemInfo> GetSystemInfoAsync()
	{
		var response = await client
			.SendRequestAsync<GetSystemInfoRequest, GetSystemInfoResponse, GetSystemInfo>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	/// <summary>
	/// Gets system settings such as locale info and eula status.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="GetSystemSettings"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<GetSystemSettings> GetSystemSettingsAsync()
	{
		var response = await client
			.SendRequestAsync<GetSystemSettingsRequest, GetSystemSettingsResponse, GetSystemSettings>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	/// <summary>
	/// Gets available services.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="GetServiceList"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<GetServiceList> GetServiceListAsync()
	{
		var response = await client
			.SendRequestAsync<GetServiceListRequest, GetServiceListResponse, GetServiceList>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	/// <summary>
	/// Gets configs through the provided list of configNames.
	/// </summary>
	/// <param name="configNames">Configuration names.</param>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="GetConfigs"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<GetConfigs> GetConfigsAsync(List<string> configNames)
	{
		ArgumentNullException.ThrowIfNull(nameof(configNames));

		var request = new GetConfigsRequest();
		request.Payload.ConfigNames.AddRange(configNames);

		var response = await client
			.SendRequestAsync<GetConfigsRequest, GetConfigsResponse, GetConfigs>(request);

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetPowerState> GetPowerStateAsync()
	{
		var response = await client
			.SendRequestAsync<GetPowerStateRequest, GetPowerStateResponse, GetPowerState>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> TurnOffAsync()
	{
		var response = await client.SendRequestAsync<TurnOffRequest>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<TurnOnScreen> TurnOnScreenAsync()
	{
		var response = await client.SendRequestAsync<TurnOnScreenRequest, TurnOnScreenResponse, TurnOnScreen>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<TurnOffScreen> TurnOffScreenAsync()
	{
		var response = await client.SendRequestAsync<TurnOffScreenRequest, TurnOffScreenResponse, TurnOffScreen>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
