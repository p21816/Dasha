using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class Account
    {

        #region Fields

        private int id;
        private string accountNumber;
        private AccountHolder accountHolder;
        private decimal balance;
        private int bonus;
        private string type;

        private const string typeBasic = "basic";
        private const string typeGold = "gold";
        private const string typePlatinum = "platinum";


        #endregion


        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }


        public AccountHolder AccountHolder
        {
            get { return accountHolder; }
            set { accountHolder = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public int Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }



        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string TypeBasic
        {
            get { return typeBasic; }
        }

        public string TypeGold
        {
            get { return typeGold; }
        }

        public string TypePlatinum
        {
            get { return typePlatinum; }
        } 

        #endregion


    }
}
