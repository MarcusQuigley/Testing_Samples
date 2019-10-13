using AutoMoq;
using Moq;
using NUnit.Framework;
using TestableCodeDemos.Module6.Shared;
using TestableCodeDemos.Project6;

namespace TestableCodeDemos.Test.Project6
{
    [TestFixture]
  public  class PrintInvoiceCommandTests
    {
        AutoMoqer _mocker;
        int _invoiceId;
        Invoice _invoice;
        PrintInvoiceCommand _command;

        [SetUp]
        public void Setup()
        {
            _invoiceId = 6;
            _invoice = new Invoice();
            _mocker = new AutoMoqer();
            _mocker.GetMock<IDatabase>()
                   .Setup(p => p.GetInvoice(_invoiceId))
                   .Returns(_invoice);
            _mocker.GetMock<ISecurity>()
                   .Setup(p => p.IsAdmin())
                   .Returns(true);
            _mocker.GetMock<IInvoiceWriter>()
                   .Setup(p => p.Print(_invoice));

            _command = _mocker.Create<PrintInvoiceCommand>();
        }

        [Test]
        public void Exception_thrown_if_not_admin()
        {
            _mocker.GetMock<ISecurity>()
                               .Setup(p => p.IsAdmin())
                               .Returns(false);
            Assert.That(()=>_command.Execute(_invoiceId),
                Throws.InstanceOf<UserNotAuthorizedException>());
        }

        [Test]
        public void Save_called()
        {
            _command.Execute(_invoiceId);
             _mocker.GetMock<IDatabase>()
                   .Verify(p => p.Save(), Times.Once);
         }

        [Test]
        public void LastPrintedBy_equals()
        {
            string userName = "marcus";
            _mocker.GetMock<ISecurity>()
                   .Setup(p => p.GetUserName())
                   .Returns(userName);
            _command.Execute(_invoiceId);

            Assert.That(_invoice.LastPrintedBy, Is.EqualTo(userName));

        }
    }
}
