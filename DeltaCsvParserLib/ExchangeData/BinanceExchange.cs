using DeltaCsvParserLib.ExchangeData.Binance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DeltaCsvParserLib.CommonData;

namespace DeltaCsvParserLib.ExchangeData {
    class BinanceExchange : IExchangeParcelableCsv {

        List<BinanceTransactionData> transactions;
        List<BinanceDepositWithdrawData> depositWithdraws;

        public BinanceExchange() {
            transactions = new List<BinanceTransactionData>();
            depositWithdraws = new List<BinanceDepositWithdrawData>();
        }

        public BaseExchangeData ReadExcel(string filePath, TRANSACTION_TYPE type) {
            try {
                using (StreamReader sr = new StreamReader(filePath)) {

                    sr.ReadLine(); //Descarte de la primera line de cabecera

                    string line = string.Empty;
                    while (!sr.EndOfStream) {
                        line = sr.ReadLine();

                        switch (type) {
                            case TRANSACTION_TYPE.BUY:
                            case TRANSACTION_TYPE.SELL:
                                transactions.Add(new BinanceTransactionData(line));
                                break;
                            case TRANSACTION_TYPE.DEPOSIT:
                            case TRANSACTION_TYPE.WITHDRAW:
                                depositWithdraws.Add(new BinanceDepositWithdrawData(line));
                                break;
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine(Path.GetFileName(filePath));
            return null;
        }

        public bool ExportToDelta(BaseExchangeData deltaCsv) {
            throw new NotImplementedException();
        }
    }
}
