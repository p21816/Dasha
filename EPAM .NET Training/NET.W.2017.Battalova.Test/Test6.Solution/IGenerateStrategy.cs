using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public interface IGenerateStrategy<T>
    {
        T GenerateElement(List<T> sequence, int position);
    }
}
