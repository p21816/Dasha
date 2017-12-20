using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public class DalAccount: IEntity
    {
        #region Fields
        private string type;

        private int id;
        private string accountNumber;
        private DalAccountHolder accountHolder;
        private decimal balance;
        private int bonus;

        #endregion

        #region Properties
        public string Type
        {
            get { return type; }
            set { type = value; }
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

        public DalAccountHolder AccountHolder
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
    }
}
