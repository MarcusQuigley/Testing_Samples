using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module5.Shared;

namespace TestableCodeDemos.Module5.After
{
    public class PrintInvoiceCommand
    {
        private readonly IDatabase _database;
        private readonly IInvoiceWriter _writer;
        readonly ISecurity _security;

        public PrintInvoiceCommand(
            IDatabase database,
            IInvoiceWriter writer,
            ISecurity security)
        {
            _database = database;
            _writer = writer;
            _security = security;
        }

        public void Execute(int invoiceId)
        {
            var invoice = _database.GetInvoice(invoiceId);

            // var security = Security.GetInstance();

            if (!_security.IsAdmin())
                throw new UserNotAuthorizedException();

            _writer.Print(invoice);

            invoice.LastPrintedBy = _security.GetUserName();

            _database.Save();
        }
    }
}
