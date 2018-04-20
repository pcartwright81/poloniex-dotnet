using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poloniex.Models;

namespace Poloniex.Queries
{
	public static class GetDepositAddressesQuery
	{
		public static async Task<IList<DepositAddress>> GetDepositAddressesAsync(this PoloniexClient clien)
		{
			var response = await clien.SendRequestAsync<Dictionary<string, string>>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnDepositAddresses"
			});

			return response.Select(x => new DepositAddress
			{
				Symbol = x.Key,
				Address = x.Value
			}).ToList();
		}
	}
}
