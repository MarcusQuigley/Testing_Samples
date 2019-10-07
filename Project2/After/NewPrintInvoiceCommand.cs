namespace TestableCodeDemos.Project2.After
{
    public class NewPrintInvoiceCommand : IPrintInvoiceCommand
    {
        readonly IDatabase _database;
        readonly IPrinter _printer;
        readonly IDateTimeWrapper _datetime;
        public NewPrintInvoiceCommand(IDatabase database, IPrinter printer, IDateTimeWrapper datetime)
        {
            _database = database;
            _printer = printer;
            _datetime = datetime;
        }
        public void Execute(int invoiceId)
        {
            var invoice = _database.GetInvoice(invoiceId);
            _printer.WriteLine("Invoice ID: " + invoice.Id);
            _printer.WriteLine("Total: $" + invoice.Total);

            var dateTime = _datetime.GetNow();

            _printer.WriteLine("Printed: " + dateTime.ToShortDateString());
        }
    }
}
