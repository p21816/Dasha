using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public interface IComparer
    {
        int CompareTo(Book b);
        bool Equals (Book b);
    }
}
