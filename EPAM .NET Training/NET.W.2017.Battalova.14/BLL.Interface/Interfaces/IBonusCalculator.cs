using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IBonusCalculator
    {
        int GetPercentOf(decimal value, int percent);
         int CalculateBinusOnWithdraw(decimal value);
    
         int CalculateBinusOnAdd(decimal value);
   
    }
}
