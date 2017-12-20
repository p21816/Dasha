using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BaseAccountBonusCalculation: IBonusCalculator
    {
        public int CalculateBonus(decimal sum)
        {
            decimal result = sum * 5 / 100;
            int res = Convert.ToInt32(result);
            return res;
        }
    }
}
