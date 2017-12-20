using BLL.Interface;
using BLL.Interface.Entities;
using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class Mapper
    {
        internal static DalAccountHolder ToDalAccountHolder(this AccountHolder accountHolder)
        {
            DalAccountHolder dalAccountHolder = new DalAccountHolder();
            dalAccountHolder.Id = accountHolder.Id;
            dalAccountHolder.FirstName = accountHolder.FirstName;
            dalAccountHolder.LastName = accountHolder.LastName;
            return dalAccountHolder;
        }

        internal static AccountHolder ToBllAccountHolder(this DalAccountHolder dalAccountHolder)
        {
            AccountHolder accountHolder = new AccountHolder();
            accountHolder.Id = dalAccountHolder.Id;
            accountHolder.FirstName = dalAccountHolder.FirstName;
            accountHolder.LastName = dalAccountHolder.LastName;
            return accountHolder;
        }

        internal static DalAccount ToDalAccount(this Account account)
        {
            DalAccount dalAccount = new DalAccount();
            dalAccount.Id = account.Id;
            dalAccount.Type = account.Type;
            dalAccount.AccountNumber = account.AccountNumber;
            dalAccount.AccountHolder = account.AccountHolder.ToDalAccountHolder();
            dalAccount.Balance = account.Balance;
            dalAccount.Bonus = account.Bonus;
            return dalAccount;
        }

        internal static Account ToBLLAccount(this DalAccount dalAccount)
        {
            Account account = ResolveDalAccountType(dalAccount);
            account.Id = dalAccount.Id;
            account.AccountNumber = dalAccount.AccountNumber;
            account.AccountHolder = dalAccount.AccountHolder.ToBllAccountHolder();
            account.Balance = dalAccount.Balance;
            account.Bonus = dalAccount.Bonus;
            return account;
        }

        internal static Account ResolveDalAccountType(DalAccount account)
        {
            if (account.Type == "base")
            {
                return new BaseAccount();
            }
            if (account.Type == "gold")
            {
                return new GoldAccount();
            }
            return null;
        }
    }
}
