using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QSort
    {
        public void qSort(int[] arr, int first, int last)
        {
            int middle = arr[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < middle && i <= last) ++i;
                while (arr[j] > middle && j >= first) --j;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) qSort(arr, first, j);
            if (i < last) qSort(arr, i, last);
        }
    }
}
