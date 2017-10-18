using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    public class Model
    {
       public List<BankAccount> accounts = new List<BankAccount>();


       public void addAccount(int num, int n, int s)
        {
            accounts.Add(new BankAccount(num,  n , s));
        }

       public void removeAccount(int index)
        {
            accounts.RemoveAt(index);
        }

        public void makeTransaction(int from , int to , int sumOfTransaction)
       {
           accounts[from - 1].sum = accounts[from - 1].sum - sumOfTransaction;
             accounts[to - 1].sum = accounts[to - 1].sum + sumOfTransaction;
       }


    }
}
