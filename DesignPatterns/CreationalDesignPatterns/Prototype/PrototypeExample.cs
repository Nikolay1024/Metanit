using System;

namespace Prototype.Example
{
    interface IFigure1
    {
        IFigure1 Clone();
        void GetInfo();
    }

    class Rectangle1 : IFigure1
    {
        int Width;
        int Height;

        public Rectangle1(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public IFigure1 Clone() => new Rectangle1(Width, Height);
        public void GetInfo() => Console.WriteLine($"Прямоугольник длиной {Height} и шириной {Width}.");
    }

    class Circle1 : IFigure1
    {
        int Radius;

        public Circle1(int radius) => Radius = radius;

        public IFigure1 Clone() => new Circle1(Radius);
        public void GetInfo() => Console.WriteLine($"Круг радиусом {Radius}.");
    }
}
