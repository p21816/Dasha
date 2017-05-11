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




    }
}
