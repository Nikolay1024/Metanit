using State.Example;
using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var water = new Water(new LiquidWaterState());
            // Нагрели воду, получили пар.
            water.Heat();
            // Заморозили пар, получили воду.
            water.Frost();
            // Заморозили воду, получили лед.
            water.Frost();

            Console.ReadLine();
        }
    }
}
