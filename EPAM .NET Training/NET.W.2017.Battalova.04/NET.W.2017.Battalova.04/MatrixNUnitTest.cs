using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NET.W._2017.Battalova._04;

namespace NET.W._2017.Battalova._04
{
    [TestFixture]
    class MatrixNUnitTest
    {


         [Test]
        public void Test()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new int[] { 1, 2, 3 };
            jaggedArray[2] = new int[] { 1 };

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 1 };
            expectedArray[1] = new int[] { 1, 2, 3 };
            expectedArray[2] = new int[] { 1, 2, 3, 4, 5 };

             int [][]result = Matrix.Sort(jaggedArray, new ComparerRealization());
            Assert.AreEqual(jaggedArray, );
        }
    }



    public class ComparerRealization : IComparer
    {
        public int CompareTo(int[] lhs, int[] rhs)
        {
            if (lhs == null) return -1;

            if (rhs == null) return 1;

            return lhs.Sum() - rhs.Sum();

        }

        public int CompareToMaxElement(int[] lhs, int[] rhs)
        {
            int maxFirst = 0;
            int maxSecond = 0;
            foreach (int i in lhs)
            {
                if (i > maxFirst) maxFirst = i;
            }
            foreach (int i in rhs)
            {
                if (i > maxSecond) maxSecond = i;
            }

            if (maxFirst > maxSecond)
            {
                return 0;
            }
            else if (maxSecond > maxFirst)
            {
                return 1;
            }
            else return -1;
        }

        public int CompareToMinElement(int[] lhs, int[] rhs)
        {
            int minFirst = 0;
            int minSecond = 0;
            foreach (int i in lhs)
            {
                if (i < minFirst) minFirst = i;
            }
            foreach (int i in rhs)
            {
                if (i < minSecond) minSecond = i;
            }

            if (minFirst > minSecond)
            {
                return 0;
            }
            else if (minSecond > minFirst)
            {
                return 1;
            }
            else return -1;
        }
    }
}
