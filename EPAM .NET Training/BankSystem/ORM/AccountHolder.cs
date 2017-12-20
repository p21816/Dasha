﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class AccountHolder
    {
        public AccountHolder()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
