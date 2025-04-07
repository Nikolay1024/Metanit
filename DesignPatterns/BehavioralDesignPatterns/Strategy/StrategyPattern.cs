namespace Strategy.Pattern
{
    // Паттерны поведения: стратегия (strategy).
    // Когда надо применять паттерн:
    // 1. Когда есть несколько родственных классов, которые отличаются поведением. Можно задать один основной класс, а разные варианты поведения
    // вынести в отдельные классы и при необходимости их применять.
    // 2. Когда необходимо обеспечить выбор из нескольких вариантов алгоритмов, которые можно легко менять в зависимости от условий.
    // 3. Когда необходимо менять поведение объектов на стадии выполнения программы.
    // 4. Когда класс, применяющий определенную функциональность, ничего не должен знать о ее реализации.
    interface IStrategy
    {
        void Algorithm();
    }
    class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm() { }
    }
    class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm() { }
    }

    class Client
    {
        IStrategy Strategy { get; set; }

        public Client(IStrategy strategy) => Strategy = strategy;

        public void ExecuteAlgorithm() => Strategy.Algorithm();
    }
}
