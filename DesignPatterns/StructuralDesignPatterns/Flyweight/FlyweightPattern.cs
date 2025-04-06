using System.Collections.Generic;

namespace Flyweight.Pattern
{
    // Структурные паттерны: приспособленец (flyweight).
    // Когда надо применять паттерн:
    // 1. Когда приложение использует большое количество однообразных объектов, из-за чего происходит выделение большого количества памяти.
    // 2. Когда часть состояния объекта, которое является изменяемым, можно вынести во вне. Вынесение внешнего состояния позволяет заменить
    // множество объектов небольшой группой общих разделяемых объектов.
    abstract class Flyweight
    {
        public abstract void Operation(int externalState);
    }
    class ConcreteFlyweight : Flyweight
    {
        int InternalState;

        public override void Operation(int externalState) { }
    }
    class UnsharedConcreteFlyweight : Flyweight
    {
        int AllState;

        public override void Operation(int externalState) => AllState = externalState;
    }

    class FlyweightFactory
    {
        Dictionary<string, Flyweight> Flyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            Flyweights.Add("X", new ConcreteFlyweight());
            Flyweights.Add("Y", new ConcreteFlyweight());
            Flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            if (!Flyweights.ContainsKey(key))
                Flyweights.Add(key, new ConcreteFlyweight());
            Flyweight flyweight = Flyweights[key];
            return flyweight;
        }
    }

    class Client
    {
        void UseFlyweightPattern()
        {
            int externalState = 22;

            var flyweightFactory = new FlyweightFactory();

            Flyweight flyweightX = flyweightFactory.GetFlyweight("X");
            flyweightX.Operation(--externalState);

            Flyweight flyweightY = flyweightFactory.GetFlyweight("Y");
            flyweightY.Operation(--externalState);

            Flyweight flyweightD = flyweightFactory.GetFlyweight("D");
            flyweightD.Operation(--externalState);

            var unsharedConcreteFlyweight = new UnsharedConcreteFlyweight();

            unsharedConcreteFlyweight.Operation(--externalState);
        }
    }
}
