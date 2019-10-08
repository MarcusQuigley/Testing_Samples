using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Project4.After
{
   public interface IPrintInvoiceCommand
    {
        void Execute(int invoiceId);
    }
}
