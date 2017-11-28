using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PasswordIsEmptyChecker: IChecker
    {
        public bool isValid(string password)
        {
            if (password == string.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
