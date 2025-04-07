using System;

namespace Strategy.Example
{
    interface IMovable
    {
        void Move();
    }

    class PetrolMove : IMovable
    {
        public void Move() => Console.WriteLine("Перемещение на бензине.");
    }

    class ElectricMove : IMovable
    {
        public void Move() => Console.WriteLine("Перемещение на электричестве.");
    }

    class Car
    {
        // Кол-во пассажиров.
        int Passengers;
        // Модель автомобиля.
        string Model;
        public IMovable Movable { private get; set; }

        public Car(int passengers, string model, IMovable movable)
        {
            Passengers = passengers;
            Model = model;
            Movable = movable;
        }

        public void Move() => Movable.Move();
    }
}
