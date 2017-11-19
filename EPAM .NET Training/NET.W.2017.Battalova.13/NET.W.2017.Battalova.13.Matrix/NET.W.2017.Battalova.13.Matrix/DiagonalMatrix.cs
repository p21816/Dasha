using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._13.Matrix
{
    public class DiagonalMatrix<T>:Matrix<T>
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">dimension of the matrix</param>
        /// <param name="elements">elements of main diagonal</param>
        /// <exception cref="ArgumentNullException">elements should not be null</exception>

        public DiagonalMatrix(int n,IEnumerable<T> elements):base(n)
        {
            if (elements == null) throw new ArgumentNullException();

            for (int i = 0, j = 0; i < n; i++, j++)
            {
                matrix[i, j] = elements.ElementAt(i);
            }
        }

        /// <summary>
        /// create a new empty diagonal matrix
        /// </summary>
        /// <param name="n">dimension of the matrix</param>
        public DiagonalMatrix(int n)
            : base(n)
        {

        }

        /// <summary>
        /// change element on main diagonal
        /// </summary>
        /// <param name="i">line position of element</param>
        /// <param name="j">column position of element</param>
        /// <param name="obj">new element</param>
        /// <exception cref="IndexOutOfRangeException">i and j should be the same in diagonal matrix</exception>
        public override void ChangeElement(int i, int j, T obj)
        {
            if(i!=j) throw new IndexOutOfRangeException();
            base.ChangeElement(i, j, obj);
        }
    }
}
