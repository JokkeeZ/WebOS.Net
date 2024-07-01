﻿using WebOS.Net.TV;

namespace WebOS.Net.Services;

public class WebOSTVService(WebOSClient client)
{
	public async Task<GetChannelList> GetChannelListAsync()
	{
		var response = await client.SendRequestAsync<GetChannelListRequest, GetChannelListResponse, GetChannelList>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetChannelProgramInfo> GetChannelProgramInfoAsync()
	{
		var response = await client
			.SendRequestAsync<GetChannelProgramInfoRequest, GetChannelProgramInfoResponse, GetChannelProgramInfo>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
