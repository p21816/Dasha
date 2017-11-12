//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;


//namespace NET.W._2017.Battalova._04
//{
//    [TestFixture]
//    public class PolynomialTests
//    {
//        [Test]
//        public void CalculateResultTest(double num)
//        {
//            double[] coeffs = { 1.1, 1.2 , 1.3 };
//            Polynomial pol = new Polynomial(coeffs);
//            double expectedResult = 3.6;
//            double res = pol.CalculateResult(1);
//            Assert.AreEqual(expectedResult, res);
//        }


//        [Test]
//        public void getIndexTest()
//        {
//            double[] arr = { 1, 2, 3, 4, 5, 6 };
//            Polynomial pol = new Polynomial(arr);
//            double expetedResult = 6.0;
//            double res = pol[5];
//            Assert.AreEqual(expetedResult, res);
//        }

//        [Test]
//        public void EqualsTest()
//        {
//            double[] arr = { 45.9, 23.5 };
//            Polynomial ob1 = new Polynomial(arr);
//            object ob2 = ob1;

//            Assert.True(ob1.Equals(ob2));
//        }

//        [Test]
//        public void OperatorPlusTest()
//        {
//            double[] arr1 = { 11.5, 10.0, 4.7 };
//            double[] arr2 = { 8.5, 5.0 };
//            double[] expectedArr = { 20, 15, 4.7 };

//            Polynomial pol1 = new Polynomial(arr1);
//            Polynomial pol2 = new Polynomial(arr2);
//            Polynomial expectedPol = new Polynomial(expectedArr);

//            Polynomial resPol = pol1 + pol2;

//            Assert.True(expectedPol == resPol);
//        }

//        [Test]
//        public void OperatorMinusTest()
//        {
//            double[] arr1 = { 10.5, 7.0 };
//            double[] arr2 = { 5.5, 13.0, 11.3 };
//            double[] expectedArr = { 4.5, -6, -11.3 };

//            Polynomial pol1 = new Polynomial(arr1);
//            Polynomial pol2 = new Polynomial(arr2);
//            Polynomial expectedPol = new Polynomial(expectedArr);

//            Polynomial resPol = Polynomial.Subtract(pol1, pol2);

//            Assert.True(expectedPol == resPol);
//        }



//    }
//}
