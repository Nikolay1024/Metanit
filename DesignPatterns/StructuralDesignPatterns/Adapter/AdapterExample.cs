using System;

namespace Adapter.Example
{
    // Интерфейс транспорта.
    interface ITransport
    {
        void Drive();
    }
    // Класс машины.
    class Auto : ITransport
    {
        public void Drive() => Console.WriteLine("Машина едет по дороге");
    }

    // Интерфейс животного.
    interface IAnimal
    {
        void Move();
    }
    // Класс верблюда.
    class Camel : IAnimal
    {
        public void Move() => Console.WriteLine("Верблюд идет по пескам пустыни");
    }

    // Адаптер от Camel к ITransport
    class CamelToTransportAdapter : ITransport
    {
        Camel Camel;
        
        public CamelToTransportAdapter(Camel camel) => Camel = camel;

        public void Drive() => Camel.Move();
    }

    // Класс путешественника.
    class Traveler
    {
        public void Travel(ITransport transport) => transport.Drive();
    }
}
