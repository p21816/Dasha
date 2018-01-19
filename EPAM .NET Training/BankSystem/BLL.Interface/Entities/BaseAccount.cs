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
       public BaseAccount(int id, string accountNumber, AccountHolder accountHolder) :
            base(id, accountNumber, accountHolder)
       {
           this.Type = "base";
       }

       public void AddMoney(decimal sum, IBonusCalculator calculator)
       {
           this.Balance += sum;
           this.Bonus += calculator.CalculateBonus(sum);
       }
    }
}
