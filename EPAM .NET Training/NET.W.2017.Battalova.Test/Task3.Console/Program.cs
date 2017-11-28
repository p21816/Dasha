using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            StockInfo info = new StockInfo();

            Broker broker = new Broker("Mr.Broker");
            stock.MarketChanged += broker.BuyOrNotToBuy;

            Bank bank = new Bank("customBank");
            stock.MarketChanged += bank.BuyOrNotToBuy;

            stock.Market();

        }
    }
}
