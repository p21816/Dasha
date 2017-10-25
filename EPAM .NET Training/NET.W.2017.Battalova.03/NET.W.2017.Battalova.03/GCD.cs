using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._03
{
    public static class GCD
    {
        /// <summary>
        /// gets gcd of any number of digits and get elapsed time for the operation
        /// </summary>
        /// <param name="gcd"></param>
        /// <param name="elapsedTime"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="array"></param>
        public static void GetGCD_ElapsedTime(out int gcd, out string elapsedTime, int a, int b, params int[] array)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            gcd = GCD.GetGCD(a, b, array);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            elapsedTime = ts.Ticks.ToString();
        }

        /// <summary>
        /// get gdc of two numbers using Euclid algorithm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>int gcd</returns>
        public static int GetGCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b) a = a % b;
                else b = b % a;
            }
            return a + b;
        }

        /// <summary>
        /// gets of three numbers using Euclid algorithm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>int gcd</returns>
        public static int GetGCD(int a, int b, int c)
        {
            return GetGCD(GetGCD(a, b), c);
        }

        /// <summary>
        /// of four numbers using Euclid algorithm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns>int gcd</returns>
        public static int GetGCD(int a, int b, int c, int d)
        {
            return GetGCD(GetGCD(GetGCD(a, b), c), d);
        }

        /// <summary>
        /// of any number of digits using Euclid algorithm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="array"></param>
        /// <returns>int gcd</returns>
        public static int GetGCD(int a, int b, params int[] array)
        {
            int GCD = GetGCD(a, b);
            for (int i = 0; i < array.Length; i++)
            {
                GetGCD(GCD, array[i]);
            }
            return GCD;
        }


        /// <summary>
        /// gets gcd of two numbers using Stein algorithm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>int gcd</returns>
        public static int GCDbyStein(int a, int b)
        {
            if (a == 0 || b == 0) return a + b;
            if (a % 2 == 0)
                return (b % 2 == 0)
                    ? GCDbyStein(a >> 1, b >> 1) << 1
                    : GCDbyStein(a >> 1, b);
            else
                return (b % 2 == 0)
                    ? GCDbyStein(a, b >> 1)
                    : GCDbyStein(b, a > b ? a - b : b - a);
        }
    }
}
