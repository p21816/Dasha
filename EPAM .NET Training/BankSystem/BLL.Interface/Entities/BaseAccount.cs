using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BaseAccount: Account
    {
       public BaseAccount() { }
       public BaseAccount(string accountNumber, AccountHolder accountHolder) :
            base(accountNumber, accountHolder)
       {
           this.Type = "base";
       }

       public void AddMoney(decimal sum, IBonusCalculator calculator)
       {
           this.bonus += calculator.CalculateBonus(sum);
       }
    }
}
