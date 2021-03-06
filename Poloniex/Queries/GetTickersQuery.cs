﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class GetTickersQuery
	{
		public static async Task<IDictionary<String, Ticker>> GetTickersAsync(this PoloniexClient client)
		{
			return await client.SendRequestAsync<Dictionary<String, Ticker>>(new PoloniexRequest
			{
				Api = PoloniexApi.Public,
				Command = "returnTicker"
			});
		}
	}
}
