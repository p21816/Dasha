using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public class BooksFromBinaryFile: IBooksFromStorage
    {

        #region fields
      private List<Book> bookCollection = new List<Book>();
      private string ISBN;
      private string name;
      private string publisher;
      private int year;
      private int pagesNumber;
      private decimal price;

        #endregion

        /// <summary>
      /// implements ReadBooks method of the IBooksFromStorage Interface, reads books from a binary file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>list of books read from the file</returns>
      public List<Book> ReadBooks(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        ISBN = reader.ReadString();
                        name = reader.ReadString();
                        publisher = reader.ReadString();
                        year = reader.ReadInt32();
                        pagesNumber = reader.ReadInt32();
                        price = reader.ReadDecimal();

                        Book b = new Book(ISBN, name, publisher, year, pagesNumber, price);
                        bookCollection.Add(b);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            return bookCollection;
        }


        /// <summary>
      /// implements WriteBooks method of the IBooksFromStorage Interface, writes the books to a binary file
        /// </summary>
        /// <param name="li"></param>
        /// <param name="fileName"></param>
       public void WriteBooks(List<Book> li, string fileName)
       {
               using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
               {
                   foreach (Book b in li)
                   {
                       writer.Write(b.ISBNProperty);
                       writer.Write(b.Name);
                       writer.Write(b.Publisher);
                       writer.Write(b.Year);
                       writer.Write(b.PagesNumber);
                       writer.Write(b.Price);
                   }
               }
           
       }


    }
}
