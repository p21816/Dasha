using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using BLL.ServiceImplementation;
using DAL.Fake;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IAccountService accountService = resolver.Get<IAccountService>();
            IAccountRepository accountRepository = resolver.Get<ListAccountRepository>();
            Account account = accountService.CreateNewAccount("Darya Battalova", 100, 1 , "basic");
            accountService.AddMoney(account, 200);
            accountService.WithdrawMoney(account, 150);
            accountRepository.Save(account);
            accountRepository.DeleteAccount(account);
        }
    }
}
