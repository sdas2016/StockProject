using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public enum StockType
    {
        Common,
        Preferred,
    }

    public class Stock
    {
        public string Symbol { get; set; }
        public string Type { get; set; }
        public int LastDividend { get; set; }
        public double FixedDividend { get; set; }
        public int PartValue { get; set; }

        //Calculate the Dividend Yield
        public double DividendYield(Stock stock, double tickerPrice)
        {
            double result = 0;
            try
            {
                if (tickerPrice > 0)
                {
                    if (stock != null && stock.Type.ToUpper().Equals(StockType.Preferred.ToString().ToUpper()))
                    {
                        //Dividend Yield for Preffered StockType
                        result = (stock.FixedDividend * stock.PartValue) / tickerPrice;
                    }
                    else
                    {
                        //Dividend Yield for Common StockType
                        if (stock != null) result = stock.LastDividend / tickerPrice;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        //Calculate the P/E Ratio
        public double PERatio(Stock stock, double tickerPrice)
        {
            double result = 0;
            try
            {
                var dividend = DividendYield(stock, tickerPrice);
                if (dividend > 0)
                {
                    result = tickerPrice / dividend;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

    }
}
