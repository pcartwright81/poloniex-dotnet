using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Poloniex.Models
{
	public class DepositWithdrawal
	{
		[JsonProperty("txid")]
		public String TxId { get; set; }

		[JsonProperty("currency")]
		public String Symbol { get; set; }

		[JsonIgnore]
		public String Type { get; set; }

		[JsonIgnore]
		public DateTime Date { get; set; }

		[JsonProperty("timestamp")]
		private ulong TimeStamp
		{
			set { this.Date = ExtensionMethods.FromUnixTimestamp(value); }
		}
		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("fee")]
		public Decimal Fees { get; set; }

		[JsonProperty("status")]
		public String Status { get; set; }

		[JsonProperty("address")]
		public String Address { get; set; }
	}
}
