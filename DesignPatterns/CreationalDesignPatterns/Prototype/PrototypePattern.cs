namespace Prototype.Pattern
{
    // Порождающие паттерны: прототип (prototype).
    // Когда надо применять паттерн:
    // 1. Когда конкретный тип создаваемого объекта должен определяться динамически во время выполнения.
    // 2. Когда нежелательно создание отдельной иерархии классов фабрик для создания объектов-продуктов из параллельной иерархии классов
    // (как это делается, например, при использовании паттерна абстрактная фабрика).
    // 3. Когда клонирование объекта является более предпочтительным вариантом нежели его создание и инициализация с помощью конструктора.
    // Особенно когда известно, что объект может принимать небольшое ограниченное число возможных состояний.
    abstract class Prototype
    {
        public int Id { get; private set; }

        public Prototype(int id) => Id = id;

        public abstract Prototype Clone();
    }

    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id) { }
        
        public override Prototype Clone() => new ConcretePrototype1(Id);
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id) { }

        public override Prototype Clone() => new ConcretePrototype2(Id);
    }

    class Client
    {
        public void UsePrototypePattern()
        {
            Prototype prototype1 = new ConcretePrototype1(1);
            Prototype clonePrototype1 = prototype1.Clone();
            Prototype prototype2 = new ConcretePrototype2(2);
            Prototype clonePrototype2 = prototype2.Clone();
        }
    }
}
