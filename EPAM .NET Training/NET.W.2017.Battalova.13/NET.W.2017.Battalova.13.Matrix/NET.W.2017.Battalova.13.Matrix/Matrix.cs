using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._13.Matrix
{
    public abstract class Matrix<T>
    {
        #region Fields

        private int dimension;
        protected T[,] matrix;
        public EventHandler ChangeHandler;

        #endregion

        #region Properties
        public int Dimension
        {
            get { return dimension; }
        }
        #endregion

        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="n">dimension</param>
        /// <exception cref="ArgumentOutOfRangeException">matrix dimention cannot be less then zero</exception>

        public Matrix(int n)
        {
            if (n <= 0) throw new ArgumentOutOfRangeException();
            dimension = n;
            matrix = new T[dimension, dimension];
        }

        /// <summary>
        /// change a value in the matrix
        /// </summary>
        /// <param name="i">line postition of element to be chanched</param>
        /// <param name="j">column postition of element to be chanched</param>
        /// <param name="value">new value</param>

        public virtual void ChangeElement(int i, int j, T value)
        {
            matrix[i, j] = value;
            MatrixChanged(this, new MatrixElementChangedEventArgs<T>(i, j, value));
        }

        /// <summary>
        /// event handler
        /// </summary>
        /// <param name="o">object that was changed</param>
        /// <param name="args">description of a change</param>
        private void MatrixChanged(object o, MatrixElementChangedEventArgs<T> args)
        {
            ChangeHandler(o, args);
        }

    }

    public class MatrixElementChangedEventArgs<T>: EventArgs
    {
        private int i;
        private int j;
        private T value;

        #region Properties

        public int I
        {
            get { return i; }
        }

        public int J
        {
            get { return j; }
        }

        public T Value
        {
            get { return this.value; }
        }

        #endregion
        public MatrixElementChangedEventArgs(int i, int j, T value)
        {
            this.i = i;
            this.j = j;
            this.value = value;
        }

    }
    
}
