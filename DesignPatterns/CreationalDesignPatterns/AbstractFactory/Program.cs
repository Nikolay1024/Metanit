using AbstractFactory.Example;
using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero warrior = new Hero(new WarriorFactory());
            warrior.Run();
            warrior.Hit();

            Hero archer = new Hero(new ArcherFactory());
            archer.Run();
            archer.Hit();

            Console.ReadLine();
        }
    }
}
