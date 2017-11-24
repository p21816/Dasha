using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IBonusCalculator
    {
        int CalculateBinusOnAdd(decimal value);
        int CalculateBinusOnWithdraw(decimal value);
    }
}
