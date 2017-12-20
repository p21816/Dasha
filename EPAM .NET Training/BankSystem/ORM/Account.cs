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

        [Required]
        public string AccountNumber { get; set; }
        public int AccountHolderId { get; set; }
        private string Type { get; set; }
        private decimal Balance { get; set; }
        private int Bonus { get; set; }
        public virtual AccountHolder accountHolder { get; set; }
    }
}
