using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableCodeDemos.Project1.After
{
    public interface ICalculator
    {
        decimal GetTotal(decimal parts, decimal service, decimal discount);
    }

    public class Calculator : ICalculator
    {
        public decimal GetTotal(decimal parts, decimal service, decimal discount)
        {
            return parts +service - discount;
        }
    }
}
