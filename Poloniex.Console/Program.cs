using System;

namespace Poloniex.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			PoloniexClient Client = new PoloniexClient("", "");
			var bal = Client.GetBalancesAsync().GetAwaiter().GetResult();
		}
	}
}
