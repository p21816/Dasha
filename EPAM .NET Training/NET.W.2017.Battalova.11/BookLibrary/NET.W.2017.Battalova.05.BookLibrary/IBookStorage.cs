using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public interface IBookStorage
    {
        List<Book> ReadBooks();
        void WriteBooks(List<Book> li);

    }
}
