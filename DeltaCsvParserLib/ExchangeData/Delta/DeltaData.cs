using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeltaCsvParserLib.ExchangeData {

    /// <summary>
    /// Base class that will be used to generate delta's csv
    /// </summary>
    public class DeltaData : BaseExchangeData {
        /// <summary>
        /// The exchange where the trade (or deposit/withdraw) was made. Optional for trades. When not specified, we'll use the Global Average to calculate the costs/proceeds and worth on
        /// </summary>
        public string Exchange { get; set; }

        /// <summary>
        /// The fee that was paid on the trade or transfer
        /// </summary>
        public string Fee { get; set; }

        /// <summary>
        /// The currency of the fee
        /// </summary>
        public string FeeCurrency { get; set; }

        /// <summary>
        /// Optional, used for an ICO, we'll take this amount as money invested
        /// </summary>
        public string CostsProceeds { get; set; }

        /// <summary>
        /// Optional, used for an ICO, the currency of the amount invested
        /// </summary>
        public string CostsProceedsCurrency { get; set; }

        /// <summary>
        /// Optional, for trades. When set to 1, the quote will be added to or deducted from your holdings (depending if it's a SELL or BUY). It's recommended but it can result in a negative balance if you manually entered corresponding trades/transfers.
        /// </summary>
        public bool SyncHoldings { get; set; }

        /// <summary>
        /// Your notes you want to keep for this transaction (optional)
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public DeltaData() { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bittrexOperations"></param>
        internal static void PojoToCSV(List<DeltaData> bittrexOperations, string folder) {
            //before your loop
            var csv = new StringBuilder();
            csv.AppendLine("Date,Type,Exchange,Base amount, Base currency,Quote amount, Quote currency,Fee,Fee currency, Costs/ Proceeds,Costs / Proceeds currency,Sync Holdings, Sent/ Received from,Sent to, Notes");

            foreach (DeltaData item in bittrexOperations) {
                csv.Append(item.Date + ",");
                csv.Append(item.TType + ",");
                csv.Append(item.Exchange + ",");
                csv.Append(item.BaseAmount + ",");
                csv.Append(item.BaseCurrency + ",");
                csv.Append(item.QuoteAmount + ",");
                csv.Append(item.QuoteCurrency + ",");
                csv.Append(item.Fee + ",");
                csv.Append(item.FeeCurrency + ",");
                csv.Append(item.CostsProceeds + ",");
                csv.Append(item.CostsProceeds + ",");
                csv.Append((item.SyncHoldings ? "1" : "0") + ",");
                csv.Append(item.SentReceivedFrom + ",");
                csv.Append(item.SentTo + ",");
                csv.Append(item.Notes);
                csv.AppendLine();
            }

            File.WriteAllText(folder + @"\Delta.csv", csv.ToString());
        }
    }
}
