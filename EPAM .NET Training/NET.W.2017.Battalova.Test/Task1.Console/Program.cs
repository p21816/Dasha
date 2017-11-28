using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordCheckerService checker = new PasswordCheckerService();

            IChecker [] checkers = {new PasswordIsNullChecker() ,
                                       new PasswordIsEmptyChecker(),
                                       new PasswordLengthChecker() , new PasswordIsNumberChecker()};
            //valid password
            System.Console.WriteLine(checker.VerifyPassword(new SqlRepository(), checkers, "12345dsd12"));

            //not valid password
            System.Console.WriteLine(checker.VerifyPassword(new SqlRepository(), checkers, "1234"));
        }
    }
}
