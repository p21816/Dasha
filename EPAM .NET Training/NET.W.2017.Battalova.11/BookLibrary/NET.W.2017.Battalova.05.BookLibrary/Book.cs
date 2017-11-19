using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public class Book: IFormattable, IComparable, IComparable<Book> , IEquatable<Book>
    {
        #region fields

        private string ISBN;
        private string name;
        private string publisher;
        private int year;
        private int pagesNumber;
        private decimal price;

        #endregion

        #region Properties

        public string ISBNProperty
        {
            get { return ISBN; }
            set { ISBN = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int PagesNumber
        {
            get { return pagesNumber; }
            set { pagesNumber = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion

        #region constructor

        public Book(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// creates a new Book based on parameters
        /// </summary>
        /// <param name="ISBN">a unique number of the book</param>
        /// <param name="name">a name of the book</param>
        /// <param name="publisher">a publisher of the book</param>
        /// <param name="year">a year when the book was published</param>
        /// <param name="pagesNumber">a number of pages of the book</param>
        /// <param name="price">a price of the book</param>

        public Book(string ISBN, string name, string publisher, int year, int pagesNumber, decimal price)
        {
            this.ISBN = ISBN;
            this.name = name;
            this.publisher = publisher;
            this.year = year;
            this.pagesNumber = pagesNumber;
            this.price = price;
        }

        #endregion

        #region IComparable, IComparable<Book> realization

        /// <summary>
        /// implement interface IComparable
        /// </summary>
        /// <param name="obj">other object that is compared with a book</param>
        /// <returns>
        /// 1 if the other object is less
        /// -1 if the othe object is bigger
        /// 0 if the objects are equal
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Book otherBook = obj as Book;
            try
            {
                return this.PagesNumber.CompareTo(otherBook.PagesNumber);
            }
            catch(Exception e)
            {
                Program.logger.Info("Unhandled exception:");
                Program.logger.Error(e.StackTrace);
            }
            throw new ArgumentException("object is ot a book");
        }


        /// <summary>
        /// Implement the generic CompareTo method with the Book class as the Type parameter.
        /// </summary>
        /// <param name="other">other book</param>
        /// <returns>
        ///  1 if the other object is less
        /// -1 if the othe object is bigger
        ///  0 if the objects are equal
        /// </returns>
        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return PagesNumber.CompareTo(other.PagesNumber);
        }


        /// <summary>
        ///  Define the is greater than operator.
        /// </summary>
        /// <param name="operand1">one book</param>
        /// <param name="operand2">another book</param>
        /// <returns>
        ///  1 if the other object is less
        /// -1 if the othe object is bigger
        ///  0 if the objects are equal
        /// </returns>
        public static bool operator >(Book operand1, Book operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }


        /// <summary>
        /// Define the is less than operator.
        /// </summary>
        /// <param name="operand1">one book</param>
        /// <param name="operand2">another book</param>
        /// <returns>
        ///  1 if the other object is less
        /// -1 if the othe object is bigger
        ///  0 if the objects are equal
        /// </returns>
        public static bool operator <(Book operand1, Book operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }


        /// <summary>
        /// Define the is greater than or equal to operator.
        /// </summary>
        /// <param name="operand1">one book</param>
        /// <param name="operand2">another book</param>
        /// <returns>
        ///  1 if the other object is less
        /// -1 if the othe object is bigger
        ///  0 if the objects are equal
        /// </returns>
        public static bool operator >=(Book operand1, Book operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }


        /// <summary>
        /// Define the is less than or equal to operator.
        /// </summary>
        /// <param name="operand1">one book</param>
        /// <param name="operand2">another book</param>
        /// <returns>
        ///  1 if the other object is less
        /// -1 if the othe object is bigger
        ///  0 if the objects are equal
        /// </returns>

        public static bool operator <=(Book operand1, Book operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

        #endregion

        #region IEquatable<Book>


        /// <summary>
        /// Implement the Equals method with the Book class as the Type parameter.
        /// </summary>
        /// <param name="other">other book</param>
        /// <returns>
        /// true if the objects are equals
        /// false if the objects are different
        /// </returns>
        public bool Equals(Book other)
        {
            if (other == null)
                return false;

            if (this.ISBNProperty == other.ISBNProperty
                && this.Name == other.Name
                && this.Publisher == other.Publisher
                && this.Year == other.Year
                && this.PagesNumber == other.PagesNumber
                && this.Price == other.Price
                )
                return true;
            else
                return false;
        }


        /// <summary>
        /// Implement the operator equals
        /// </summary>
        /// <param name="lhs">one book</param>
        /// <param name="rhs">other book</param>
        /// <returns>
        /// true if the objects are equals
        /// false if the objects are different
        /// </returns>
        public static bool operator ==(Book lhs, Book rhs)
        {
            if (((object)lhs) == null || ((object)rhs) == null)
                return Object.Equals(lhs, rhs);

            return lhs.Equals(rhs);
        }


        /// <summary>
        /// Implement the operator not equals
        /// </summary>
        /// <param name="lhs">one book</param>
        /// <param name="rhs">other book</param>
        /// <returns>
        ///true if the objects are diferent
        /// false if the objects are equals
        /// </returns>
        public static bool operator !=(Book lhs, Book rhs)
        {
            if (((object)lhs) == null || ((object)rhs) == null)
                return !Object.Equals(lhs, rhs);

            return !(lhs.Equals(rhs));
        }

        #endregion

        #region Object Methods

        /// <summary>
        /// overrides equals method of an Object 
        /// </summary>
        /// <param name="obj">object to compare with</param>
        /// <returns>true if the objects are equal nad false if the objects are different</returns>
        public override bool Equals(Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Book b = obj as Book;
            if ((Object)b == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ISBN == b.ISBN) 
                && (name == b.name)
                && (publisher == b.publisher)
                && (year == b.year)
                && (pagesNumber == b.pagesNumber)
                && (price == b.price);
        }


        /// <summary>
        /// overrides GetHashCode method of an Object
        /// </summary>
        /// <returns>Hash Code based on year and nu,ber of pages of the book</returns>

        public override int GetHashCode()
        {
            return year ^ pagesNumber;
        }

        #endregion

        #region IFormattable realization

          public override string ToString()
          {
              return this.ToString("G", CultureInfo.CurrentCulture);
          }
          public string ToString(string format)
          {
              return this.ToString(format, CultureInfo.CurrentCulture);
          }

          public string ToString(string format, IFormatProvider provider)
          {
              if (String.IsNullOrEmpty(format)) format = "G";
              if (provider == null) provider = CultureInfo.CurrentCulture;

              switch (format.ToUpperInvariant())
              {
                  case "G":
                  case "A":
                      return name.ToString()+ " , " + publisher.ToString();
                  case "B":
                      return name.ToString() + " , " + publisher.ToString() + " , " + year.ToString();
                  case "Z":
                      return name.ToString() + " , " + publisher.ToString()
                          + " , " + year.ToString() + " , " + ISBN.ToString() + " , " + price.ToString("C");
                  default:
                      throw new FormatException(String.Format("The {0} format string is not supported.", format));
              }
          }

        #endregion
    }
}
