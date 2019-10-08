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
        Invoice _invoice;
        readonly int invoiceId = 6;
        readonly string userName = "marcus";
        [SetUp]
        public void Setup()
        {
            _invoice = new Invoice();
            _mocker = new AutoMoqer();

            _mocker.GetMock<IDatabase>()
                   .Setup(p => p.GetInvoice(invoiceId))
                   .Returns(_invoice);
            _command = _mocker.Create<PrintInvoiceCommand>();
        }

        [Test]
        public void Execute_gets_invoice()
        {
            _command.Execute(invoiceId);
            _mocker.GetMock<IDatabase>()
                  .Verify(p => p.GetInvoice(invoiceId)
                  , Times.Once);
        }

        [Test]
        public void Execute_writes_invoice()
        {
            _command.Execute(invoiceId);
            _mocker.GetMock<IInvoiceWriter>()
                   .Verify(p => p.Write(_invoice)
                   , Times.Once);
        }

        [Test]
        public void Execute_gets_User_from_session()
        {
            _mocker.GetMock<IUser>()
                   .Setup(p => p.GetUserName())
                   .Returns(userName);
            _command.Execute(invoiceId);
            _mocker.GetMock<IUser>()
                   .Verify(p => p.GetUserName()
                   , Times.Once);
            Assert.That(_invoice.LastPrintedBy
                , Is.EqualTo(userName));

        }

        [Test]
        public void Execute_calls_database_save()
        {
            _command.Execute(invoiceId);
            _mocker.GetMock<IDatabase>()
                  .Verify(p => p.Save()
                  , Times.Once);
        }
    }
}
