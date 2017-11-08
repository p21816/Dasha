using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public class BookListService
    {
        #region fields

        private List<Book> bookCollection;
        private IBooksFromStorage books = new BooksFromBinaryFile();
        private string fileName = "BookListStorage.dat";

        #endregion


        /// <summary>
        /// prints bookCollection to console
        /// </summary>
        public void ToConsole()
        {
            foreach(Book b in bookCollection)
            {
                Console.WriteLine(b.ToString());
            }
        }

        /// <summary>
        /// makes a new BookListService.
        /// If there are books in a file, reads them and adds them to the List bookCollection.
        /// If thete the books are absent creates new List bookCollection
        /// </summary>
        public BookListService()
        {
            try
            {
                bookCollection = new List<Book>();
                bookCollection = books.ReadBooks(fileName);
            }
            catch
            {
                bookCollection = new List<Book>();
            }
        }


        /// <summary>
        /// adds the book to a file
        /// </summary>
        /// <param name="b"></param>

       public void AddBook(Book b)
       {
           if(bookCollection.Contains(b))
           {
               throw new InvalidOperationException();
           }
           bookCollection.Add(b);
           books.WriteBooks(bookCollection, fileName);
       }


        /// <summary>
        /// removes the book from a file
        /// </summary>
        /// <param name="b"></param>
        public void RemoveBook(Book b)
       {
            if(!(bookCollection.Contains(b)))
            {
                throw new InvalidOperationException();
            }
            bookCollection.Remove(b);
            books.WriteBooks(bookCollection, fileName);
       }


        /// <summary>
        /// finds the book by ISBN
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns>found book</returns>
        public Book FindBookByTag(string isbn)
        {
            foreach(Book b in bookCollection)
            {
                if(b.ISBNProperty == isbn)
                {
                    return b;
                }
            }
            return null;
        }



        /// <summary>
        /// sorts collection by ISBN
        /// </summary>
        public void SortBooksByTag()
        {
            for (int i = 0; i < bookCollection.Count(); i++)
            {
                for (int j = 0; j < bookCollection.Count() - i - 1; j++)
                {
                    if (bookCollection[j].CompareTo(bookCollection[j + 1]) == 1)
                    {
                        Book temp = bookCollection[j];
                        bookCollection[j] = bookCollection[j + 1];
                        bookCollection[j + 1] = temp;
                    }
                }
            }
        }


    }
}

