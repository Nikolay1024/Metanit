using System.Collections.Generic;

namespace Observer.Pattern
{
    // Паттерны поведения: наблюдатель / издатель-подписчик (observer / publisher-subscriber).
    // Когда надо применять паттерн:
    // 1. Когда система состоит из множества классов, объекты которых должны находиться в согласованных состояниях.
    // 2. Когда общая схема взаимодействия объектов предполагает две стороны: одна рассылает сообщения и является главной,
    // а другая получает сообщения и реагирует на них.
    // Отделение логики обеих сторон позволяет их рассматривать независимо и использовать отдельно друга от друга.
    // 3. Когда существует один объект, рассылающий сообщения, и множество подписчиков, которые получают сообщения.
    // При этом точное число подписчиков заранее неизвестно и в процессе работы программы может изменяться.
    interface IObserver
    {
        void Notify();
    }

    class ConcreteObserver : IObserver
    {
        public void Notify() { }
    }

    interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    class ConcreteObservable : IObservable
    {
        List<IObserver> Observers = new List<IObserver>();

        public void AddObserver(IObserver observer) => Observers.Add(observer);
        public void RemoveObserver(IObserver observer) => Observers.Remove(observer);
        public void NotifyObservers()
        {
            foreach (IObserver observer in Observers)
                observer.Notify();
        }
    }
}
