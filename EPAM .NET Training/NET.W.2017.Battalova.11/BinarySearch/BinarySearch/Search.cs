using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Search
    {
        /// <summary>
        /// search the given element
        /// </summary>
        /// <typeparam name="T">any type</typeparam>
        /// <param name="array">an array to search in</param>
        /// <param name="element">an element to search</param>
        /// <param name="comparer">interface according to which the search is made</param>
        /// <returns></returns>
        public static int BinarySearch<T>( T[] array, T element, IComparer<T> comparer)
        {
            int left = 0;
            int right = array.Length - 1;
            int middle = right / 2;

            while (left <= right)
            {
                int result = comparer.Compare(array[middle], element);
                if (result == 0)
                    return middle;
                else if (result < 0)
                {
                    left = middle + 1;
                    middle = (left + right) / 2;
                }
                else 
                {
                    right = middle - 1;
                    middle = (left + right) / 2;
                }
            }
            return -1;
        }
    }
}
