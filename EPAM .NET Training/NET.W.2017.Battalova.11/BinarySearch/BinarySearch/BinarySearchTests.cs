using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BinarySearch
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void BinarySearchPositiveTest()
        {
            string[] array = {"one", "two", "three", "four", "five"  };
            string elementToFind = "three";
            int result = Search.BinarySearch(array, elementToFind, new BinarySearchForStringComparer());
            Assert.AreEqual(2,2);
        }
    }
}
