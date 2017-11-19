using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace NET.W._2017.Battalova._13.Matrix
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SymmetricMatrixTest()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 5, 1, 3 };
            matrix[1] = new int[] { 2, 0, 2 };
            matrix[2] = new int[] { 3, 1, 5 };

            int[] elements = { 5, 1, 3, 2, 0 };
            SymmetricMatrix<int> symMatrix = new SymmetricMatrix<int>(3, elements);
            Assert.AreEqual(matrix, symMatrix);
        }

        [Test]
        public void DiagonalMatrixTest()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 5, 0, 0 };
            matrix[1] = new int[] { 0, 1, 0 };
            matrix[2] = new int[] { 0, 0, 3 };

            int[] elements = { 5, 1, 3 };
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(3, elements);
            Assert.AreEqual(matrix, diagonalMatrix);
        }
    }
}
