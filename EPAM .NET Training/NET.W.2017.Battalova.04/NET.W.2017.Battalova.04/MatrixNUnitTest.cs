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

        /// <summary>
        /// checks if the method sort woks correctly with the ComparerToSumOfTheString implementation of IComparer
        /// </summary>

         [Test]
        public void ComparatorSumTest()
        {
            int[][] jaggedArray = new int[3][];
            FillJaggedArray(jaggedArray);

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 1 };
            expectedArray[1] = new int[] { 1, 2, 3 };
            expectedArray[2] = new int[] { 1, 2, 3, 4, 5 };

            Matrix.Sort(jaggedArray, new ComparerToSumOfTheString());
            Assert.AreEqual(jaggedArray, expectedArray);
        }



        /// <summary>
        ///  checks if the method sort woks correctly with the CompareToMaxElement implementation of IComparer
        /// </summary>
        [Test]
         public void ComparatorMaxTest()
         {
             int[][] jaggedArray = new int[3][];
             FillJaggedArray(jaggedArray);

             int[][] expectedArray = new int[3][];
             expectedArray[0] = new int[] { 1 };
             expectedArray[1] = new int[] { 1, 2, 3 };
             expectedArray[2] = new int[] { 1, 2, 3, 4, 5 };

             Matrix.Sort(jaggedArray, new CompareToMaxElement());
             Assert.AreEqual(jaggedArray, expectedArray);
         }



        /// <summary>
        ///checks if the method sort woks correctly with the CompareToMinElement implementation of IComparer
        /// </summary>
        [Test]
         public void ComparatorMinTest()
         {
             int[][] jaggedArray = new int[3][];
             FillJaggedArray(jaggedArray);

             int[][] expectedArray = new int[3][];
             expectedArray[0] = new int[] { 1, 2, 3, 4, 5 };
             expectedArray[1] = new int[] { 1, 2, 3 };
             expectedArray[2] = new int[] { 1 };


             Matrix.Sort(jaggedArray, new CompareToMinElement());
             Assert.AreEqual(jaggedArray, expectedArray);
         }


        #region private methods
        /// <summary>
        /// fills jagged array with numbers for testing
        /// </summary>
        /// <param name="jaggedArray">an array to sort</param>
        private void FillJaggedArray(int[][] jaggedArray)
        {
            jaggedArray[0] = new int[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new int[] { 1, 2, 3 };
            jaggedArray[2] = new int[] { 1 };
        }
        #endregion
    }





    public class ComparerToSumOfTheString : IComparer
    {
        public int CompareTo(int[] lhs, int[] rhs)
        {
            if (lhs == null) return -1;
            if (rhs == null) return 1;
            return lhs.Sum() - rhs.Sum();

        }
    }

    public class CompareToMaxElement: IComparer
    {
        public int CompareTo(int[] lhs, int[] rhs)
        {
            if (lhs == null) return -1;
            if (rhs == null) return 1;
            return lhs.Max() - rhs.Max();
        }

    }


    public class CompareToMinElement: IComparer
    {
        public int CompareTo(int[] lhs, int[] rhs)
        {
            if (lhs == null) return -1;
            if (rhs == null) return 1;
            return lhs.Min() - rhs.Min();
        }
    }

}



