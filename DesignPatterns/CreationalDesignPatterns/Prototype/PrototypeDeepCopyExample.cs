using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Prototype.DeepCopyExample
{
    [Serializable]
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

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

        public IFigure Clone() => MemberwiseClone() as IFigure;
        public void GetInfo() => Console.WriteLine($"Прямоугольник длиной {Height} и шириной {Width}.");
    }

    [Serializable]
    class Circle : IFigure
    {
        int Radius;
        public Point Point { get; set; }

        public Circle(int radius, int x, int y)
        {
            Radius = radius;
            Point = new Point() { X = x, Y = y };
        }

        // Поверхностная копия копирует поля значимых типов, а для полей ссылочных типов копируются ссылки.
        public IFigure Clone() => MemberwiseClone() as IFigure;
        // Глубокая копия копирует поля значимых типов и для полей ссылочных типов создает глубокие копии объектов.
        public object DeepCopy()
        {
            object figure = null;
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));

                binaryFormatter.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);

                figure = binaryFormatter.Deserialize(memoryStream);
            }
            return figure;
        }
        public void GetInfo() => Console.WriteLine($"Круг радиусом {Radius} и центром в точке ({Point.X}, {Point.Y})");
    }
}
