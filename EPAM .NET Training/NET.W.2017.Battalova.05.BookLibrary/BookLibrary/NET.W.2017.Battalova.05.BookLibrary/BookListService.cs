using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public class BookListService
    {
        private List<Book> bookCollection;

        /// <summary>
        /// constructor that creates just a new List of books
        /// </summary>
        public BookListService()
        {
            bookCollection = new List<Book>();
        }


        /// <summary>
        /// constructor that loads books from the storage
        /// </summary>
        /// <param name="storage">book storage</param>
        public BookListService(IBookStorage storage)
        {
            bookCollection = new List<Book>();
            try
            {
                bookCollection = storage.ReadBooks();
            }
            catch(Exception e)
            {
                Program.logger.Info("Unhandled exception:");
                Program.logger.Error(e.StackTrace);
            }
        }


        /// <summary>
        /// adds a book to the list of books
        /// </summary>
        /// <param name="b">a book to add</param>
        public void AddBook(Book b)
        {
            try
            {
                bookCollection.Add(b);
            }
            catch(Exception e)
            {
                Program.logger.Info("Unhandled exception:");
                Program.logger.Error(e.StackTrace);
            }
        }

        /// <summary>
        /// saves books to a book storage
        /// </summary>
        /// <param name="storage">a book storage</param>
        public void Save(IBookStorage storage)
        {
            storage.WriteBooks(bookCollection);
        }


        /// <summary>
        /// removes a book from a book storage
        /// </summary>
        /// <param name="b">a book to remove</param>
        public void RemoveBook(Book b)
        {
            try
            {
                bookCollection.Remove(b);
            }
            catch (Exception e)
            {
                Program.logger.Info("Unhandled exception:");
                Program.logger.Error(e.StackTrace);
            }
        }

        /// <summary>
        /// finds a book by a tag
        /// </summary>
        /// <param name="finder">an interface for finding</param>
        /// <param name="criteria"> a critirea according to wich a book should be found</param>
        /// <returns>
        /// a found book if succeeded
        /// null if failed
        /// </returns>

        public Book FindBookByTag(IFinder finder, string criteria)
        {
            foreach (Book b in bookCollection)
            {
                if (finder.Find(b)) return b;
            }
            return null;
        }
    

        /// <summary>
        /// sort a coolection of books
        /// </summary>
        public void SortBooksByTag()
        {
            bookCollection.Sort();
        }


        /// <summary>
        /// sort a collection of books by certain criteria by means of interface
        /// </summary>
        /// <param name="comparer">an interface according to which a collection will be sorted</param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            bookCollection.Sort(comparer);
        }


    }
}

