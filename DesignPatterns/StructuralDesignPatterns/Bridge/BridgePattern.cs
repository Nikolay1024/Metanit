namespace Bridge.Pattern
{
    // Структурные паттерны: мост (bridge).
    // Когда надо применять паттерн:
    // 1. Когда надо избежать постоянной привязки абстракции к реализации.
    // 2. Когда наряду с реализацией надо изменять и абстракцию независимо друг от друга.
    // То есть изменения в абстракции не должно привести к изменениям в реализации.
    
    // Реализация.
    abstract class Implementor
    {
        public abstract void OperationImp();
    }
    class ConcreteImplementorA : Implementor
    {
        public override void OperationImp() { }
    }
    class ConcreteImplementorB : Implementor
    {
        public override void OperationImp() { }
    }

    // Абстракция.
    abstract class Abstraction
    {
        public Implementor Implementor { protected get; set; }

        public Abstraction(Implementor implementor) => Implementor = implementor;

        public virtual void Operation() => Implementor.OperationImp();
    }
    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor implementor) : base(implementor) { }

        public override void Operation() { }
    }

    class Client
    {
        static void UseBridgePattern()
        {
            Abstraction abstraction = new RefinedAbstraction(new ConcreteImplementorA());
            abstraction.Operation();
            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.Operation();
        }
    }
}
