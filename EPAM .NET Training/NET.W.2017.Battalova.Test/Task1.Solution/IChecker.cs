using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public interface IChecker
    {
        bool isNotEmpty(string password);
        bool IsNotNull(string password);
        bool IsValidLength(int Length);
        bool IsLetter(string password);
        bool IsNumber(string password);
    }
}
