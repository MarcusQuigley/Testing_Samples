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

        static void NewMain(string[] args, ICalculator calculator)
        {
            var parts = decimal.Parse(args[0]);

            var service = decimal.Parse(args[1]);

            var discount = decimal.Parse(args[2]);

            var total = calculator.GetTotal(parts,service,discount);

            Console.WriteLine("Total testy Price: $" + total);
        }
    }
}
