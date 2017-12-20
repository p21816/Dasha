using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IAccountService
    {
        Account GetAccount(int id);
        IEnumerable<Account> GetAllAccounts();
        void CreateAccount(Account account);
        void DeleteAccount(Account account);

        //etc.
    }
}
