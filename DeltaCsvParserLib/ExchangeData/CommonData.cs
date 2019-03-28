using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaCsvParserLib {
    public class CommonData {
        /// <summary>
        /// Transfer types
        /// </summary>
        public enum TRANSACTION_TYPE {
            BUY,
            SELL,
            DEPOSIT,
            WITHDRAW,
            TRANSFER,
            UNKNOWN
        }
    }
}
