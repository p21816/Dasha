﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class GoldAccount: Account
    {
        public GoldAccount() { }
        public GoldAccount(string accountNumber, AccountHolder accountHolder) :
            base(accountNumber, accountHolder) 
        {
            this.Type = "gold";
        }

    }
}
