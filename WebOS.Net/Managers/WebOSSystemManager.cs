using WebOS.Net.System;

namespace WebOS.Net.Managers;

public class WebOSSystemManager(WebOSClient client)
{
	public async Task<GetSystemInfo> GetSystemInfoAsync()
	{
		var response = await client
			.SendRequestAsync<GetSystemInfoRequest, GetSystemInfoResponse, GetSystemInfo>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetSystemSettings> GetSystemSettingsAsync()
	{
		var response = await client
			.SendRequestAsync<GetSystemSettingsRequest, GetSystemSettingsResponse, GetSystemSettings>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetServiceList> GetServiceListAsync()
	{
		var response = await client
			.SendRequestAsync<GetServiceListRequest, GetServiceListResponse, GetServiceList>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetConfigs> GetConfigsAsync(List<string> configNames)
	{
		if (configNames == null || configNames?.Count == 0)
		{
			ArgumentNullException.ThrowIfNullOrEmpty(nameof(configNames));
		}

		var request = new GetConfigsRequest();
		request.Payload.ConfigNames.AddRange(configNames);

		var response = await client
			.SendRequestAsync<GetConfigsRequest, GetConfigsResponse, GetConfigs>(request);

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
