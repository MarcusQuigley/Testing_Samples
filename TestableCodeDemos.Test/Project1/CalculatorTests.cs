using NUnit.Framework;
using TestableCodeDemos.Project1.After;

namespace TestableCodeDemos.Test
{
    public class CalculatorTests
    {
        ICalculator calculator;
        [SetUp]
        private void Setup()
        {
            calculator = new Calculator();
        }

        public void Does_result_add_correctly()
        {
            var result = calculator.GetTotal(5, 2, 3);
            Assert.AreEqual(4, result);
        }
    }
}