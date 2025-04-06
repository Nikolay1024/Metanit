using DependencyInversionPrinciple.Example1;
using System;

namespace DependencyInversionPrinciple
{
    class Program
    {
        static void Main()
        {
            var book2 = new Book2(new ConsolePrinter2());
            book2.Print();
            book2.Printer = new HtmlPrinter2();
            book2.Print();

            Console.ReadLine();
        }
    }
}
