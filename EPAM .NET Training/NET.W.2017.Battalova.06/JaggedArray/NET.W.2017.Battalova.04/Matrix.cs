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
        /// sorts jagged array
        /// </summary>
        /// <param name="array">array to be sorted</param>
        /// <param name="comparer">criteria for sorting the array</param>
        public static void Sort(int[][] array, IComparer comparer)
        {
            BubbleSort(array, comparer.CompareTo);
        }


        #region private methods

        /// <summary>
        /// sorts jagged array
        /// </summary>
        /// <param name="jaggedArray">array to be sorted</param>
        /// <param name="compare">delegate according to which array is sorted</param>
        private static void BubbleSort(int[][] jaggedArray, Func<int[], int[], int> compare)
        {
            int comparerResult = 0;
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    comparerResult = compare(jaggedArray[j], jaggedArray[j + 1]);
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



        //old realization with IComparer

        //public static void Sort(int[][] jaggedArray, IComparer comparer)
        //{
        //    int comparerResult = 0;
        //    for (int i = 0; i < jaggedArray.Length; i++)
        //    {
        //        for (int j = 0; j < jaggedArray.Length - i - 1; j++)
        //        {
        //            comparerResult = comparer.CompareTo(jaggedArray[j], jaggedArray[j + 1]);
        //            if (comparerResult > 0) Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
        //        }
        //    }
        //}

        #endregion

    }


 

}
