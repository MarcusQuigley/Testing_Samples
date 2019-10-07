using System;
using AutoMoq;
using Moq;
using NUnit.Framework;
using TestableCodeDemos.Module3.Shared;
using TestableCodeDemos.Project3.After;

namespace TestableCodeDemos.Test.Project3
{
    [TestFixture]
    class PrintInvoiceCommandTests
    {
        IPrintInvoiceCommand _command;
        AutoMoqer _mocker;
        int _invoiceId = 1;
        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMoqer();
            _command = _mocker.Create<PrintInvoiceCommand>();
        }

        [Test]
        public void execute_should_call_getinvoice()
        {
            _command.Execute(_invoiceId);
            _mocker.GetMock<IDatabase>()
                .Verify(p => p.GetInvoice(_invoiceId)
                , Times.Once);
        }

        [Test]
         public void execute_should_call_write()
        {
            Invoice invoice = new Invoice
            {
                Id = _invoiceId,
                IsOverdue = false
            };

            _mocker.GetMock<IDatabase>()
               .Setup(p => p.GetInvoice(_invoiceId))
               .Returns(invoice);

            _command.Execute(_invoiceId);

            _mocker.GetMock<IInvoiceWriter>()
                .Verify(p => p.Write(invoice)
                , Times.Once);
        }
    }
}
