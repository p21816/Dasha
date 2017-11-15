using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{

    public static class QuickSort
    {
        public static void Sort(int[] array, int first, int last)
        {
            int middle = array[(last - first) / 2 + first];
           // int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (array[i] < middle && i <= last) ++i;
                while (array[j] > middle && j >= first) --j;
                if (i <= j)
                {
                    Swap(array[i], array[j]);
                    //temp = array[i];
                    //array[i] = array[j];
                    //array[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) Sort(array, first, j);
            if (i < last) Sort(array, i, last);
        }


        private static void Swap(int lhs, int rhs)
        {
            int temp = 0;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
