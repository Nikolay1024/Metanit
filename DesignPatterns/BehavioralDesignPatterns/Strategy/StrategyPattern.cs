namespace Strategy.Pattern
{
    // Паттерны поведения: стратегия (strategy).
    // Когда надо применять паттерн:
    // Когда есть несколько родственных классов, которые отличаются поведением. Можно задать один основной класс, а разные варианты поведения вынести в отдельные классы и при необходимости их применять.
    // Когда необходимо обеспечить выбор из нескольких вариантов алгоритмов, которые можно легко менять в зависимости от условий.
    // Когда необходимо менять поведение объектов на стадии выполнения программы.
    // Когда класс, применяющий определенную функциональность, ничего не должен знать о ее реализации.
    public interface IStrategy
    {
        void Algorithm();
    }
    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm() { }
    }
    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm() { }
    }

    public class Context
    {
        public IStrategy Strategy { get; set; }

        public Context(IStrategy strategy) => Strategy = strategy;

        public void ExecuteAlgorithm() => Strategy.Algorithm();
    }
}
