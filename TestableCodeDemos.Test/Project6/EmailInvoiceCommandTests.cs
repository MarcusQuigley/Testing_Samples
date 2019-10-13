using AutoMoq;
using NUnit.Framework;
using TestableCodeDemos.Module6.Shared;
using TestableCodeDemos.Project6.After;

namespace TestableCodeDemos.Test.Project6
{
    [TestFixture]
    public class EmailInvoiceCommandTests
    {
        AutoMoqer _mocker;
        int _invoiceId;
        Invoice _invoice;
        EmailInvoiceCommand _command;
        [SetUp]
        public void Setup()
        {
            _invoiceId = 6;
            _invoice = new Invoice()
            {
                EmailAddress = "marcus@marcus.com"
            };
            _mocker = new AutoMoqer();
            _mocker.GetMock<IDatabase>()
                 .Setup(p => p.GetInvoice(_invoiceId))
                 .Returns(_invoice);

            _command = _mocker.Create<EmailInvoiceCommand>();
        }

        [Test]
        public void calls_email_with_address()
        {
             _command.Execute(_invoiceId);
            _mocker.GetMock<IInvoiceEmailer>()
                   .Verify(p => p.Email(_invoice));
        }

        [Test]
        public void throws_exception_with_empty_address()
        {
            _invoice.EmailAddress = string.Empty;
       
            Assert.That(() => _command.Execute(_invoiceId),
                Throws.TypeOf<EmailAddressIsBlankException>());
        }
    }
}
