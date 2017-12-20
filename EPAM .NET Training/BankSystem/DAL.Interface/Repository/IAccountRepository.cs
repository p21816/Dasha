using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    public interface IAccountRepository : IRepository<DalAccount>//Add account repository methods!
    {
        //void AddAccount(DalAccount account);
        //DalAccount GetAccount(string id);
        //void UpdateAccount(DalAccount account);
        //void RemoveAccount(DalAccount account);
        //IEnumerable<DalAccount> GetAccounts();
    }
}
