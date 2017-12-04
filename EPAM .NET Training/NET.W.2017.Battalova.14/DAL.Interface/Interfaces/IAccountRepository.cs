using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IAccountRepository
    {
        AccountDTO GetAccount(string accountNumber);
        void SaveAccount(AccountDTO account);
        void AddAccount(AccountDTO account);
        void RemoveAccount(AccountDTO account);
        IEnumerable<AccountDTO> GetAllAccounts();
    }
}
