using BLL;
using BLL.Interface;
using BLL.Interface.Entities;
using DAL;
using DAL.Interface;
using DAL.Interface.DTO;
using ORM;
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

           EntityModel db = new EntityModel();

            BLL.Interface.Entities.AccountHolder holder1 = new BLL.Interface.Entities.AccountHolder(1, "Darya", "Battalova");
            //AccountHolder holder2 = new AccountHolder(2, "Evgeniy", "Bazarov");
            BaseAccount baseAccount = new BaseAccount(1 ,"1234567", holder1);
            //GoldAccount goldAccount = new GoldAccount(1 , "5432123", holder2);


            baseAccount.AddMoney(100, new BaseAccountBonusCalculation());

            AccountService accountService = new AccountService(new AccountRepository(db));

            Console.WriteLine("1");
            accountService.CreateAccount(baseAccount);
            //accountService.CreateAccount(goldAccount);
            Console.WriteLine("2");


            using (db)
            {
                Console.WriteLine("item1");

                foreach (var u in db.Accounts)
                {
                    Console.WriteLine("item");
                    Console.WriteLine(u.ToString());
                }

                Console.WriteLine("item2");

            }




            //List<Account> accountList = new List<Account>();
            //accountList = (List<Account>)accountService.GetAllAccounts();

            //foreach(var i in accountList)
            //{
            //    Console.WriteLine(i.ToString());
            //}


            //Console.WriteLine("found account: " + accountService.GetAccountById(1).ToString());



            //accountService.DeleteAccount(baseAccount);

            //List<Account> accountList1 = new List<Account>();
            //accountList1 = (List<Account>)accountService.GetAllAccounts();
            //foreach (var i in accountList1)
            //{
            //    Console.WriteLine(i.ToString());
            //}
      
        }
    }
}
