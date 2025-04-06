using System.Collections.Generic;
using System;

namespace Memento.Example
{
    // Хранитель (Memento).
    class HeroMemento
    {
        public int Ammo { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int ammo, int lives)
        {
            Ammo = ammo;
            Lives = lives;
        }
    }

    // Смотритель (Caretaker).
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; } = new Stack<HeroMemento>();
    }

    // Создатель (Originator).
    class Hero
    {
        // Кол-во патронов.
        int Ammo = 10;
        // Кол-во жизней.
        int Lives = 5;

        public void Shoot()
        {
            if (Ammo > 0)
                Console.WriteLine($"Производим выстрел. Осталось {--Ammo} патронов.");
            else
                Console.WriteLine("Патронов больше нет.");
        }
        // Сохранение состояния.
        public HeroMemento SaveState()
        {
            Console.WriteLine($"Сохранение игры. Параметры: {Ammo} патронов, {Lives} жизней.");
            return new HeroMemento(Ammo, Lives);
        }
        // Восстановление состояния.
        public void RestoreState(HeroMemento heroMemento)
        {
            Ammo = heroMemento.Ammo;
            Lives = heroMemento.Lives;
            Console.WriteLine($"Загрузка сохранения. Параметры: {Ammo} патронов, {Lives} жизней.");
        }
    }
}
