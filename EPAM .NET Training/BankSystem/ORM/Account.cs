using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ORM
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int AccountHolderId { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }
        public int Bonus { get; set; }
    }
}
