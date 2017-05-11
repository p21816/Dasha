using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    public class BankAccount
    {
        public int num;
        public int accountNumber;
        public int sum;


        public BankAccount(int num, int n, int s)
        {
            this.num = num;
            this.accountNumber = n;
            this.sum = s;
        }

        public override string ToString()
        {
            return "№ " + num + " " + accountNumber + "  " + sum + "$";
        }

    }
}
