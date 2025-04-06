using Adapter.Example;
using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Путешественник.
            var traveler = new Traveler();
            // Машина.
            var auto = new Auto();
            // Отправляемся в путешествие.
            traveler.Travel(auto);
            // Встретились пески, надо использовать верблюда.
            var camel = new Camel();
            // Используем адаптер.
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            // Продолжаем путь по пескам пустыни.
            traveler.Travel(camelTransport);

            Console.ReadLine();
        }
    }
}
