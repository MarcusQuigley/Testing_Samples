using System;

namespace TestableCodeDemos.Project2.After
{
    public interface IPrinter
    {
        void WriteLine(string arg);
    }
    public class Printer : IPrinter
    {
        public void WriteLine(string arg)
        {
            Console.WriteLine(arg);
        }
    }
}
