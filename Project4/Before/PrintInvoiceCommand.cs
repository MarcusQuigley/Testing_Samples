using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module4.Shared;
using TestableCodeDemos.Project4.After;

namespace TestableCodeDemos.Module4.Before
{
    public class PrintInvoiceCommand : IPrintInvoiceCommand
    {
        readonly IDatabase _database;
        readonly IInvoiceWriter _invoiceWriter;
        readonly IUser _user;

        public PrintInvoiceCommand(
            IDatabase database,
            IInvoiceWriter invoiceWriter,
            IUser user)
        {
            _database = database;
            _invoiceWriter = invoiceWriter;
            _user = user;
        }

        public void Execute(int invoiceId)
        {
            var invoice = _database.GetInvoice(invoiceId);

            _invoiceWriter.Write(invoice);
            invoice.LastPrintedBy = _user.GetUserName();
            _database.Save();
        }
    }
}