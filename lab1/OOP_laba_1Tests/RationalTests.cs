using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_laba_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_laba_1.Tests
{
    [TestClass()]
    public class RationalTests
    {
        [TestMethod()]
        public void sumTest()
        {
            Rational r1 = new Rational(5, 2);
            Rational r2 = new Rational(15, 3);
            
            Rational sum = r1 + r2;
            Rational mysum = new Rational(15, 2);

            Assert.IsTrue(mysum == sum);
        }
        [TestMethod()]
        public void decTest()
        {
            Rational r1 = new Rational(5, 3);
            Rational r2 = new Rational(15, 3);

            Rational sum = r2 - r1;
            Rational mysum = new Rational(10, 3);
            Assert.IsTrue(sum == mysum);
        }
        [TestMethod()]
        public void biggerTest()
        {
            Rational r1 = new Rational(5, 3);
            Rational r2 = new Rational(15, 3);
            Assert.IsTrue(r2 > r1);
        }
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}