using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class SequenceGenerator<T>
    {
        List<T> sequence;
        int count;
        int offset;
        IGenerateStrategy<T> strategy;
        public SequenceGenerator(List<T> initialSequence, int count, int offset, IGenerateStrategy<T> strategy)
        {
            sequence = new List<T>();
            FillList(sequence , initialSequence);
            this.count = count;
            this.offset = offset;
            this.strategy = strategy;
        }
        public List<T> Generate()
        {

        }

        private T GenerateNextElement()
        {
            for(int i = offset; i <= count; i++)
            {
                yield return strategy.GenerateElement(sequence, i);
            }
            return nu
        }

        private void FillList(List<T> sequence ,List<T> initialSequence )
        {
            int i = 0;
            foreach (var element in initialSequence)
            {
                sequence[i] = element;
                i++;
            }
        }
    }
}
