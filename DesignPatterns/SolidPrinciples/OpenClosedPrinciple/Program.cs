using OpenClosedPrinciple.Example1;
using OpenClosedPrinciple.Example2;
using System;

namespace OpenClosedPrinciple
{
    class Program
    {
        static void Main()
        {
            var cookBob1 = new Cook1("Bob");
            cookBob1.MakeDinner();
            Console.ReadLine();

            // Применение паттерна Стратегия (Strategy) для реализации Принципа Открытости/Закрытости (Open/Closed Principle).
            var cookBob2 = new Cook2("Bob");
            cookBob2.MakeDinner(new PotatoMeal2());
            Console.WriteLine();
            cookBob2.MakeDinner(new SaladMeal2());
            Console.ReadLine();

            // Применение паттерна Шаблонный Метод (Template Method) для реализации Принципа Открытости/Закрытости (Open/Closed Principle).
            var meals = new Meal[] { new PotatoMeal3(), new SaladMeal3() };
            Cook3 cookBob3 = new Cook3("Bob");
            cookBob3.MakeDinner(meals);
            Console.ReadLine();
        }
    }
}
