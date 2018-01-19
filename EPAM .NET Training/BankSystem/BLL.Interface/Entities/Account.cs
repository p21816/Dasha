using BLL.Interface.Entities;
using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public abstract class Account
    {

#region Fields
        private int id;
        private string accountNumber;
        private AccountHolder accountHolder;
        private decimal balance;
        private int bonus;
        private string type;

#endregion

#region Properties

        public string Type
        {
            get { return type; }
            protected set { type = value; }

        }
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

#endregion

        protected Account() { }
        protected Account(int id, string accountNumber, AccountHolder accountHolder)
        {
            this.Id = id;
            this.accountNumber = accountNumber;
            this.accountHolder = accountHolder;
            this.balance = 0;
            this.bonus = 0;
        }

        public override string ToString()
        {
            return accountNumber + " " + AccountHolder.ToString();
        }

    }


}
