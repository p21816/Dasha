using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class PlatinumAccountBonusCalculationService : AbstractBonusCalculator
    {
        /// <summary>
        /// calculetes bonus for platinum account
        /// </summary>
        /// <param name="value">sum of money for transaction</param>
        /// <returns>bonus</returns>
        public int CalculateBinusOnAdd(decimal value)
        {
            return GetPercentOf(value, 30);
        }

        /// <summary>
        /// calculetes bonus for platinum account
        /// </summary>
        /// <param name="value">sum of money for transaction</param>
        /// <returns>bonus</returns>
        public int CalculateBinusOnWithdraw(decimal value)
        {
            return GetPercentOf(value, 15);
        }
    }
}
