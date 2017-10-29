using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace NET.W._2017.Battalova._04
{
        [TestFixture]
    class MatrixTests
    {
            [Test]
           public void IncrementSumTest()
            {
                 int[][] jaggedArray = new int[4][];
                 jaggedArray[2] = new int[]{5};
                 jaggedArray[3] = new int[]{6, 4, 2};
                 jaggedArray[0] = new int[]{5, 3, 0, 2};
                 jaggedArray[1] = new int[]{8, 7, 1};

                 int[][] expected = new int[4][];
                 expected[0] = new int[] { 5 };
                 expected[1] = new int[] { 5,3,0,2 };
                 expected[2] = new int[] { 6,4,2 };
                 expected[3] = new int[] { 8,7,1 };
                Assert.AreEqual(expected, Matrix.IncrementSum(jaggedArray));
            }

            [Test]
            public void DecrementSumTest()
            {
                int[][] jaggedArray = new int[4][];
                jaggedArray[2] = new int[] { 5 };
                jaggedArray[3] = new int[] { 6, 4, 2 };
                jaggedArray[0] = new int[] { 5, 3, 0, 2 };
                jaggedArray[1] = new int[] { 8, 7, 1 };

                int[][] expected = new int[4][];
                expected[0] = new int[] { 8,7,1 };
                expected[1] = new int[] { 6,4,2 };
                expected[2] = new int[] { 5,3,0,2};
                expected[3] = new int[] { 5 };
                Assert.AreEqual(expected, Matrix.IncrementSum(jaggedArray));
            }

            [Test]
            public void IncrementMaxElementTest()
            {
                int[][] jaggedArray = new int[4][];
                jaggedArray[2] = new int[] { 5 };
                jaggedArray[3] = new int[] { 6, 4, 2 };
                jaggedArray[0] = new int[] { 5, 3, 0, 2 };
                jaggedArray[1] = new int[] { 8, 7, 1 };

                int[][] expected = new int[4][];
                expected[0] = new int[] { 5,3,0,2};
                expected[1] = new int[] { 5 };
                expected[2] = new int[] { 6,4,2 };
                expected[3] = new int[] { 8,7,1};
                Assert.AreEqual(expected, Matrix.IncrementSum(jaggedArray));
            }

            [Test]
            public void DecrementMaxElementTest()
            {
                int[][] jaggedArray = new int[4][];
                jaggedArray[2] = new int[] { 5 };
                jaggedArray[3] = new int[] { 6, 4, 2 };
                jaggedArray[0] = new int[] { 5, 3, 0, 2 };
                jaggedArray[1] = new int[] { 8, 7, 1 };

                int[][] expected = new int[4][];
                expected[0] = new int[] { 8,7,1 };
                expected[1] = new int[] { 6,4,2 };
                expected[2] = new int[] { 5 };
                expected[3] = new int[] { 5, 3, 0, 2 };
                Assert.AreEqual(expected, Matrix.IncrementSum(jaggedArray));
            }

            [Test]
            public void IncrementMinElementTest()
            {
                int[][] jaggedArray = new int[4][];
                jaggedArray[2] = new int[] { 5 };
                jaggedArray[3] = new int[] { 6, 4, 2 };
                jaggedArray[0] = new int[] { 5, 3, 0, 2 };
                jaggedArray[1] = new int[] { 8, 7, 1 };

                int[][] expected = new int[4][];
                expected[0] = new int[] { 5,3,0,2};
                expected[1] = new int[] {8,7,1, };
                expected[2] = new int[] { 6,4,2 };
                expected[3] = new int[] { 5 };
                Assert.AreEqual(expected, Matrix.IncrementSum(jaggedArray));
            }

            [Test]
            public void DecrementMinElementTest()
            {
                int[][] jaggedArray = new int[4][];
                jaggedArray[2] = new int[] { 5 };
                jaggedArray[3] = new int[] { 6, 4, 2 };
                jaggedArray[0] = new int[] { 5, 3, 0, 2 };
                jaggedArray[1] = new int[] { 8, 7, 1 };

                int[][] expected = new int[4][];
                expected[0] = new int[] { 5};
                expected[1] = new int[] { 6,4,2 };
                expected[2] = new int[] { 8,7,1 };
                expected[3] = new int[] { 5,3,0,2 };
                Assert.AreEqual(expected, Matrix.IncrementSum(jaggedArray));
            }
    }
}
