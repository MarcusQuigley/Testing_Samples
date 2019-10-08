using AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestableCodeDemos.Module4.Before;
using TestableCodeDemos.Module4.Shared;
using TestableCodeDemos.Project4.After;

namespace TestableCodeDemos.Test.Project4
{
    [TestFixture]
   public class PrintInvoiceCommandTests
    {
        AutoMoqer _mocker;
        IPrintInvoiceCommand _command;
        readonly int invoiceId = 6;
        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMoqer();
            _command = _mocker.Create<PrintInvoiceCommand>();
        }

        [Test]
        public void Execute_gets_invoice()
        {
            
            Invoice invoice = new Invoice
            {
                LastPrintedBy = "",
                Status = InvoiceStatus.Open
            };
           
   
            _mocker.GetMock<IDatabase>()
                   .Setup(p => p.GetInvoice(invoiceId))
                   .Returns(invoice);

            _command.Execute(invoiceId);

            _mocker.GetMock<IDatabase>()
                   .Verify(p => p.GetInvoice(invoiceId), Times.Once)
                   ;
                   
        }

        [Test]
        public void Execute_writes_invoice()
        {
            Invoice invoice = new Invoice
            {
                LastPrintedBy = "",
                Status = InvoiceStatus.Open
            };
            _mocker.GetMock<IDatabase>()
                   .Setup(p => p.GetInvoice(invoiceId))
                   .Returns(invoice);

            _command.Execute(invoiceId);
            _mocker.GetMock<IInvoiceWriter>()
                   .Verify(p => p.Write(invoice), Times.Once);
        }

        [Test]
        public void Execute_gets_User_from_session()
        {
            _mocker.GetMock<IDatabase>()
                   .Setup(p => p.GetInvoice(invoiceId))
                   .Returns(new Invoice());
            _command.Execute(invoiceId);
            _mocker.GetMock<IUser>()
                   .Verify(p => p.GetUserName(), Times.Once);
        }

        [Test]
        public void Execute_calls_database_save()
        {
            _mocker.GetMock<IDatabase>()
                   .Setup(p => p.GetInvoice(invoiceId))
                   .Returns(new Invoice());

            _command.Execute(invoiceId);
            
            _mocker.GetMock<IDatabase>()
                   .Verify(p => p.Save(), Times.Once);
        }
    }
}
