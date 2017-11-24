using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public abstract class AbstractBonusCalculator : IBonusCalculator
    {
        /// <summary>
        /// calculates percent of bonus
        /// </summary>
        /// <param name="value">sum of money for transaction</param>
        /// <param name="percent">percent depending on type of account</param>
        /// <returns>percent to be added as a bonus</returns>
        protected int GetPercentOf(decimal value, int percent)
        {
            decimal result = value * percent / 100;
            int res = Convert.ToInt32(result);
            return res;
        }
    }
}
