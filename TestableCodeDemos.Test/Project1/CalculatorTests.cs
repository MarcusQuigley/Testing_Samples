using NUnit.Framework;
using TestableCodeDemos.Project1.After;

namespace TestableCodeDemos.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        ICalculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Does_result_add_correctly()
        {
            var result = calculator.GetTotal(5, 2, 3);
            //Assert.AreEqual(4, result);
            Assert.That(result, Is.EqualTo(4.0m));
        }
    }
}