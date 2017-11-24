using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NET.W._2017.Battalova._02
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        [TestCase(20, -1)]
        [TestCase(10, -1)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(1234126, 1234162)]
        public void FindNextBiggerNumber_PositiveTest(int param, int ExpectedResult)
        {
            Assert.AreEqual(ExpectedResult, Algorithms.FindNextBiggerNumber(param));
        }
    }
}
