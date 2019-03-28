using DeltaCsvParserLib.ExchangeData;
using System;
using System.Globalization;
using static DeltaCsvParserLib.CommonData;

namespace DeltaCsvParser.ExchangeData {
    public class BittrexData: BaseExchangeData{

        /// <summary>
        /// Order identificator
        /// </summary>
        public string OrderUuid { get; set; }

        /// <summary>
        /// Constructor with csv line parameter
        /// </summary>
        /// <param name="line">CSV line with the operation</param>
        public BittrexData(String line) {
            string[] fields = line.Split(',');

            try {
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

            } catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Method to set the standar date as Delta required
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private string SetStandarDate(string date) {
            string formattedDate = String.Empty;
            string dateFormat = "yyyy-MM-dd hh:mm:ss zzz";

            if (DateTime.TryParseExact(date, "M/d/yyyy h:mm:ss tt",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime parsedDateTime)) {
                formattedDate = parsedDateTime.ToString(dateFormat);
            } else {
                Console.WriteLine("Parsing failed");
            }

            return formattedDate;
        }

        /// <summary>
        /// Método para parsear el string de la operacion del csv a el tipo de transaccion
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        private TRANSACTION_TYPE GetTypeEnum(string transactionType) {
            TRANSACTION_TYPE result;

            switch (transactionType) {
                case "LIMIT_BUY":
                    result = TRANSACTION_TYPE.BUY;
                    break;
                case "LIMIT_SELL":
                    result = TRANSACTION_TYPE.SELL;
                    break;
                default:
                    Console.WriteLine("Añadir " + transactionType + " al método GetTypeEnum()");
                    result = TRANSACTION_TYPE.UNKNOWN;
                    break;
            }

            return result;
        }
    }
}
