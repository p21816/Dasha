using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class GoldAccount: Account
    {
        public GoldAccount() { }
        public GoldAccount(int id, string accountNumber, AccountHolder accountHolder) :
            base(id, accountNumber, accountHolder) 
        {
            this.Type = "gold";
        }

    }
}
