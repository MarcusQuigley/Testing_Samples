using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableCodeDemos.Module6.Shared;
namespace TestableCodeDemos.Project6.After
{
  public abstract  class BaseInvoiceCommand
    {
        private readonly IDatabase _database;
        public BaseInvoiceCommand(IDatabase database)
        {
            _database = database;
        }

       // public  void Execute()
    }
}
