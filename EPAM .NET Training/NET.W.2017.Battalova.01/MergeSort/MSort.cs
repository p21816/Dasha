using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public class MSort
    {
        public int[] mSort(int [] arr)
        {
            if (arr.Length == 1) return arr;
            int middle = arr.Length / 2;
            return merge(mSort(arr.Take(middle).ToArray()), mSort(arr.Skip(middle).ToArray()));
        }
            public static int[] merge(int[] arr1, int[] arr2)
        {
            int a = 0, b = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length + arr2.Length; i++)
            {
                if (b < arr2.Length && a < arr1.Length)
                    if (arr1[a] > arr2[b] && b < arr2.Length)
                       merged[i] = arr2[b++];
                    else
                       merged[i] = arr1[a++];
                else
                    if (b < arr2.Length)
                        merged[i] = arr2[b++];
                    else
                        merged[i] = arr1[a++];
            }
            return merged;
        }
        }
    }

