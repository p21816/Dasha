using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._03
{
    public static class DoubleExtention
    {
        public static string DoubleToBin(this double number)
        {
            int integerPart = (int)Math.Truncate(number);
            string intPart = ShortenBin(integerPart);
            int exp = intPart.Length - 1;
            double fractionalPart = number - integerPart;
            string mantisa = mantisaToBin(fractionalPart);

            //64 bites:
            exp = exp + 1023;
            string binExp = ShortenBin(exp);
            string result;
            if (number > 0)
            {
                result = "0" + binExp + mantisa;
            }
            else
            {
                result = "1" + binExp + mantisa;
            }
            return result; ;
        }
        #region PrivateMethods
        private static string mantisaToBin(double fractPart)
        {
            double temp = fractPart * 2;
            string mant = "";
            for (int i = 0; i < 23; i++)
            {
                mant += Math.Truncate(temp);
                if (Math.Truncate(temp) == 1)
                {
                    temp = temp - Math.Truncate(temp);
                }
                temp = temp * 2;
            }
            return mant;
        }
        private static string ShortenBin(int value)
        {
            string str = (string)ToBin(value);
            char[] arr = str.ToCharArray();
            int i = 0;
            while (arr[i] == '0')
            {
                i++;
            }
            string intPart = "";
            for (int j = i; j < arr.Length; j++)
            {
                intPart += arr[j];
            }
            return intPart;
        }
        private static string ToBin(int value)
        {
            return ToBinRec(value, 32);
        }
        private static string ToBinRec(int value, int len)
        {
            return (len > 1 ? ToBinRec(value >> 1, len - 1) : null) + "01"[value & 1];
        }
        #endregion
    }
}
