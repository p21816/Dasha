﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._05.BookLibrary
{
    public  class FinderImplementation: IFinder
    {
        public bool Find(Book b, string ISBN)
        {
            if (b.ISBNProperty == ISBN) return true;
            else return false;
        }
    }
}
