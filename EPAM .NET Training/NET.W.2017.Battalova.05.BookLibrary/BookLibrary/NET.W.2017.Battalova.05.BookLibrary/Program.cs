using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    class Program
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Book theCatcherInTheRye = new Book("2", "The Catcher in the Rye",
                                 "Some Publisher", 1998, 300, 12.15m);
            Book HarryPotter = new Book("1", "Harry Potter and the Cursed Child",
                                         "Little, Brown Book Group", 2016, 343, 18.95m);

            BookListService bookListService = new BookListService();
            bookListService.AddBook(HarryPotter);

        }
    }
}
