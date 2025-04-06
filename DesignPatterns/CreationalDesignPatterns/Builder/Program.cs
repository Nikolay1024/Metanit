using Builder.Example;
using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Содаем объект пекаря.
            var baker = new Baker();
            
            // Создаем билдер для ржаного хлеба.
            BreadBuilder breadBuilder = new RyeBreadBuilder();
            // Выпекаем.
            Bread ryeBread = baker.Bake(breadBuilder);
            Console.WriteLine(ryeBread.ToString());
            
            // Cоздаем билдер для пшеничного хлеба.
            breadBuilder = new WheatBreadBuilder();
            // Выпекаем.
            Bread wheatBread = baker.Bake(breadBuilder);
            Console.WriteLine(wheatBread.ToString());

            Console.ReadLine();
        }
    }
}
