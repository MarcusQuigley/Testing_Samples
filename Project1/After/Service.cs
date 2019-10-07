using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Project1.After
{
  

    public interface IService
    {
        decimal GetService(decimal price);

    }
    public class Service : IService
    {
      public  decimal GetService(decimal price)
        {
            return price;
        }
    }
}
