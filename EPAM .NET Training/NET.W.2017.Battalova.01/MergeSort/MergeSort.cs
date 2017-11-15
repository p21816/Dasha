using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public static class MergeSort
    {
        public static int[] Sort(int [] array)
        {
            if (array.Length == 1) return array;
            int middle = array.Length / 2;
            return Merge(Sort(array.Take(middle).ToArray()), Sort(array.Skip(middle).ToArray()));
        }

        #region private methods
        private static int[] Merge(int[] lhs, int[] rhs)
        {
            int j = 0, k = 0;
            int[] mergedArray = new int[lhs.Length + rhs.Length];

            for (int i = 0; i < lhs.Length + rhs.Length; i++)
            {
                if (k < rhs.Length && j < lhs.Length)
                    if (lhs[j] > rhs[k] && k < rhs.Length)
                       mergedArray[i] = rhs[k++];
                    else
                       mergedArray[i] = lhs[j++];
                else
                    if (k < rhs.Length)
                        mergedArray[i] = rhs[k++];
                    else
                        mergedArray[i] = lhs[j++];
            }
            return mergedArray;
        }

        #endregion
    }
    }

