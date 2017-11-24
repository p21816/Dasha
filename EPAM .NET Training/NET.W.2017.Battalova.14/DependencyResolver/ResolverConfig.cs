using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IGenerateAccountNumberService>().To<SimpleGenerateAccountNumberService>();
            kernel.Bind<IAccountRepository>().To<ListAccountRepository>();
            kernel.Bind<BasicAccountBonusCalculationService>().To<BasicAccountBonusCalculationService>();
            kernel.Bind<GoldAccountBonusCalculationService>().To<GoldAccountBonusCalculationService>();
            kernel.Bind<PlatinumAccountBonusCalculationService>().To<PlatinumAccountBonusCalculationService>();
            kernel.Bind<AccountTypeResolver>().To<AccountTypeResolver>();
        }
    }
}
