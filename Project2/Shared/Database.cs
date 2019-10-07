using TestableCodeDemos.Project2.After;

namespace TestableCodeDemos.Module2.Shared
{
    public class Database : IDatabase
    {
        public Invoice GetInvoice(int invoiceId)
        {
            return new Invoice() { Id = invoiceId, Total = 200.0m };
        }
    }
}