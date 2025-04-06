using Decorator.Example;
using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Итальянская пицца с томатами.
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1);
            Console.WriteLine($"Название: {pizza1.Name}.\nЦена: {pizza1.GetCost()}.");

            // Итальянская пиццы с сыром.
            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);
            Console.WriteLine($"Название: {pizza2.Name}.\nЦена: {pizza2.GetCost()}.");

            // Болгарская пиццы с томатами и сыром.
            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);
            Console.WriteLine($"Название: {pizza3.Name}.\nЦена: {pizza3.GetCost()}.");

            Console.ReadLine();
        }
    }
}
