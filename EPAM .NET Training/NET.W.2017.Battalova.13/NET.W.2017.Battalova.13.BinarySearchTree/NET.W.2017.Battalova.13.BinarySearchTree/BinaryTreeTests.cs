using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NET.W._2017.Battalova._13.BinarySearchTree
{
    public class BinaryTreeTests
    {
        #region Tests with int

        [Test]
        public void Enumerator_Int_SortedArray()
        {
            int[] array = new int[] { 12, 25, 78, 98, 7, 65, 35 };
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);

            int i = 0;
            foreach (var el in tree)
            {
                array[i] = el;
                i++;
            }

            int[] expectedArr = new int[] { 7, 12, 25, 35, 65, 78, 98 };

            Assert.AreEqual(expectedArr, array);
        }

        #endregion


        #region Tests with string

        public sealed class CustomStringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return x.Length - y.Length;
            }

            [Test]
            public void Enumerator_String_SortedArray()
            {
                string[] array = new string[] { "one", "three", "four" };

                var comparer = new CustomStringComparer();

                BinarySearchTree<string> tree = new BinarySearchTree<string>(array, comparer);

                int i = 0;
                foreach (var el in tree)
                {
                    array[i] = el;
                    i++;
                }

                string[] expectedArr = new string[] { "one", "four", "three" };

                Assert.AreEqual(expectedArr, array);
            }


        #endregion


            #region Test with Book

            sealed class Book:IComparable<Book>,IComparable
            {
                public int Pages { get; set; }

                public string Name { get; set; }

                public string Author { get; set; }


                public int CompareTo(Book ob) 
                {
                   return this.Pages - ob.Pages;
                }

                public int CompareTo(object ob)
                {
                   return CompareTo((Book)ob);
                }
            }


            [Test]
            public void Enumerator_Book_SortedArray()
            {
                var book1 = new Book() { Pages = 910 };

                var book2 = new Book() { Pages = 20 };

                var book3 = new Book() { Pages = 123 };

                Book[] books = {book1, book2, book3 };
                BinarySearchTree<Book> tree = new BinarySearchTree<Book>(books);

                Book[] resBooks = new Book[3];

                int i = 0;
                foreach (var el in tree)
                {
                    resBooks[i] = el;
                    i++;
                }

                Book[] expBooks = { book2, book3, book1 };

                Assert.AreEqual(expBooks, resBooks);
            }

#endregion


        #region Test with struct

        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

        }

        public sealed class CustomPointComparer : IComparer<Point>
        {
        public int Compare(Point x, Point y)
        {
            return x.X * x.Y - y.X * y.Y;
        }
        }

        [Test]
        public void Enumerator_Point_SortedArray()
        {
            var point1 = new Point() { X = 910,Y=3 };

            var point2 = new Point() { X = 9, Y = 3 };

            var point3 = new Point() { X = 91, Y = 2 };

            Point[] points = {point1, point2, point3};

            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(points, new CustomPointComparer());

            var resArray = new Point[3];

            int i = 0;
            foreach (var el in tree)
            {
                resArray[i] = el;
                i++;
            }

            Point[] expArr = { point2, point3, point1 };

            Assert.AreEqual(expArr, resArray);
        }

        #endregion
        }
    }
}
