using System;
using System.Linq;
using Task1.Solution;

namespace Task1
{
    public class PasswordCheckerService
    {
        public Tuple<bool, string> VerifyPassword(IRepository repository, IChecker [] checker, string password)
        {
            foreach(var item in checker)
            {
                if (item.isValid(password) == false)
                    return Tuple.Create(false, "Password is not valid");
            }
            repository.Create(password);
            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
