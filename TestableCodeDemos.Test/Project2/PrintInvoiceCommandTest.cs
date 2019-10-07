using Moq;
using NUnit.Framework;
using System;
using TestableCodeDemos.Module2.Shared;
using TestableCodeDemos.Project2.After;

namespace TestableCodeDemos.Test.Project2
{
    [TestFixture]
    public class PrintInvoiceCommandTest
    {
        IPrintInvoiceCommand _invoicePrinter;
         Mock<IDatabase> _database;
        Mock<IPrinter> _printer;
        Mock<IDateTimeWrapper> _date;
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

            _database = new Mock<IDatabase>();
            _printer = new Mock<IPrinter>();
            _date = new Mock<IDateTimeWrapper>();

            _database
                .Setup(p => p.GetInvoice(invoiceId))
                .Returns(_invoice);

            _date
                .Setup(p => p.GetNow())
                .Returns(new System.DateTime());

            _invoicePrinter = new NewPrintInvoiceCommand(_database.Object, _printer.Object, _date.Object);
        }

        [Test]
        public void Executes_should_print_invoice_number()
        {
            _invoicePrinter.Execute(invoiceId);
            _printer.Verify(p => p.WriteLine("Invoice ID: 1")
            , Times.Once);         
        }

        [Test]
        public void Executes_should_print_invoice_total()
        {
            _invoicePrinter.Execute(invoiceId);
            _printer.Verify(p => p.WriteLine("Total: $200.0")
            , Times.Once);
        }

        [Test]
        public void Executes_should_call_datetimes_getwrapper()
        {
            _invoicePrinter.Execute(invoiceId);
            _date.Verify(p => p.GetNow()
            , Times.Once);
        }
        [Test]
        public void Executes_should_print_date()
        {
            _invoicePrinter.Execute(invoiceId);
            _printer.Verify(p => p.WriteLine("Printed: " + DateTime.MinValue.ToShortDateString())
            , Times.Once);
        }
    }
}
