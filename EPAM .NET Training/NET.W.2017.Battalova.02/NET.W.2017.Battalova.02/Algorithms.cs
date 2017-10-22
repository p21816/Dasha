using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._02
{
    public static class Algorithms
    {
        #region IntegerInsertion
        public static int IntegerInsertion(int firstNumber, int secondNumber, int start, int end)
        {
            const int maxBinIndex = 32;
            const int maxInt = int.MaxValue;

            if (start > end || start < 0 || end > maxBinIndex)
                throw new ArgumentOutOfRangeException();

            int mask1 = ((maxInt >> (maxBinIndex - end - 1)) ^ -1) | (maxInt >> (maxBinIndex - start));
            int mask2 = -1 ^ mask1;

            return (firstNumber & mask1) | (secondNumber & mask2);
        }

        public static string ToBin(int value)
        {
            return BinaryRepresentation(value, 32);
        }

        static string BinaryRepresentation(int value, int len)
        {
            return (len > 1 ? BinaryRepresentation(value >> 1, len - 1) : null) + "01"[value & 1];
        }
#endregion



#region NextBiggerNumber
        static DateTime OperationBeginning()
        {
            DateTime operationBeginning = DateTime.Now;
            return operationBeginning;
        }
        static DateTime OperationEnding()
        {
            DateTime operationEnding = DateTime.Now;
            return operationEnding;
        }
        static TimeSpan OperationTotalTime(DateTime start, DateTime end)
        {
            return end - start;
        }


        public static int NextBiggerNumber(int number)
        {
            DateTime start = OperationBeginning();
            if (number < 0) throw new ArgumentException("Number is negative!");

            List<int> digs = new List<int>();
            while (number > 0)
            {
                digs.Add(number % 10);
                number = number / 10;
            }
            digs.Reverse();
            int[] digits = digs.ToArray<int>();

            for (int i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    int temp = digits[i];
                    digits[i] = digits[i - 1];
                    digits[i - 1] = temp;

                    Array.Sort(digits, i, digits.Length - (i));
                    string result = "";

                    foreach (int j in digits)
                    {
                        result += j;
                    }

                    int res = Convert.ToInt32(result);
                    DateTime end = OperationEnding();
                    OperationTotalTime(start, end);
                    return res;
                }
            }
            return -1;
        }

#endregion


        public static int[] FilterDigit(int[] digits, int number)
        {
            int temp;
            int tempNumber;
            List<int> digs = new List<int>();
            for (int i = 0; i < digits.Length; i++)
            {
                tempNumber = digits[i];
                while (digits[i] > 0)
                {
                    temp = digits[i] % 10;
                    digits[i] = digits[i] / 10;
                    if (temp == 7)
                    {
                        digs.Add(tempNumber);
                        break;
                    }
                }
            }
            int[] result = digs.ToArray<int>();
            return result;
        }


       public static double Sqrt(double number, int n, double precision)
        {
            int fractionalPart = precision.ToString().Length - precision.ToString().IndexOf(',') - 1;
            var previous = number / n;
            var next = (1.0 / n) * ((n - 1) * previous + number / Math.Pow(previous, n - 1));

            while (Math.Abs(next - previous) > precision)
            {
                previous = next;
                next = (1.0 / n) * ((n - 1) * previous + number / Math.Pow(previous, n - 1));
            }

            return Math.Round(next, fractionalPart);
        }

    }
}
