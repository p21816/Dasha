using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._04
{
    public sealed class Polynomial
    {
       double[] coefficients { get;  set; }

        /// <summary>
        /// polynomial constructor
        /// </summary>
        /// <param name="coeffs"></param>
        public Polynomial(params double[] coeffs)
        {
            coefficients = new double[coeffs.Length];
            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] = coeffs[i];
            }
        }

        /// <summary>
        /// get th eelement by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= coefficients.Length)
                    throw new ArgumentOutOfRangeException();

                return coefficients[index];
            }
        }


        /// <summary>
        /// gets lenght of an array of coefficients of polynomial
        /// </summary>
        public int Length
        {
            get { return coefficients.Length; }
        }

        /// <summary>
        /// calculates result
        /// </summary>
        /// <param name="num"></param>
        /// <returns>double</returns>
        public double CalculateResult(double num)
        {
            double sum = 0;

            for (int i = 0; i < this.Length; i++)
                sum += this[i] * Math.Pow(num, i);

            return sum;
        }


        /// <summary>
        /// minus operator
        /// </summary>
        /// <param name="polynom1"></param>
        /// <param name="polynom2"></param>
        /// <returns></returns>
        public static Polynomial operator-(Polynomial polynom1, Polynomial polynom2)
        {
            Polynomial longest = (polynom1.Length > polynom2.Length) ? polynom1 : polynom2;
            Polynomial shortest = (longest == polynom2) ? polynom2 : polynom1;

            double[] resultArray = new double[longest.Length];

            for (int i = 0; i < longest.Length; i++)
            {
                resultArray[i] = longest[i];
            }

            for (int i = 0; i < shortest.Length; i++)
                resultArray[i] -= shortest[i];

            return new Polynomial(resultArray);
        }

        /// <summary>
        /// multiply operator
        /// </summary>
        /// <param name="polynom1"></param>
        /// <param name="polynom2"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial polynom1, Polynomial polynom2)
        {
            double[] resultArray = new double[polynom1.Length + polynom2.Length - 1];

            for (int i = 0; i < polynom1.Length; i++)
            {
                for (int j = 0; j < polynom2.Length; j++)
                {
                    resultArray[i + j] += polynom1[i] * polynom2[j];
                }
            }
            return new Polynomial(resultArray);
        }

        /// <summary>
        /// plus operator
        /// </summary>
        /// <param name="polynom1"></param>
        /// <param name="polynom2"></param>
        /// <returns></returns>
        public static Polynomial operator+(Polynomial polynom1, Polynomial polynom2)
        {
            Polynomial longest = (polynom1.Length > polynom2.Length) ? polynom1 : polynom2;
            Polynomial shortest = (longest == polynom2) ? polynom2 : polynom1;

            double[] resultArray = new double[longest.Length];

            for (int i = 0; i < longest.Length; i++)
            {
                resultArray[i] = longest[i];
            }

            for (int i = 0; i < shortest.Length; i++)
                resultArray[i] += shortest[i];

            return new Polynomial(resultArray);
        }

        /// <summary>
        /// counts the sum of two polynomials
        /// </summary>
        /// <param name="polynom1"></param>
        /// <param name="polynom2"></param>
        /// <returns></returns>
        public static Polynomial Add(Polynomial polynom1, Polynomial polynom2)
        {
            return polynom1 + polynom2;
        }


        /// <summary>
        /// counts substraction of two polynomials
        /// </summary>
        /// <param name="polynom1"></param>
        /// <param name="polynom2"></param>
        /// <returns></returns>
        public static Polynomial Subtract(Polynomial polynom1, Polynomial polynom2)
        {
            return polynom1 - polynom2;
        }

        public static Polynomial Multiply(Polynomial polynom1, Polynomial polynom2)
        {
            return polynom1 * polynom2;
        }

        /// <summary>
        /// shows if the elements are equal or not
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Polynomial pol = obj as Polynomial;
            if ((object)pol == null)
            {
                return false;
            }
            return coefficients.SequenceEqual(pol.coefficients);
        }

        /// <summary>
        /// shows if the elements are equal or not
        /// </summary>
        /// <param name="pol"></param>
        /// <returns></returns>
        public bool Equals(Polynomial pol)
        {
            return coefficients.SequenceEqual(pol.coefficients);
        }

        /// <summary>
        /// get hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return coefficients.GetHashCode();
        }

        /// <summary>
        /// converts polynomial to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "";

            foreach (double coef in coefficients)
                str += coef.ToString();
            return str;
        }

        /// <summary>
        /// shows if the elements are equal or not
        /// </summary>
        /// <param name="pol1"></param>
        /// <param name="pol2"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (ReferenceEquals((object)pol1, (object)pol2))
            {
                return true;
            }

            if ((object)pol1 == null || (object)pol2 == null)
            {
                return false;
            }

            return pol1.coefficients.SequenceEqual(pol2.coefficients);
        }

        /// <summary>
        /// shows if the elements are equal or not
        /// </summary>
        /// <param name="pol1"></param>
        /// <param name="pol2"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !(pol1 == pol2);
        }
    }
}
