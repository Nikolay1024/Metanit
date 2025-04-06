using System;

namespace Prototype.Example
{
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int Width;
        int Height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public IFigure Clone() => new Rectangle(Width, Height);
        public void GetInfo() => Console.WriteLine($"Прямоугольник длиной {Height} и шириной {Width}.");
    }

    class Circle : IFigure
    {
        int Radius;

        public Circle(int radius) => Radius = radius;

        public IFigure Clone() => new Circle(Radius);
        public void GetInfo() => Console.WriteLine($"Круг радиусом {Radius}.");
    }
}
