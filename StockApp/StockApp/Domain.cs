using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public class Domain
    {
        private Dictionary<int, Stock> _stockList;

        public Dictionary<int, Stock> GetStockList()
        {
            _stockList = new Dictionary<int, Stock>()
            {
                {1, new Stock {Symbol="TEA", Type="Common", LastDividend = 0, PartValue=100 } },
                {2, new Stock {Symbol="POP", Type="Common", LastDividend =8,PartValue=100 } },
                {3, new Stock {Symbol="ALE", Type="Common", LastDividend=23,  PartValue=60 } },
                {4, new Stock {Symbol="GIN", Type="Preferred", LastDividend=8, FixedDividend=0.02,PartValue=100 } },
                {5, new Stock {Symbol="JOE", Type="Common", LastDividend=13, PartValue=250 } }
            };

            return _stockList;
        }
    }
}
