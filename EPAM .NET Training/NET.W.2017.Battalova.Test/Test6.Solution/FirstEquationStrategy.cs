using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class FirstEquationStrategy : IGenerateStrategy<int>
    {
        public int GenerateElement(List<int> sequence, int position)
        {
            if (sequence == null) throw new ArgumentNullException();
            return sequence[position] + sequence[position - 1];
        }
    }
}
