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
            Example.IFigure figure = new Example.Rectangle(30, 40);
            Example.IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Example.Circle(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.ReadLine();
        }

        static void PrototypeDeepCopy()
        {
            Console.WriteLine("-> Prototype с глубоким копированием");
            var figure = new DeepCopyExample.Circle(30, 50, 60);
            // Применяем глубокое копирование.
            var clonedFigure = figure.DeepCopy() as DeepCopyExample.Circle;
            figure.Point.X = 100;
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.ReadLine();
        }
    }
}
