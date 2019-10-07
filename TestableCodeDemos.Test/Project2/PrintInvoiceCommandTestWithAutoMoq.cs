using AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using TestableCodeDemos.Module2.Shared;
using TestableCodeDemos.Project2.After;

namespace TestableCodeDemos.Test.Project2
{
    [TestFixture]
    public class PrintInvoiceCommandTestWithAutoMoq
    {
        IPrintInvoiceCommand _invoicePrinter;
        AutoMoqer _mocker;
 
        Invoice _invoice;

        const int invoiceId = 1;
        const decimal total = 200.0m;

        [SetUp]
        public void Setup()
        {
            _invoice = new Invoice()
            {
                Id = invoiceId,
                Total = total
            };
            _mocker = new AutoMoqer();
 
            _mocker.GetMock<IDatabase>()
                .Setup(p => p.GetInvoice(invoiceId))
                .Returns(_invoice);
 
             _mocker.GetMock<IDateTimeWrapper>()
                .Setup(p => p.GetNow())
                .Returns(new System.DateTime());
 
            _invoicePrinter = _mocker.Create<NewPrintInvoiceCommand>();
        }

        [Test]
        [TestCase("Invoice ID: 1")]
        [TestCase("Total: $200.0")]
        [TestCase("Printed: 1/1/0001")]
        public void Executes_should_print(string line)
        {
            _invoicePrinter.Execute(invoiceId);
            _mocker.GetMock<IPrinter>()
                .Verify(p => p.WriteLine(line)
                , Times.Once);         
        }
 
        [Test]
        public void Executes_should_call_datetimes_getwrapper()
        {
            _invoicePrinter.Execute(invoiceId);
            _mocker.GetMock<IDateTimeWrapper>()
                .Verify(p => p.GetNow()
                , Times.Once);
        }
       
    }
}
