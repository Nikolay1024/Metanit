using System.Collections.Generic;
using System;

namespace Observer.Example
{
    interface IObserver
    {
        void Notify(StockInfo stockInfo);
    }

    // Брокер (класс наблюдателя).
    class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable Stock;

        public Broker(string name, IObservable stock)
        {
            Name = name;
            Stock = stock;
            Stock.AddObserver(this);
        }

        public void Notify(StockInfo stockInfo)
        {
            if (stockInfo.USD > 30)
                Console.WriteLine($"Брокер {Name} продает доллары. Курс доллара: {stockInfo.USD}.");
            else
                Console.WriteLine($"Брокер {Name} покупает доллары. Курс доллара: {stockInfo.USD}.");
        }
        public void StopTrade()
        {
            Stock.RemoveObserver(this);
            Stock = null;
        }
    }

    // Банк (класс наблюдателя).
    class Bank : IObserver
    {
        public string Name { get; set; }
        IObservable Stock;

        public Bank(string name, IObservable stock)
        {
            Name = name;
            Stock = stock;
            Stock.AddObserver(this);
        }

        public void Notify(StockInfo stockInfo)
        {
            if (stockInfo.Euro > 40)
                Console.WriteLine($"Банк {Name} продает евро. Курс евро: {stockInfo.Euro}.");
            else
                Console.WriteLine($"Банк {Name} покупает евро. Курс евро: {stockInfo.Euro}.");
        }
    }

    interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    // Валютные курсы.
    class StockInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }

    // Валютнаю биржа (класс, над которым ведется наблюдение).
    class Stock : IObservable
    {
        // Информация о торгах.
        StockInfo StockInfo = new StockInfo();
        List<IObserver> Observers = new List<IObserver>();

        public void AddObserver(IObserver observer) => Observers.Add(observer);
        public void RemoveObserver(IObserver observer) => Observers.Remove(observer);
        public void NotifyObservers()
        {
            foreach (IObserver observer in Observers)
                observer.Notify(StockInfo);
        }
        public void Market()
        {
            var random = new Random();
            StockInfo.USD = random.Next(20, 40);
            StockInfo.Euro = random.Next(30, 50);
            NotifyObservers();
        }
    }
}
