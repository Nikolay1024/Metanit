using Strategy.Example;
using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(4, "Volvo", new PetrolMove());
            car.Move();
            car.Movable = new ElectricMove();
            car.Move();

            Console.ReadLine();
        }
    }
}
