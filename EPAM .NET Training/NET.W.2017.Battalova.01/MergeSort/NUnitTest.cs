using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sort
{
    [TestFixture]
    public class NUnitTest
    {
        //[Test]
        //public void QuickSortPositiveTest()
        //{
        //    int [] array = {4,2,-1,9,2,1,0 };
        //    QuickSort.Sort(array, 0, array.Length -1);
        //    int[] expectedArray = { -1, 0, 1, 2, 2, 4, 9 };
        //    Assert.AreEqual(expectedArray, array);
        //}

        [Test]
        public void MergeSortPositiveTest()
        {
            int[] array = { 4, 2, -1, 9, 2, 1, 0 };
            int [] actualArray = MergeSort.Sort(array);
            int[] expectedArray = { -1, 0, 1, 2, 2, 4, 9 };
            Assert.AreEqual(expectedArray, actualArray);
        }
    }
}
