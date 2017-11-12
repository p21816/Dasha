using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public class Book: IComparer, IFormattable
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


        /// <summary>
        /// creates a new Book based on parameters
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="name"></param>
        /// <param name="publisher"></param>
        /// <param name="year"></param>
        /// <param name="pagesNumber"></param>
        /// <param name="price"></param>
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

        #region Object Methods

        /// <summary>
        /// overrides equals method of an Object 
        /// </summary>
        /// <param name="obj"></param>
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

        #region order and equality relations


        /// <summary>
        /// implementation of CompareTo method of the IComparer Interface
        /// </summary>
        /// <param name="b"></param>
        /// <returns>
        /// 0 is the objects are equal,
        /// 1 if param b is smaller than current object, 
        /// -1 if param b is bigger than current object
        /// </returns>
        public int CompareTo(Book b)
          {
              if (b == null) return 1;
              return this.ISBNProperty.CompareTo(b.ISBNProperty);
          }


        /// <summary>
        /// implementation of Equals method of the IComparer Interface
        /// </summary>
        /// <param name="b"></param>
        /// <returns>true if the objects are equal nad false if the objects are different</returns>
          public bool Equals(Book b)
          {
              // If parameter is null return false:
              if ((object)b == null)
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
