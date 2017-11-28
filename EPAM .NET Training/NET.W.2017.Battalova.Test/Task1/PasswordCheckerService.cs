using System;
using System.Linq;
using Task1.Solution;

namespace Task1
{
    public class PasswordCheckerService
    {
        public Tuple<bool, string> VerifyPassword(IRepository repository, IChecker checker, string password)
        {
            if (checker.IsNotNull(password) && 
                checker.IsValidLength(password.Length)
                && checker.isNotEmpty(password)
                && checker.IsLetter(password)
                && checker.IsNumber(password)
                )
         {
             repository.Create(password);
             return Tuple.Create(true, "Password is Ok. User was created");
         }
         return Tuple.Create(false, "Password is not valid");
        }
    }
}
