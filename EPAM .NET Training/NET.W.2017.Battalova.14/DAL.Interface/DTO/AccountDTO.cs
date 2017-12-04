using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class AccountDTO
    {
        #region Properties

        public string AccountNumber { get; set; }

        /// <summary>
        /// Account holder's first name
        /// </summary>

        /// <summary>
        /// A type of a bank account.
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// A number of a bank account.
        /// </summary>

        public string AccountHolderFirstName { get; set; }

        /// <summary>
        /// Account holder's last name.
        /// </summary>
        public string AccountHolderLastName { get; set; }

        /// <summary>
        /// Balance of the account.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Bonus of the account.
        /// </summary>
        public int Bonus { get; set; }

        #endregion  
    }
}
