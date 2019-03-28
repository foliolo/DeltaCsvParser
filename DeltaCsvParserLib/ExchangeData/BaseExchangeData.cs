using System;
using static DeltaCsvParserLib.CommonData;

namespace DeltaCsvParserLib.ExchangeData {
    public class BaseExchangeData {
        /// <summary>
        /// The date of the transaction (UTC).
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The type of the transaction. For trades you can specify 'BUY' or 'SELL', and for transfers you can specify 'DEPOSIT', 'WITHDRAW' or 'TRANSFER'
        /// </summary>
        public TRANSACTION_TYPE TType { get; set; }

        /// <summary>
        /// The amount you were trading or transferring (excluding fees)
        /// </summary>
        public string BaseAmount { get; set; }

        /// <summary>
        /// The currency you were trading or transferring
        /// </summary>
        public string BaseCurrency { get; set; }

        /// <summary>
        /// For trades, the amount you were trading it for (excluding fees). It can be calculated as the price per coin * the amount of coins traded
        /// </summary>
        public string QuoteAmount { get; set; }

        /// <summary>
        /// The trade currency
        /// </summary>
        public string QuoteCurrency { get; set; }

        /// <summary>
        /// In case of an ICO, this field should be 'ICO', otherwise it's only used for transfers. You can specify the name of an exchange, 'MY_WALLET', 'OTHER_WALLET', 'BANK', 'AIRDROP', 'MINING', 'FORK', 'DIVIDENDS' or 'OTHER'
        /// </summary>
        public string SentReceivedFrom { get; set; }

        /// <summary>
        /// Only used for transfers. You can specify the name of an exchange, 'MY_WALLET', 'OTHER_WALLET', 'BANK' or 'OTHER'
        /// </summary>
        public string SentTo { get; set; }
    }
}


/* Información adiciona:
 * 
 * ¿Qué datos se importan?
 * Importamos todsas las filas que se pueen validra. Esto incluye compras, ventas, transferencias, retiradas y depósitos.
 * También importaremos tarifas de transacción, notas, marcas de tiempo y otros datos si se proporcionan.
 * 
 * ¿Qué columnas son obligatorias?
 * Para todos los tipos de transacciones se requieren las siguientes columnas: Fecha, Tipo, Importe base, Moneda base, 
 * Importe de cotización y Moneda de cotización. Si no se completan una o más de estas columnas, la fila no se importará.
 * Para las transferencias, se requieren columnas adicionales: Enviado/Recibido desde, y enaviado a.
 * 
 */
