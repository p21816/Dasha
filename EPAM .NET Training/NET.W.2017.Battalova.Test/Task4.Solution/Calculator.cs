using System;
using System.Collections.Generic;
using System.Linq;
using Task4.Solution;

namespace Task4
{
    public class Calculator
    {
        public double CalculateAverage(List<double> values, ICalculate calculator)
        {
            if (values == null)
            {
                throw  new ArgumentNullException();
            }
            return calculator.Calculate(values);
        }

        public double CalculateAverage(List<double> values, Func<List<double>, double> calculate)
        {
            if (values == null)
            {
                throw new ArgumentNullException();
            }
            return calculate(values);
        }
    }
}
