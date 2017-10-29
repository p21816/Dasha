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
        /// check if the argument is null
        /// </summary>
        /// <param name="jaggedArray"></param>
        private static void CheckNull(int[][] jaggedArray) 
        {
            foreach(int[] i in jaggedArray)
            {
                if (i.Length == 0) throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// reverses matrix
        /// </summary>
        /// <param name="jaggedArray"></param>
        private static void Reverse(int[][] jaggedArray)
        {
            int i;
            int[] tmp;
            int hLenght = jaggedArray.Length >> 1;
            for (i = 0; i < hLenght; ++i)
            {
              tmp = jaggedArray[i];
              jaggedArray[i] = jaggedArray[jaggedArray.Length - i - 1];
              jaggedArray[jaggedArray.Length - i - 1] = tmp;
            }
        }

        /// <summary>
        /// sorts the array according to the sum of the elements in a string
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <returns>int[][]</returns>
        public static int[][] IncrementSum(int[][] jaggedArray) 
        {
            CheckNull(jaggedArray);
            for (int i = jaggedArray.Length - 1; i > 0; i--) 
            {
                for (int j = 0; j < i; j++)
                {
                    int sumFirst = 0;
                    int sumSecond = 0;
                    foreach (int integer in jaggedArray[j]) 
                    {
                        sumFirst += integer;
                    }
                    foreach (int integer in jaggedArray[j+1])
                    {
                        sumSecond += integer;
                    }
                    if (sumFirst > sumSecond)
                    {
                        int[] t = jaggedArray[j];
                        jaggedArray[j] = jaggedArray[j + 1];
                        jaggedArray[j + 1] = t;
                    }
                }
          }
            return jaggedArray;
       }


        /// <summary>
        ///sorts the array according to the decreasing of sum of the elements in a string
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <returns>int[][]</returns>
        public static int[][] DecrementSum(int[][] jaggedArray)
        {
            IncrementSum(jaggedArray);
            Reverse(jaggedArray);
            return jaggedArray;
        }


        /// <summary>
        /// sorts the array according to the incrementation of the maximum element in a string
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <returns>int[][]</returns>
        public static int[][] IncrementMaxElement(int[][] jaggedArray)
        {
            CheckNull(jaggedArray);
            for (int i = jaggedArray.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    int maxFirst = 0;
                    int maxSecond = 0;
                    foreach (int integer in jaggedArray[j]) 
                    {
                        if (integer > maxFirst) maxFirst = integer;
                    }
                    foreach (int integer in jaggedArray[j+1])
                    {
                        if (integer > maxSecond) maxSecond = integer;
                    }
                    if (maxFirst > maxSecond)
                    {
                        int[] t = jaggedArray[j];
                        jaggedArray[j] = jaggedArray[j + 1];
                        jaggedArray[j + 1] = t;
                    }
                }
            }
            return jaggedArray;
         }


        /// <summary>
        /// sorts the array according to the decreasing of minimum element in a string
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <returns>int[][]</returns>
        public static int[][] DecrementMaxElement(int[][] jaggedArray)
        {
            IncrementMaxElement(jaggedArray);
            Reverse(jaggedArray);
            return jaggedArray;
        }


        /// <summary>
        /// sorts the array according to the increasing of minimum element in a string
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <returns>int[][]</returns>
        public static int[][] IncrementMinElement(int[][] jaggedArray) 
        {
        CheckNull(jaggedArray);
        for (int i = jaggedArray.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                int minFirst = 0;
                int minSecond = 0;
                foreach (int integer in jaggedArray[j]) 
                    {
                    if (integer == 0)
                    {
                        minFirst = 0;
                        break;
                    }
                    if (minFirst == 0 || integer <= minFirst)
                    {
                        minFirst = integer;
                    }
                }
                foreach (int integer in jaggedArray[j]) 
                    {
                    if (integer == 0)
                    {
                        minSecond = 0;
                        break;
                    }
                    if (minSecond == 0 || integer <= minSecond) minSecond = integer;
                }
                if (minFirst > minSecond)
                {
                    int[] t = jaggedArray[j];
                    jaggedArray[j] = jaggedArray[j + 1];
                    jaggedArray[j + 1] = t;
                }
            }
        }
        return jaggedArray;
    }


        /// <summary>
        /// sorts the array according to the decreasing of a minimum element in a string
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <returns>int[][]</returns>
        public static int[][] DecrementMinElement(int[][] jaggedArray)
        {
            IncrementMinElement(jaggedArray);
            Reverse(jaggedArray);
            return jaggedArray;
        }
    }
}
