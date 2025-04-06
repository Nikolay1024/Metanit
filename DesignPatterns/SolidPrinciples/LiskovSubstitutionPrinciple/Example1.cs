namespace LiskovSubstitutionPrinciple.Example1
{
    // SOLID. L - Принцип Подстановки Лисков (Liskov Substitution Principle) можно сформулировать так:
    // Должна быть возможность вместо базового типа подставить любой его подтип.
    // Фактически принцип подстановки Лисков помогает четче сформулировать иерархию классов, определить функционал для базовых и производных
    // классов и избежать возможных проблем при применении наследования и полиморфизма.
    class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea() => Width * Height;
    }

    class Square : Rectangle
    {
        public override int Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override int Height
        {
            get => base.Height;
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}
