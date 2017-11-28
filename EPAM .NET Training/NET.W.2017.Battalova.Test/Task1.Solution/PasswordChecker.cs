using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PasswordChecker: IChecker
    {
        public bool IsNotNull(string password)
        {
            if (password == null)
                return false;

            return true;
        }

        public bool IsValidLength(int Length)
        {
            // check if length more than 7 chars 
            if (Length <= 7 || Length >= 15)
            {
                return false;
            }
            return true;
        }

        public bool isNotEmpty(string password)
        {
            if (password == string.Empty)
            {
                return false;
            }
            return true;
        }

        bool IsLetter(string password)
        {
            // check if password conatins at least one alphabetical character 
            if (!password.Any(char.IsLetter))
            {
                return false;
            }
            return true;
        }

        public bool IsNumber(string password)
        {
            // check if password conatins at least one digit character 
            if (!password.Any(char.IsNumber))
                return false;

            return true;
        }

    }
}



