using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ticker price hardcoded
            var tickerPrice = 5.0;
            //Stock Symbol to be tested
            string TestStock = "GIN";

            var dividendYield = 0.0;
            var pERatio = 0.0;
            var geometricMean = 0.0;
            var stockPrice = 0.0;

            List<Record> tradeRecord = new List<Record>();
            Stock stock = new Stock();
            Record record = new Record();
            Domain data = new Domain();
            var stockList = data.GetStockList();

            //For the specified symbol the Dividend Yield, P/E Ratio, Stock Price and the Geometric Mean will be calculated and displayed as well a list of some records of the trade generated randomly.
            //The result will be displayed.
            foreach (KeyValuePair<int, Stock> stk in stockList)
            {
                if (stk.Value.Symbol.Equals(TestStock.ToUpper()))
                {
                    dividendYield = stock.DividendYield(stk.Value, tickerPrice);

                    pERatio = stock.PERatio(stk.Value, tickerPrice);

                    tradeRecord = record.Trade(TestStock);

                    stockPrice = record.StockPrice(tradeRecord, TestStock);

                    geometricMean = record.GBCE(tradeRecord, TestStock);
                }
            }

            Console.WriteLine("Stock Name: " + TestStock);
            Console.WriteLine("..................................");
            Console.WriteLine("Dividend Yield: " + dividendYield);
            Console.WriteLine();
            Console.WriteLine("P/E Ratio: " + pERatio);
            Console.WriteLine();
            Console.WriteLine("The records for the trade in the last 15 minutes are: ");
            Console.WriteLine("......................................................");

            //Recording trades in last 15minutes
            foreach (Record rec in tradeRecord)
            {
                Console.WriteLine("Symbol: " + rec.Symbol + ", Time: " + rec.Timestamp + ", Shares: " + rec.QtyShares + ", Buy/Sell: " + rec.BuySell + ", Price: " + rec.TradePrice);
            }
            Console.WriteLine();
            Console.WriteLine("Stock price: " + stockPrice);
            Console.WriteLine();
            Console.WriteLine("Global Beverage Corporation Exchange: " + geometricMean);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
