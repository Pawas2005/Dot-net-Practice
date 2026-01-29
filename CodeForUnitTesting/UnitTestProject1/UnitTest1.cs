using CalculatorService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Calculator calcObj = null;
        public UnitTest1()
        {
            calcObj = new Calculator();
        }

        [TestMethod]
        public void TestMethodForAddMe()
        {
            int numTest1 = 100;
            int numTest2 = 20;
            int actual = 0;
            int expected = 300;
            actual = calcObj.AddMe(numTest1, numTest2);
            Assert.AreEqual(expected, actual);
        }
    }
}
