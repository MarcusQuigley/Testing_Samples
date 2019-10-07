using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableCodeDemos.Module3.Shared;

namespace TestableCodeDemos.Project3.After
{
    public class PrintInvoiceCommand : IPrintInvoiceCommand
    {
        readonly IDatabase _database;
        readonly IInvoiceWriter _invoiceWriter;

        public PrintInvoiceCommand(IDatabase database,
            IInvoiceWriter invoiceWriter)
        {
            _database = database;
            _invoiceWriter = invoiceWriter;
        }

        public void Execute(int invoiceId)
        {
            var invoice = _database.GetInvoice(invoiceId);
            _invoiceWriter.Write(invoice);
        }
    }
}
