using System;
using System.Collections.Generic;

namespace Flyweight.Example
{
    // Flyweight.
    abstract class House
    {
        // Количество этажей.
        protected int Stages;

        public abstract void Build(double longitude, double latitude);
    }
    class PanelHouse : House
    {
        public PanelHouse() => Stages = 16;

        public override void Build(double longitude, double latitude) =>
            Console.WriteLine($"Построен панельный дом из 16 этажей. Координаты: {latitude} широты и {longitude} долготы.");
    }
    class BrickHouse : House
    {
        public BrickHouse() => Stages = 5;

        public override void Build(double longitude, double latitude) =>
            Console.WriteLine($"Построен кирпичный дом из 5 этажей. Координаты: {latitude} широты и {longitude} долготы.");
    }

    class HouseFactory
    {
        Dictionary<string, House> Houses = new Dictionary<string, House>();

        public HouseFactory()
        {
            Houses.Add("Panel", new PanelHouse());
            Houses.Add("Brick", new BrickHouse());
        }

        public House GetHouse(string key)
        {
            if (Houses.ContainsKey(key))
                return Houses[key];

            return null;
        }
    }
}
