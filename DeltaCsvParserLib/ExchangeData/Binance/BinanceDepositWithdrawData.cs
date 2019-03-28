using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaCsvParserLib.ExchangeData.Binance {
    public class BinanceDepositWithdrawData : BaseExchangeData {
        private string address;
        private string txid;
        private string status;

        public BinanceDepositWithdrawData(string line) { }
    }
}
