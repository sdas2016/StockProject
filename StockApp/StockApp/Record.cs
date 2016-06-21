using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public class Record
    {
        public string Symbol { get; set; }
        public DateTime Timestamp { get; set; }
        public int QtyShares { get; set; }
        public string BuySell { get; set; }
        public double TradePrice { get; set; }

        //Calculates the records for a trade
        public List<Record> Trade(string arg)
        {
            List<Record> record = new List<Record>();
            Random rdm = new Random();
            string[] tradeType = { "Buy", "Sell" };
            var itt = rdm.Next(tradeType.Count());

            for (int i = 0; i < 15; i++)
            {
                Record rcrd = new Record();
                rcrd.Symbol = arg;
                rcrd.Timestamp = DateTime.Now.AddMinutes(i);
                rcrd.QtyShares = rdm.Next(50);
                rcrd.BuySell = tradeType[itt];
                rcrd.TradePrice = rdm.NextDouble();
                record.Add(rcrd);
            }
            return record;
        }

        //Calculates the stock price
        public double StockPrice(List<Record> list, string testStock)
        {
            DateTime date = DateTime.Now;
            var sumQtyShares = 0;
            var totalPrice = 0.0;
            var result = 0.0;

            foreach (Record r in list)
            {
                if (r.Symbol.ToUpper().Equals(testStock))
                {
                    var d = (r.Timestamp - date).TotalMinutes;
                    //Last 15 minutes calculation
                    if (d <= 15)
                    {
                        totalPrice += (r.QtyShares * r.TradePrice);
                        sumQtyShares += r.QtyShares;
                    }
                }
            }
            if (sumQtyShares > 0)
                result = totalPrice / sumQtyShares;

            return result;
        }

        //Calculates the GBCE
        public double GBCE(List<Record> record, string testStock)
        {
            var prices = 0.0;
            foreach (Record rec in record)
            {
                if (rec.Symbol.ToUpper().Equals(testStock.ToUpper()))
                {
                    prices += rec.TradePrice;
                }
            }
            return Math.Pow(prices, 1.0 / record.Count);
        }
    }
}
