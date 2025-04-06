using Memento.Example;
using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var hero = new Hero();

            // Делаем выстрел, осталось 9 патронов.
            hero.Shoot();

            // Сохраняем игру.
            var gameHistory = new GameHistory();
            HeroMemento heroMemento = hero.SaveState();
            gameHistory.History.Push(heroMemento);

            // Делаем выстрел, осталось 8 патронов.
            hero.Shoot();

            // Загружаем игру.
            heroMemento = gameHistory.History.Pop();
            hero.RestoreState(heroMemento);

            // Делаем выстрел, осталось 8 патронов.
            hero.Shoot();

            Console.ReadLine();
        }
    }
}
