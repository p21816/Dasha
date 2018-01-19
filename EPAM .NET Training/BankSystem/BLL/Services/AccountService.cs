using BLL.Interface;
using BLL.Interface.Services;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using DAL.Interface;

namespace BLL
{
    public class AccountService : IAccountService
    {


        private readonly IAccountRepository accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            if (ReferenceEquals(accountRepository, null))
            {
                throw new ArgumentNullException();
            }

            this.accountRepository = accountRepository;
        }

        public Account GetAccountById(int id)
        {
            return accountRepository.GetById(id).ToBLLAccount();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            List<Account> accs = new List<Account>();
            IEnumerable<DalAccount> accounts = accountRepository.GetAll();
            foreach(var i in accounts)
            {
                accs.Add(i.ToBLLAccount());
            }
            return accs;
        }

        public void CreateAccount(Account account)
        {
            accountRepository.Create(account.ToDalAccount());
        }

        public void DeleteAccount(Account account)
        {
            accountRepository.Delete(account.ToDalAccount());
        }
    }
}
