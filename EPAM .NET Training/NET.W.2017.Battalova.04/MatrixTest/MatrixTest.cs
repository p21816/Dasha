using System;
using NET.W._2017.Battalova._04;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace NET.W._2017.Battalova._04
{

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new int[] { 1, 2, 3 };
            jaggedArray[2] = new int[] { 1 };

            int [][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 1 };
            expectedArray[1] = new int[] { 1, 2, 3 };
            expectedArray[2] = new int[] { 1,2,3,4,5};

            IComparer comparer = new ComparerRealization();

            Matrix.Sort(jaggedArray, comparer);
        }



        
    }
}
