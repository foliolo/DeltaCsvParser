using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaCsvParserLib.ExchangeData.Binance {
    public class BinanceTransactionData : BaseExchangeData {
        string OrderUuid { get; set; }
        string Exchange { get; set; }
        string Pair { get; set; }
        string AvgTradingPrice { get; set; }
        string Filled { get; set; }
        string Total { get; set; }
        string Status { get; set; }
        string Line { get; set; }

        public BinanceTransactionData(string line) {
            string[] fields = line.Split(',');

            OrderUuid = fields[0];

            Date = SetStandarDate(fields[8]);
            TType = GetTypeEnum(fields[2]);
            Exchange = "BitTrex";
            BaseAmount = fields[3];
            BaseCurrency = fields[1].Split('-')[1];
            QuoteAmount = fields[6];
            QuoteCurrency = fields[1].Split('-')[0];
            Fee = fields[5];
            FeeCurrency = fields[1].Split('-')[0];
            CostsProceeds = String.Empty;
            CostsProceedsCurrency = String.Empty;
            SyncHoldings = false;
            SentReceivedFrom = String.Empty;
            SentTo = String.Empty;
            Notes = String.Empty;
        }
    }
}
