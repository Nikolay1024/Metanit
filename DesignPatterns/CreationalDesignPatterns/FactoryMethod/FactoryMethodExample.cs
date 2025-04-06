using System;

namespace FactoryMethod.Example
{
    abstract class House { }

    class PanelHouse : House
    {
        public PanelHouse() => Console.WriteLine("Панельный дом построен");
    }
    class WoodHouse : House
    {
        public WoodHouse() => Console.WriteLine("Деревянный дом построен");
    }

    // Абстрактный класс строительной компании.
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string name) => Name = name;
        
        // Фабричный метод.
        abstract public House Create();
    }
    
    // Строит панельные дома.
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name) : base(name) { }

        public override House Create() => new PanelHouse();
    }
    
    // Строит деревянные дома.
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name) : base(name) { }

        public override House Create() => new WoodHouse();
    }
}
