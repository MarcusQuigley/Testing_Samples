using System;
using System.Collections.Generic;
using System.Linq;
using TestableCodeDemos.Project1.After;

namespace TestableCodeDemos.Module1.Hard
{
    class Program
    {
        static void Main(string[] args)
        {

            var parts = decimal.Parse(args[0]);

            var service = decimal.Parse(args[1]);

            var discount = decimal.Parse(args[2]);

            var total = parts + service - discount;

            Console.WriteLine("Total Price: $" + total);
        }

        static void NewMain(string[] args, ICalculator calculator, IParts parts, IService service, IDiscount discount)
        {
            var p = parts.GetParts(Decimal.Parse(args[0]));

            var s = service.GetService(Decimal.Parse(args[1]));

            var d = discount.GetDiscount(Decimal.Parse(args[2]));

            var total = calculator.GetTotal(p,s, d );

            Console.WriteLine("Total testy Price: $" + total);
        }
    }
}
