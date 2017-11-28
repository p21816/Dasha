using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class Stock 
    {
        private StockInfo stocksInfo;
        public event EventHandler<MarketChangedEventArgs> MarketChanged = delegate { };

        public Stock()
        {
            stocksInfo = new StockInfo();
        }
        public void Market()
        {
            Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);
            OnMarketChanged(new MarketChangedEventArgs(stocksInfo.USD, stocksInfo.Euro));
        }

        public void OnMarketChanged(MarketChangedEventArgs eventArgs)
        {
            EventHandler<MarketChangedEventArgs> temp = MarketChanged;
            if(temp != null) temp.Invoke(this, eventArgs);
        }
    }
}
