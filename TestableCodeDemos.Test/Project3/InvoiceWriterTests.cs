using AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestableCodeDemos.Module3.Shared;
using TestableCodeDemos.Project3.After;

namespace TestableCodeDemos.Test.Project3
{
    [TestFixture]
    class InvoiceWriterTests
    {
        IInvoiceWriter _invoiceWriter;
        AutoMoqer _mocker;
        const int invoiceId = 1;
        const bool isOverdue = false;
        Invoice _invoice;
        [SetUp]
        public void Setup() {
            _invoice = new Invoice()
            {
                Id = invoiceId,
                IsOverdue = isOverdue
            };
            _mocker = new AutoMoqer();
            //_mocker.GetMock<IPageLayout>();
            //_mocker.GetMock<IPrinter>()
            //    .Setup(p=> p.SetPageLayout(null));

            _invoiceWriter = _mocker.Create<InvoiceWriter>();
        }

        [Test]
        [TestCase("Invoice ID: 1")]
        public void should_write(string line) {
            _invoiceWriter.Write(_invoice);
            _mocker.GetMock<IPrinter>()
                .Verify(p => p.WriteLine(line)
                , Times.Once);
        }

        [Test]
        public void write_should_set_pagelayout()
        {
            _invoiceWriter.Write(_invoice);
            var layout = _mocker.GetMock<IPageLayout>().Object;
            _mocker.GetMock<IPrinter>()
                .Verify(p => p.SetPageLayout(layout)
                , Times.Once);
        }

        [Test]
        public void write_should_set_ink_red_when_overdue()
        {
            string color = "Red";
            _invoice.IsOverdue = true;
            _invoiceWriter.Write(_invoice);

            _mocker.GetMock<IPrinter>()
                .Verify(p => p.SetInkColor(color)
                , Times.Once);
        }

        [Test]
        public void should_print_regular_when_ontime()
        {
           // _invoice.IsOverdue = false;
            _invoiceWriter.Write(_invoice);
            _mocker.GetMock<IPrinter>()
                .Verify(p => p.SetInkColor(It.IsAny<string>())
                , Times.Never);
        }
    }
}
