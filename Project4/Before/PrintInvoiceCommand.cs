using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Module4.Shared;
using TestableCodeDemos.Project4.After;

namespace TestableCodeDemos.Module4.Before
{
    public class PrintInvoiceCommand : IPrintInvoiceCommand
    {
        private readonly Container _container;
        readonly IDatabase _database;
        readonly IInvoiceWriter _invoiceWriter;
        readonly ISession _session;
        readonly IUser _user;

        public PrintInvoiceCommand(IDatabase database, 
                                   IInvoiceWriter invoiceWriter, 
                                   ISession session,
                                   IUser user)
        {
            _database = database;
            _invoiceWriter = invoiceWriter;
            _session = session;
            _user = user;
        }

        public void Execute(int invoiceId)
        {
            var invoice = _database.GetInvoice(invoiceId);

            _invoiceWriter.Write(invoice);
            //invoice.LastPrintedBy = _session.GetLogin().GetUser().GetUserName();
            invoice.LastPrintedBy = _user.GetUserName();


            _database.Save();

            //var invoice = _container
            //    .Get<IDatabase>()
            //    .GetInvoice(invoiceId);

            //_container.Get<IInvoiceWriter>()
            //    .Write(invoice);

            //invoice.LastPrintedBy = _container
            //    .Get<ISession>()
            //    .GetLogin()
            //    .GetUser()
            //    .GetUserName();

            //_container
            //    .Get<IDatabase>()
            //    .Save();
        }
    }
}