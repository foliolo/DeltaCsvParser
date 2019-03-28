using DeltaCsvParserLib.ExchangeData;
using static DeltaCsvParserLib.CommonData;

namespace DeltaCsvParserLib {
    interface IExchangeParcelableCsv {
        /// <summary>
        /// Read the file 
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <param name="type">Path to the file</param>
        /// <returns>Returns the super class with the needed data</returns>
        BaseExchangeData ReadExcel(string filePath, TRANSACTION_TYPE type);

        /// <summary>
        /// Generate de csv to import to Delta program
        /// </summary>
        /// <param name="deltaCsv">Class with all information needed to build the Delta csv</param>
        /// <returns>Return true if the files has been created, false otherwise</returns>
        bool ExportToDelta(BaseExchangeData deltaCsv);
    }
}
