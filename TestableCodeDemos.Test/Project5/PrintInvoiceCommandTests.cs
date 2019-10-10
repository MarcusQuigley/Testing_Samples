using AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestableCodeDemos.Module5.After;
using TestableCodeDemos.Module5.Shared;

namespace TestableCodeDemos.Test.Project5
{
    [TestFixture]
   public class PrintInvoiceCommandTests
    {
        AutoMoqer _mocker;
        PrintInvoiceCommand _command;
     // 
        const int _invoiceId = 6;
        const string printedBy = "marcus";
        Invoice _invoice;
        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMoqer();


            _invoice = new Invoice(); 
           

            _mocker.GetMock<IDatabase>()
                   .Setup(p => p.GetInvoice(_invoiceId))
                   .Returns(_invoice);

            //_mocker.GetMock<IInvoiceWriter>()
            //      .Setup(p => p.Print(_invoice));

            _mocker.GetMock<ISecurity>()
                   .Setup(p => p.IsAdmin())
                   .Returns(true);
            _mocker.GetMock<ISecurity>()
                .Setup(p => p.GetUserName())
                .Returns(printedBy);
            _command = _mocker.Create<PrintInvoiceCommand>();

        }
 
        [Test]
        public void Execute_gets_invoice()
        {
            _mocker.GetMock<ISecurity>()
                  .Setup(p => p.IsAdmin())
                  .Returns(true);
            _command.Execute(_invoiceId);
            _mocker.GetMock<IDatabase>()
                   .Verify(p => p.GetInvoice(_invoiceId), Times.Once);
        }
        
        [Test]
        public void Execute_throws_exeption_if_Execute_not_admin()
        {
            _mocker.GetMock<ISecurity>()
                .Setup(p => p.IsAdmin())
                .Returns(false);
 
            Assert.That(() => _command.Execute(_invoiceId),
                Throws.TypeOf<UserNotAuthorizedException>());
 
        }

        [Test]
        public void Execute_should_print_invoice()
        {
            _command.Execute(_invoiceId);
            _mocker.GetMock<IInvoiceWriter>()
                    .Verify(p => p.Print(_invoice), Times.Once);
        }
        [Test]
        public void should_set_lastPrintedBy_to_GetUserName()
        {
            _command.Execute(_invoiceId);
            Assert.That(_invoice.LastPrintedBy, Is.EqualTo(printedBy));
        }

        public void Execute_should_save_to_db()
        {
            _command.Execute(_invoiceId);
            _mocker.GetMock<IDatabase>()
                    .Verify(p => p.Save(), Times.Once);
        }

    }
}
