using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2017.Battalova._03.Tests
{
    [TestClass]
    public class GDCTests
    {
        [TestMethod]
        public void GetGCDTest()
        {
            int actual = GCD.GetGCD(30, 10);
            int expected = 10;
            Assert.AreEqual(expected, actual);
        }

                [TestMethod]

        public void GetGCDTestWithThreeParams()
        {
            int actual = GCD.GetGCD(30, 10 ,20);
            int expected = 10;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCDTestWithFourParams()
        {
            int actual = GCD.GetGCD(30, 10, 20 ,40);
            int expected = 10;
            Assert.AreEqual(expected, actual);
        }

         [TestMethod]
        public void GetGCDTestParams()
        {
            int actual = GCD.GetGCD(30, 10, 20, 40 ,100, 300);
            int expected = 10;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void GetGCD_ElapsedTimeTest()
        {
            string elapsedTime;
            int gcd;
            GCD.GetGCD_ElapsedTime(out gcd, out elapsedTime, 10, 10);
            int expected = 10;
            int actual = gcd;
            Assert.AreEqual(expected, actual);
        }


    }
}
