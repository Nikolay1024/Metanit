using AbstractFactory.Example;
using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero warrior = new Hero(new WarriorFactory());
            warrior.Move();
            warrior.Hit();

            Hero archer = new Hero(new ArcherFactory());
            archer.Move();
            archer.Hit();

            Console.ReadLine();
        }
    }
}
