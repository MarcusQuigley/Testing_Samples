using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Project1.After
{
    public interface IParts
    {
        decimal GetParts(decimal price);
    }
   public class Parts : IParts
    {
        public decimal GetParts(decimal price)
        {
            return price;
        }

        
    }
}
