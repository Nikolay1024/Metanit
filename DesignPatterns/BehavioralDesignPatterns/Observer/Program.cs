using Observer.Example;
using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock();
            var bank = new Bank("ЮнитБанк", stock);
            var broker = new Broker("Иван Иваныч", stock);
            // Имитация торгов.
            stock.Market();
            // Брокер прекращает наблюдать за торгами.
            broker.StopTrade();
            // Имитация торгов.
            stock.Market();

            Console.ReadLine();
        }
    }
}
