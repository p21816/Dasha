using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2017.Battalova._03.Tests
{
    [TestClass]
    public class GDCTests
    {
        [TestMethod]
        public void GCDbyEuclidWithTwoParametersTest()
        {
            int actual = GCD.GCDbyEuclid(30, 10);
            int expected = 10;
            Assert.AreEqual(expected, actual);
        }

                [TestMethod]

        public void GCDbyEuclidWithThreeParamsTest()
        {
            int actual = GCD.GCDbyEuclid(30, 10, 20);
            int expected = 10;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCDTestWithFourParams()
        {
            int actual = GCD.GCDbyEuclid(30, 10, 20, 40);
            int expected = 10;
            Assert.AreEqual(expected, actual);
        }

         [TestMethod]
        public void GetGCDTestParams()
        {
            int actual = GCD.GCDbyEuclid(30, 10, 20, 40, 100, 300);
            int expected = 10;
            Assert.AreEqual(expected, actual);
        }

         [TestMethod]
         public void GetGCD()
         {
             string elapsedTime;             
             int expected = 10;
             int actual = GCD.GCDbyEuclid(out elapsedTime, 10, 10);
             Assert.AreEqual(expected, actual);
         }


    }
}
