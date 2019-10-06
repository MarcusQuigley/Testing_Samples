using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableCodeDemos.Project1.After;

namespace TestableCodeDemos.Project1.Tests
{
    [TestFixture]
   public class CalculatorTests
    {
        ICalculator calculator;
        [SetUp]
        public   void Setup()
        {
            calculator = new Calculator();
        }
        [Test]
        public void Does_result_add_correctly()
        {
            var result = calculator.GetTotal(5, 2, 3);
            Assert.AreEqual(4, result);
        }
    }
}
