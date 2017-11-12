using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Book HarryPotter = new Book("1", "Harry Potter and the Cursed Child",
                                         "Little, Brown Book Group", 2016, 343, 18.95m);
            //IFormattable:
            Console.WriteLine("IFormattable string: ");
            Console.WriteLine(HarryPotter.ToString("Z"));

            //copy of the book for checkig equals methods
            Book HarryPotterCopy = new Book("1", "Harry Potter and the Cursed Child",
                                         "Little, Brown Book Group", 2016, 343, 18.95m);
            //one another book
            Book theCatcherInTheRye = new Book("2", "The Catcher in the Rye",
                                         "Some Publicher", 1998, 300, 12.15m);

            //cast to Object
            Object theCatcherInTheRyeObject = theCatcherInTheRye;

           //public override bool Equals(Object obj):
            Console.WriteLine(HarryPotter.Equals(theCatcherInTheRyeObject)); // false

            //public bool Equals(Book b):
            Console.WriteLine(HarryPotter.Equals(HarryPotterCopy)); //true

           //public override int GetHashCode():
            Console.WriteLine("HarryPotter Hash: " + HarryPotter.GetHashCode() +
                "\nFight Club Hash: " + theCatcherInTheRye.GetHashCode());

            //order relation:
            Console.WriteLine("order relation: " + theCatcherInTheRye.CompareTo(HarryPotter));
            Console.WriteLine();


            BookListService bookListService = new BookListService();
            bookListService.AddBook(theCatcherInTheRye); // adds book to file
            bookListService.AddBook(HarryPotter); // adds book to file
            Console.WriteLine("two books in a list: ");
            bookListService.ToConsole();


            Book foundBook = bookListService.FindBookByTag("2"); // finds book by ISBN
            Console.WriteLine("found by ISBN book:\n" + foundBook.ToString());

            bookListService.SortBooksByTag(); // sorts books by ISBN
            Console.WriteLine("\nSorted List by ISBN: ");
            bookListService.ToConsole();


            bookListService.RemoveBook(theCatcherInTheRye); // removes book from file
            Console.WriteLine("\ntheCatcherInTheRye was removed: ");
            bookListService.ToConsole();


        }
    }
}
