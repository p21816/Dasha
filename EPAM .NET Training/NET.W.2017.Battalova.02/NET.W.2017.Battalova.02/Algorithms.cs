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

        /// <summary>
        /// inserts bits of one number to bits of another number from inde start to index end
        /// </summary>
        /// <param name="firstNumber">number from which we insert</param>
        /// <param name="secondNumber">number to which we insert</param>
        /// <param name="start">the bit we at which we start insertion</param>
        /// <param name="end">the bit at which we end insertion</param>
        /// <returns>a new number with the bits of first number inserted to the second number</returns>
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

        private static string ToBin(int value)
        {
            return BinaryRepresentation(value, 32);
        }

        private static string BinaryRepresentation(int value, int len)
        {
            return (len > 1 ? BinaryRepresentation(value >> 1, len - 1) : null) + "01"[value & 1];
        }
#endregion



#region NextBiggerNumber

        /// <summary>
        /// finds the next bigger number consisting of the same digits
        /// </summary>
        /// <param name="number">number from which to search tne next bigger number</param>
        /// <returns>the next bigger number</returns>
        public static int FindNextBiggerNumber(int number)
        {
            int[] digits = MakeArrayFromNumber(number);
            int indexOfFirstElementToSwap = IndexOfFirstElementToSwap(digits);
            int indexOfSecondElementToSwap = IndexOfSecondElementToSwap(digits);
            if (indexOfFirstElementToSwap == indexOfSecondElementToSwap) return -1;
            Swap(ref digits, indexOfFirstElementToSwap, indexOfSecondElementToSwap);
            int result = MakeNumberFromArray(digits);
            return result;
        }

        #region private methods for FindNextBiggerNumber

        private static int[] MakeArrayFromNumber(int number)
        {
            int[] digits = new int[number.ToString().Length];
            int i = 0;
            while (number > 0)
            {
                digits[i] = number % 10;
                number = number / 10;
                i++;
            }
            return digits;
        }

        private static int IndexOfFirstElementToSwap(int[] digits)
        {
            int temp = 0;
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i + 1] < digits[i])
                {
                    temp = i + 1;
                    break;
                }
            }
            return temp;
        }


        private static int IndexOfSecondElementToSwap(int[] digits)
        {
            int indexOfElementToChange = IndexOfFirstElementToSwap(digits);
            int temp = 0;
            for (int i = 0; i < digits[indexOfElementToChange]; i++)
            {
                if (digits[i] > digits[indexOfElementToChange])
                {
                    temp = i;
                    break;
                }
            }
            return temp;
        }

        private static void Swap(ref int[] digits, int indexOfFirstElementToSwap, int indexOfSecondElementToSwap)
        {
            int temp = digits[indexOfFirstElementToSwap];
            digits[indexOfFirstElementToSwap] = digits[indexOfSecondElementToSwap];
            digits[indexOfSecondElementToSwap] = temp;
        }

        private static int MakeNumberFromArray(int[] digits)
        {
            Array.Reverse(digits);
            string result = "";
            for (int i = 0; i < digits.Length; i++)
            {
                result += digits[i].ToString();
            }
            int res = Convert.ToInt32(result);
            return res;
        }

#endregion

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
                    if (temp == number)
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
