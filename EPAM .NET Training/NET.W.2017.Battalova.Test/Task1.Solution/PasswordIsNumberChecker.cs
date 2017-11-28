using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PasswordIsNumberChecker: IChecker
    {
        public bool isValid(string password)
        {
            // check if password conatins at least one digit character 
            if (!password.Any(char.IsNumber))
                return false;

            return true;
        }
    }
}
