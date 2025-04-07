using Prototype.DeepCopyExample;
using Prototype.Example;
using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Prototype");
            Prototype();
            PrototypeDeepCopy();
        }

        static void Prototype()
        {
            Console.WriteLine("-> Prototype без глубокого копирования");
            
            IFigure1 rectangle = new Rectangle1(30, 40);
            IFigure1 clonedRectangle = rectangle.Clone();
            rectangle.GetInfo();
            clonedRectangle.GetInfo();

            IFigure1 circle = new Circle1(30);
            IFigure1 clonedCircle = circle.Clone();
            circle.GetInfo();
            clonedCircle.GetInfo();

            Console.ReadLine();
        }

        static void PrototypeDeepCopy()
        {
            Console.WriteLine("-> Prototype с глубоким копированием");

            var circle = new Circle2(30, 50, 60);
            // Применяем глубокое копирование.
            var clonedCircle = circle.DeepCopy() as Circle2;
            circle.Point.X = 100;
            circle.GetInfo();
            clonedCircle.GetInfo();

            Console.ReadLine();
        }
    }
}
