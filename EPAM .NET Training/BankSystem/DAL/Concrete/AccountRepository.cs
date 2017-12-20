using DAL.Interface;
using DAL.Interface.Repository;
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
        //public AccountRepository(DbContext uow)
        //{
        //    this.context = uow;
        //}

        List<DalAccount> accounts = new List<DalAccount>();

        public IEnumerable<DalAccount> GetAll()
        {
             return accounts;
        }

        public DalAccount GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalAccount GetByPredicate(System.Linq.Expressions.Expression<Func<DalAccount, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalAccount e)
        {
            accounts.Add(e);
        }

        public void Delete(DalAccount e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalAccount entity)
        {
            throw new NotImplementedException();
        }
    }
}
