namespace AbstractFactory.Pattern
{
    // Порождающие паттерны: абстрактная фабрика (abstract factory).
    // Когда надо применять паттерн:
    // 1. Когда система не должна зависеть от способа создания и компоновки новых объектов.
    // 2. Когда создаваемые объекты должны использоваться вместе и являются взаимосвязанными.
    abstract class AbstractProductA { }
    abstract class AbstractProductB { }

    class ProductA1 : AbstractProductA { }
    class ProductA2 : AbstractProductA { }
    class ProductB1 : AbstractProductB { }
    class ProductB2 : AbstractProductB { }

    // Абстрактная фабрика.
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }
    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA() => new ProductA1();
        public override AbstractProductB CreateProductB() => new ProductB1();
    }
    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA() => new ProductA2();
        public override AbstractProductB CreateProductB() => new ProductB2();
    }

    class Client
    {
        AbstractProductA AbstractProductA;
        AbstractProductB AbstractProductB;

        public Client(AbstractFactory abstractFactory)
        {
            AbstractProductA = abstractFactory.CreateProductA();
            AbstractProductB = abstractFactory.CreateProductB();
        }

        public void Run() { }
    }
}
