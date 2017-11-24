using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace DAL.Fake
{
    public class ListAccountRepository : IAccountRepository
    {
        List<Account> storage = new List<Account>();

        /// <summary>
        /// deletes account from a repository
        /// </summary>
        /// <param name="account">account to delete</param>
        public void DeleteAccount(Account account)
        {
            if(!(storage.Contains(account)))
            {
                throw new ArgumentException();
            }
            storage.Remove(account);
        }

        /// <summary>
        /// finds account in a repository by id
        /// </summary>
        /// <param name="id">id of an account to find</param>
        /// <returns>found account</returns>
        public Account FindById(int id)
        {
            try
            {
                return storage.ElementAt(id);
            }
            catch(ArgumentOutOfRangeException e)
            {
                return null;
            }
        }


        /// <summary>
        /// saves account
        /// </summary>
        /// <param name="account">account to save to repository</param>
        public void Save(Account account)
        {
            storage.Add(account);
            int id = storage.IndexOf(account);
            account.Id = id;
        }
    }
}
