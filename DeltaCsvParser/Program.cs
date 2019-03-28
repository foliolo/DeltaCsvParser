using DeltaCsvParser.ExchangeData;
using DeltaCsvParserLib.ExchangeData;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeltaCsvParser {

    /// <summary>
    /// Inicio al programa principal
    /// </summary>
    class Program {

        /// <summary>
        /// Main Class
        /// </summary>
        /// <param name="args">Argumentos de entrada por liena de comandos</param>
        static void Main(string[] args) {

            // Control del directorio a analizar
            string rootFolder = args[0];
            if (String.IsNullOrEmpty(args[0])) {
                rootFolder = Directory.GetCurrentDirectory();
            }

            //Cargar los datos de los ficheros en las estructuras de cada exchange
                List<DeltaData> deltaOperations = new List<DeltaData>();

            foreach (string folder in Directory.GetDirectories(rootFolder)) {
                foreach (string file in Directory.GetFiles(folder)) {

                    switch (Path.GetFileName(folder)) {
                        case "binance":
                            Console.WriteLine(Path.GetFileName(folder));
                            break;
                        case "bittrex":
                            try {
                                using (StreamReader sr = new StreamReader(file)) {

                                    sr.ReadLine(); //Descarte de la primera line de cabecera

                                    string line = string.Empty;
                                    while (!sr.EndOfStream) {
                                        line = sr.ReadLine();
                                        deltaOperations.Add(new BittrexData(line));
                                    }
                                }
                            } catch (Exception e) {
                                Console.WriteLine("The File could not be read:");
                                Console.WriteLine(e.Message);
                                Console.ReadLine();
                            }
                            Console.WriteLine(Path.GetFileName(file));
                            break;
                        case "coinbase":
                            Console.WriteLine(Path.GetFileName(folder));
                            break;
                        case "kraken":
                            Console.WriteLine(Path.GetFileName(folder));
                            break;
                        case "poloniex":
                            Console.WriteLine(Path.GetFileName(folder));
                            break;
                    }
                }
            }

            DeltaData.PojoToCSV(deltaOperations, rootFolder);
        }
    }
}