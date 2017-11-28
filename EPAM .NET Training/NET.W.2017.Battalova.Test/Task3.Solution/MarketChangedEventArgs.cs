using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class MarketChangedEventArgs: EventArgs
    {
        private int usd;
        private int euro;

        #region Properties
        public int Usd
        {
            get { return usd; }
        }
        public int Euro
        {
            get { return euro; }
        }

        #endregion
        public MarketChangedEventArgs(int usd, int euro)
        {
            this.usd = usd;
            this.euro = euro;
        }
    }
}
