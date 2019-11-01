using System;
using Microsoft.Extensions.Configuration;

namespace Poloniex.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder().AddUserSecrets<PoloniexKeys>();
			IConfiguration configuration = builder.Build();
			var poloniexKeys = configuration.GetSection("PoloniexKeys").Get<PoloniexKeys>();
			var client = new PoloniexClient(poloniexKeys.APIKey, poloniexKeys.APISecret);
			var bal = client.GetBalancesAsync().GetAwaiter().GetResult();
		}
	}
}
