using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PasswordChecker: IChecker
    {
        public bool IsValid(string password)
        {
            if (password == null)
                return false;
            if (password == string.Empty)
                return false;

            // check if length more than 7 chars 
            if (password.Length <= 7)
                return false;

            // check if length more than 10 chars for admins
            if (password.Length >= 15)
                return false;

            // check if password conatins at least one alphabetical character 
            if (!password.Any(char.IsLetter))
                return false;

            // check if password conatins at least one digit character 
            if (!password.Any(char.IsNumber))
                return false;

            return true;
        }
    }
}



