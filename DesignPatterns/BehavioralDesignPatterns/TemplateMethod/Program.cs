using System;
using TemplateMethod.Example;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School();
            var university = new University();
            school.Learn();
            university.Learn();

            Console.ReadLine();
        }
    }
}
