using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class SimpleGenerateAccountNumberService: IGenerateAccountNumberService
    {
        /// <summary>
        /// generates a new number of account
        /// </summary>
        /// <returns>a new account number</returns>
        public string GenerateAccountNumber()
        {
            string result = DateTime.Now.GetHashCode().ToString();
            return result;
        }
    }
}
