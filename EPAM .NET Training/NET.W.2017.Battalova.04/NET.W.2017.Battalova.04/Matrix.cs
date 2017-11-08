using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._04
{
    public static class Matrix
    {
        public static void Sort(int[][] jaggedArray, IComparer comparer)
        {
            int comparerResult = 0;

            for (int i = 1; i <= jaggedArray.Length; i++)
            {
                for (int j = jaggedArray.Length - 1; j > i; j--)
                {
                    comparerResult = comparer.CompareTo(jaggedArray[j], jaggedArray[j - 1]);
                    if (comparerResult < 0) 
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }

        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }


 

}
