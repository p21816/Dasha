using BLL;
using BLL.Interface;
using BLL.Interface.Entities;
using DAL;
using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountHolder holder1 = new AccountHolder(1, "Darya", "Battalova");
            AccountHolder holder2 = new AccountHolder(2, "Evgeniy", "Bazarov");
            BaseAccount baseAccount = new BaseAccount("1234567", holder1);
            GoldAccount goldAccount = new GoldAccount("5432123", holder2);
    

            baseAccount.AddMoney(100, new BaseAccountBonusCalculation());
         //   Console.WriteLine(baseAccount.Bonus.ToString());


            AccountService accountService = new AccountService(new AccountRepository());
            accountService.CreateAccount(baseAccount);
            accountService.CreateAccount(goldAccount);

            List<Account> accountList = new List<Account>();
            accountList = (List<Account>)accountService.GetAllAccounts();

            foreach(var i in accountList)
            {
                Console.WriteLine(i.ToString());
            }

      
        }
    }
}
