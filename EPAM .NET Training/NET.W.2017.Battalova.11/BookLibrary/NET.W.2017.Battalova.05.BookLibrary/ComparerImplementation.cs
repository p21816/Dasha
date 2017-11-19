using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public class ComparerImplementation : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            if (a.PagesNumber == b.PagesNumber) return 0;
            if (a.PagesNumber > b.PagesNumber)
            {
                return 1;
            }
            else return -1;
        }
    }
}
