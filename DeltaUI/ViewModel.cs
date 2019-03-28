using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaUI {
    public class ViewModel {

        public ObservableCollection<string> ExchangeTypes { get; private set; }
        public ViewModel() {
            ExchangeTypes = new ObservableCollection<string> {
               "Bittrex",
               "Kraken ",
               "Poloniex",
               "Binance",
               "Coinbase",
               "Cryptonit",
            };
        }
    }
}
