using TestableCodeDemos.Module2.Shared;

namespace TestableCodeDemos.Project2.After
{
    public interface IDatabase
    {
        Invoice GetInvoice(int invoiceId);
    }
}
