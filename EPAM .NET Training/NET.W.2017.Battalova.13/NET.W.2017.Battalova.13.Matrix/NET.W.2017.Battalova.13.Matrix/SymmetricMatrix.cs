using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._13.Matrix
{
    public class SymmetricMatrix<T>: Matrix<T>
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">dimention of matrix</param>
        /// <param name="elements">half of elements to be the values of the matrix</param>
        /// <exception cref="ArgumentNullException">elements should not be null</exception>

        public SymmetricMatrix(int n,IEnumerable<T> elements):base(n)
        {
           if(elements == null) throw new ArgumentNullException();

            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    matrix[i, j] = elements.ElementAt(index);
                    matrix[j, i] = elements.ElementAt(index++);
                }
            }
        }

        /// <summary>
        /// constructor for creating a new empty symmetrical matrix
        /// </summary>
        /// <param name="n">dimension of matrix</param>
        public SymmetricMatrix(int n):base(n)
        {
            
        }

        /// <summary>
        /// change an element 
        /// </summary>
        /// <param name="i">line position of element</param>
        /// <param name="j">column position of element</param>
        /// <param name="value">a new value</param>
        public override void ChangeElement(int i, int j, T value)
        {
            base.ChangeElement(j, i, value);
            base.ChangeElement(i, j, value);
        }

    }
}
