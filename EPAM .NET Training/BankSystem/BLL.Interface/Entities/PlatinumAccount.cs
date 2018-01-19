using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class PlatinumAccount: Account
    {
        public PlatinumAccount() { }
        public PlatinumAccount(int id, string accountNumber, AccountHolder accountHolder) :
            base(id, accountNumber, accountHolder) 
        {
            this.Type = "platinum";
        }
    }
}
