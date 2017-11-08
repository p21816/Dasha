using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public interface IBooksFromStorage
    {
        List<Book> ReadBooks(string fileName);
        void WriteBooks(List<Book> li, string fileName);

    }
}
