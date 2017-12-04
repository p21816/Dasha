using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Fake.Repositories
{
    public class ListAccountRepository: IAccountRepository
    {
        private List<AccountDTO> storage = new List<AccountDTO>();
        public AccountDTO GetAccount(string accountNumber)
        {
            if (accountNumber == null) throw new ArgumentNullException();
            foreach(var i in storage )
            {
                if (i.AccountNumber == accountNumber) return i;
            }
            return null;
        }

        public void SaveAccount(AccountDTO account)
        {
            if (account == null) throw new ArgumentNullException();

            storage.RemoveAll(dalAccount => dalAccount.AccountNumber == account.AccountNumber);
            storage.Add(account);
        }

        public void AddAccount(AccountDTO account)
        {
            if (account == null) throw new ArgumentNullException();
            if (storage.Contains(account)) throw new ArgumentException();
            storage.Add(account);
        }

        public void RemoveAccount(AccountDTO account)
        {
            if (account == null) throw new ArgumentNullException();
            if (!storage.Contains(account)) throw new ArgumentException();
            storage.Remove(account);

        }

        public IEnumerable<AccountDTO> GetAllAccounts()
        {
           return new List<AccountDTO>(storage);
        }
    }
}
