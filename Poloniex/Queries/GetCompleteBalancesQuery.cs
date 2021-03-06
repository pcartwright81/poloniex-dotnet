﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class GetCompleteBalancesQuery
	{
		public static async Task<IList<CompleteBalance>> GetCompleteBalancesAsync(this PoloniexClient client)
		{
			var response = await client.SendRequestAsync<Dictionary<String, CompleteBalance>>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnCompleteBalances"
			});

			foreach (var key in response.Keys)
			{
				response[key].Symbol = key;
			}

			return response.Values.ToList();
		}

		
	}
}
