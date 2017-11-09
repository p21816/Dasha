using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._04
{
    public static class Matrix
    {
        /// <summary>
        /// sorts jagged array according to IComparer
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <param name="comparer">IComparer element</param>
        public static void Sort(int[][] jaggedArray, IComparer comparer)
        {
            int comparerResult = 0;
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    comparerResult = comparer.CompareTo(jaggedArray[j], jaggedArray[j + 1]);
                    if (comparerResult > 0) Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }


        /// <summary>
        /// swaps two strings of a jagged array
        /// </summary>
        /// <param name="lhs">first string of a jagged array</param>
        /// <param name="rhs">second string of a jagged array</param>
        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }


 

}
