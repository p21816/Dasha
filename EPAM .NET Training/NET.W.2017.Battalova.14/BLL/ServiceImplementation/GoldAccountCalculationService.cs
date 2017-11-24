using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class GoldAccountBonusCalculationService : AbstractBonusCalculator
    {
        /// <summary>
        /// calculetes bonus for gold account
        /// </summary>
        /// <param name="value">sum of money for transaction</param>
        /// <returns>bonus</returns>
        public int CalculateBinusOnAdd(decimal value)
        {
            return GetPercentOf(value, 20);
        }

        /// <summary>
        /// calculetes bonus for gold account
        /// </summary>
        /// <param name="value">sum of money for transaction</param>
        /// <returns>bonus</returns>
        public int CalculateBinusOnWithdraw(decimal value)
        {
            return GetPercentOf(value, 10);
        }
    }
}
