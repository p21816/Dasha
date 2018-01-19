using DAL.Interface;
using DAL.Interface.Repository;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContext context;
        public AccountRepository(DbContext uow)
        {
            this.context = uow;
        }

        List<DalAccount> accounts = new List<DalAccount>(); 

        public IEnumerable<DalAccount> GetAll()
        {
             return accounts;
        }

        public DalAccount GetById(int key)
        {
            try
            {
                foreach (var i in accounts)
                {
                    if (i.Id == key) return i;
                }
            }
            catch (IndexOutOfRangeException e)
            {

            }
            return null;
        }

        public DalAccount GetByPredicate(System.Linq.Expressions.Expression<Func<DalAccount, bool>> f)
        {
            throw new NotImplementedException();
        }

        //public void Create(DalAccount e)
        //{
        //    accounts.Add(e);
        //}

        public void Create(DalAccount e)
        {
            var account = new Account()
            {
                Id = e.Id,
                AccountNumber = e.AccountNumber,
                AccountHolderId = e.AccountHolder.Id,
                Type = e.Type,
                Balance = e.Balance,
                Bonus = e.Bonus
            };
            context.Set<Account>().Add(account);
        }

        public void Delete(DalAccount e)
        {
            accounts.Remove(e);
        }

        public void Update(DalAccount entity)
        {
            throw new NotImplementedException();
        }
    }
}
