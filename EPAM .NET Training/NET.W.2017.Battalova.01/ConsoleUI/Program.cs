using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MergeSort;
using QuickSort;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 23, 54, 23 ,55, 8, 2 , -6, 0 };

            //сортировка слиянием:
            MSort m = new MSort();
            int [] sortedArray = m.mSort(arr);
            Console.WriteLine(sortedArray);

            //быстрая сортировка:
            QSort q = new QSort();
            q.qSort(arr, 0, arr.Length);
        }
    }
}
