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

        #region Euclidean Algorithm

        /// <summary>
        /// counts the greatest common divisor of two numbers using Euclidean Algorithm
        /// </summary>
        /// <param name="lhs">first number</param>
        /// <param name="rhs">second number</param>
        /// <returns>the greatest common divisor of two numbers</returns>
        public static int GCDbyEuclid(int lhs, int rhs)
        {
            return GetGCD(lhs, rhs, EuclideanAlgorithm);
        }


        /// <summary>
        /// counts the greatest common divisor of any numbers of numbers using Euclidean algorithm
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="c">third number</param>
        /// <returns>great common divisor of any number of numbers</returns>
        public static int GCDbyEuclid(params int [] array)
        {
            return GetGCD(EuclideanAlgorithm, array);
        }

        /// <summary>
        /// counts the greatest common divisor and returns as well elapsedTime for the operation
        /// </summary>
        /// <param name="elapsedTime">out parameter that returns time that took an operation</param>
        /// <param name="array">array of params for counting great common divisor</param>
        /// <returns>
        /// the greatest common divisor of numbers in an array,
        /// time as out parameter that took the operation to count the greatest common divisor
        /// </returns>
        public static int GCDbyEuclid(out string elepsedTime, params int[] array)
        {
            return GetGCD(EuclideanAlgorithm, out elepsedTime, array);
        }

#region private methods

        /// <summary>
        /// counts the greatest common divisor of two numbers using Euclid algorithm
        /// </summary>
        /// <param name="lhs">first number</param>
        /// <param name="rhs">second number</param>
        /// <returns>the greatest common divisor of two numbers</returns>
        private static int EuclideanAlgorithm(int lhs, int rhs)
        {
            lhs = Math.Abs(lhs);
            rhs = Math.Abs(rhs);
            while (lhs != 0 && rhs != 0)
            {
                if (lhs > rhs) lhs = lhs % rhs;
                else rhs = rhs % lhs;
            }
            return lhs + rhs;
        }

        private static int GetGCD(int lhs, int rhs, Func<int, int, int> gcdByEulcid)
        {
            return(gcdByEulcid(lhs,rhs));
        }
        private static int GetGCD(Func<int, int, int> gcdByEulcid , params int [] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            int result = 0;
            foreach (int element in array)
            {
                result = GetGCD(result, element, gcdByEulcid);
            }
            return result;
        }
        private static int GetGCD(Func<int, int, int> gcdByEulcid, out string elapsedTime, params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int gcd = GCD.GCDbyEuclid(array);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            elapsedTime = ts.Ticks.ToString();
            return gcd;

        }

#endregion


        #endregion


        //#region Stein Algorithm

        ///// <summary>
        ///// counts a great common divisor of two numbers using Stein algorithm
        ///// </summary>
        ///// <param name="lhs">first number</param>
        ///// <param name="rhs">second number</param>
        ///// <returns>great common divisor of two numbers</returns>
        //public static int GCDbyStein(int lhs, int rhs)
        //{
        //    if (lhs == 0 || rhs == 0) return lhs + rhs;
        //    if (lhs % 2 == 0)
        //        return (rhs % 2 == 0)
        //            ? GCDbyStein(lhs >> 1, rhs >> 1) << 1
        //            : GCDbyStein(lhs >> 1, rhs);
        //    else
        //        return (rhs % 2 == 0)
        //            ? GCDbyStein(lhs, rhs >> 1)
        //            : GCDbyStein(rhs, lhs > rhs ? lhs - rhs : rhs - lhs);
        //}


        //public static int GCDbyStein(int a, int b, int c)
        //{
        //    return GCDbyStein(GCDbyStein(a, b), c);
        //}

        //public static int GCDbyStein(int a, int b, int c, int d)
        //{
        //    return GCDbyStein(GCDbyStein(GCDbyStein(a, b), c), d);
        //}

        //public static int GCDbyStein(params int[] array)
        //{
        //    int gcd = 0;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        gcd = GCDbyStein(gcd, array[i]);
        //    }
        //    return gcd;
        //}


        //public static int GCDbyStein(out string elapsedTime, params int[] array)
        //{
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();
        //    int gcd = GCD.GCDbyStein(array);
        //    stopWatch.Stop();
        //    TimeSpan ts = stopWatch.Elapsed;
        //    elapsedTime = ts.Ticks.ToString();
        //    return gcd;
        //}

        //#endregion
    }
}
