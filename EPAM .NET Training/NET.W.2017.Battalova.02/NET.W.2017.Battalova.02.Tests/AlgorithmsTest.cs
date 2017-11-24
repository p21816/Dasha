//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace NET.W._2017.Battalova._02.Tests
//{
//    [TestClass]
//    public class AlgorithmsTest
//    {
//        [TestMethod]
//        public void FilterDigitTest()
//        {
//            int[] digits = { 1, 17, 2, 70, 3, 4, 5, 7, 9 };
//            int number = 7;
//            int [] actual = Algorithms.FilterDigit(digits, number);

//            int[] expected = { 17, 70, 7 };
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void NextBiggerNumberTest()
//        {
//            int number = 2017;

//            int actual = Algorithms.NextBiggerNumber(number);

//            int expected = 2071;
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void IntegerInsertionTest()
//        {
//            int firstNumber = 8;
//            int secondNumber = 15;
//            int start = 3;
//            int end = 5;

//            int actual = Algorithms.IntegerInsertion(firstNumber, secondNumber, start , end);

//            int expected = 12;
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void SqrtTest()
//        {
//            double number = 1;
//            int n = 5;
//            double precision = 0.0001;

//            double actual = Algorithms.Sqrt(number, n , precision);

//            double expected = 1;
//            Assert.AreEqual(expected, actual);
//        }


//    }
//}
