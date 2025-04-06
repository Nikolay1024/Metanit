using FactoryMethod.Example;
using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer developer = new PanelDeveloper("ООО КирпичСтрой");
            House house1 = developer.Create();
            Console.WriteLine(house1.GetType().Name);

            developer = new WoodDeveloper("Частный застройщик");
            House house2 = developer.Create();
            Console.WriteLine(house2.GetType().Name);

            Console.ReadLine();
        }
    }
}
