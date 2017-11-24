using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class AccountTypeResolver
    {
        private BasicAccountBonusCalculationService basic;
        private GoldAccountBonusCalculationService gold;
        private PlatinumAccountBonusCalculationService platinum;

        public AccountTypeResolver(
            BasicAccountBonusCalculationService basic,
            GoldAccountBonusCalculationService gold,
            PlatinumAccountBonusCalculationService platinum
        )
        {
            this.basic = basic;
            this.gold = gold;
            this.platinum = platinum;
        }

        /// <summary>
        /// defines which type of account it is
        /// </summary>
        /// <param name="account">account to be defined</param>
        /// <returns>a type of account</returns>
        public IBonusCalculator GetBonuCalculator(Account account)
        {
            switch(account.Type)
            {
                case "basic":
                    {
                        return basic;
                    }
                case "gold":
                    {
                        return gold;
                    }
                case "platinum":
                    {
                        return platinum;
                    }
                default:
                    throw new InvalidOperationException();
            }

        }
    }
}
