using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class AccountService: IAccountService
    {
        private IGenerateAccountNumberService accountNumberGenerator;
        private AccountTypeResolver resolver;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="accountNumberGenerator">generator of new number of account</param>
        /// <param name="resolver">resolves which type of account is it</param>
        public AccountService(
            IGenerateAccountNumberService accountNumberGenerator,
            AccountTypeResolver resolver
        )
        {
            this.accountNumberGenerator = accountNumberGenerator;
            this.resolver = resolver;
        }

        /// <summary>
        /// creates new account
        /// </summary>
        /// <param name="HolderName">person to whom account belongs</param>
        /// <param name="balance">sum of money on account</param>
        /// <param name="bonus">bonus of account</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Account CreateNewAccount(string HolderName, decimal balance, int bonus, string type)
        {
            Account account = new Account();
            account.AccountNumber = accountNumberGenerator.GenerateAccountNumber();
            AccountHolder holder = new AccountHolder();
            account.AccountHolder = holder;

            holder.FirstName = HolderName;
            account.Balance = balance;
            account.Bonus = bonus;
            account.Type = type;

            return account;
        }

        /// <summary>
        /// adds money
        /// </summary>
        /// <param name="account">account to whoct we add</param>
        /// <param name="money">sum of money to add</param>
        public void AddMoney(Account account, decimal money)
        {
            account.Balance += money;
            IBonusCalculator calculator = resolver.GetBonuCalculator(account);
            int bonus = calculator.CalculateBinusOnAdd(money);
            account.Bonus += bonus;
        }

        /// <summary>
        /// withdraws money 
        /// </summary>
        /// <param name="account">account from which we withdraw money</param>
        /// <param name="money">a sum of money to withdraw</param>
        public void WithdrawMoney(Account account, decimal money)
        {
            account.Balance -= money;
            IBonusCalculator calculator = resolver.GetBonuCalculator(account);
            int bonus = calculator.CalculateBinusOnWithdraw(money);
            account.Bonus -= bonus;
        }


    }
}
