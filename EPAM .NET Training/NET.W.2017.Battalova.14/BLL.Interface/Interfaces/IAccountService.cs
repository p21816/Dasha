using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        Account CreateNewAccount(string HolderName, decimal sum, int bonus, string type);
        void AddMoney(Account account, decimal money);
        void WithdrawMoney(Account account, decimal money);
    }
}
