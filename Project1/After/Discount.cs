using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Project1.After
{
   

    public interface IDiscount
    {
        decimal GetDiscount(decimal argument);

    }
    public class Discount : IDiscount
    {
        public decimal GetDiscount(decimal argument)
        {
            return argument;
        }
    }
}
