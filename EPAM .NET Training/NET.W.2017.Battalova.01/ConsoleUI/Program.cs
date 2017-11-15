using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 23, 54, 23 ,55, 8, 2 , -6, 0 };
            Sort.QSort.QuickSort(arr, 0, arr.Length);
            foreach(int i in arr)
                Console.WriteLine(i.ToString());
            //сортировка слиянием:
          //  MSort m = new MSort();
          //  int [] sortedArray = m.mSort(arr);
         //   Console.WriteLine(sortedArray);

            //быстрая сортировка:
           // .qSort(arr, 0, arr.Length);
        }
    }
}
