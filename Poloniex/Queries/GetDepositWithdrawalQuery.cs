using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poloniex.Models;

namespace Poloniex.Queries
{
	public static class GetDepositWithdrawalQuery
	{
		public static async Task<IList<DepositWithdrawal>> GetDepositWithdrawalAsync(this PoloniexClient clien,
			DateTime? start = null, DateTime? end = null)
		{
			var response = await clien.SendRequestAsync<Dictionary<String, DepositWithdrawal[]>>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnDepositsWithdrawals",
				Parameters =
				{
					{"start", start?.ToUnixTimestamp().ToString()},
					{"end", end?.ToUnixTimestamp().ToString()},
				}
			});

			return response.SelectMany(x =>
			{
				foreach (var value in x.Value)
				{
					value.Type = x.Key;
				}

				return x.Value;
			}).ToList();
		}

	}
}
