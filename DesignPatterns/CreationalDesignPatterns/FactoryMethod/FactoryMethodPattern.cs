namespace FactoryMethod.Pattern
{
    // Порождающие паттерны: фабричный метод (factory method).
    // Когда надо применять паттерн:
    // 1. Когда заранее неизвестно, объекты каких типов необходимо создавать.
    // 2. Когда система должна быть независимой от процесса создания новых объектов и расширяемой:
    // в нее можно легко вводить новые классы, объекты которых система должна создавать.
    // 3. Когда создание новых объектов необходимо делегировать из базового класса классам наследникам.
    abstract class Product { }

    class ConcreteProductA : Product { }

    class ConcreteProductB : Product { }

    abstract class Creator
    {
        // Фабричный метод.
        public abstract Product FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod() => new ConcreteProductA();
    }

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod() => new ConcreteProductB();
    }

    class Client
    {
        public void UseFactoryMethodPattern()
        {
            Creator creatorA = new ConcreteCreatorA();
            Product productA = creatorA.FactoryMethod();
            Creator creatorB = new ConcreteCreatorB();
            Product productB = creatorB.FactoryMethod();
        }
    }
}
