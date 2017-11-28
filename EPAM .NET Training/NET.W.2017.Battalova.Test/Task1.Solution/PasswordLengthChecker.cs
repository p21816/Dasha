using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PasswordLengthChecker: IChecker
    {
        public bool isValid(string password)
        {
            // check if password conatins at least one alphabetical character 
            if (!password.Any(char.IsLetter))
            {
                return false;
            }
            return true;
        }
    }
}
