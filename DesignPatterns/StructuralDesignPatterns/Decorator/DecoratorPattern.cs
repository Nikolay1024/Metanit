namespace Decorator.Pattern
{
    // Структурные паттерны: декоратор (decorator).
    // Когда надо применять паттерн:
    // 1. Когда надо динамически добавлять к объекту новые функциональные возможности. При этом данные возможности могут быть сняты с объекта.
    // 2. Когда применение наследования неприемлемо. Например, если нам надо определить множество различных функциональностей и
    // для каждой функциональности наследовать отдельный класс, то структура классов может очень сильно разрастись.
    // Еще больше она может разрастись, если нам необходимо создать классы, реализующие все возможные сочетания добавляемых функциональностей.
    abstract class Component
    {
        public abstract void Operation();
    }
    class ConcreteComponent : Component
    {
        public override void Operation() { }
    }

    abstract class Decorator : Component
    {
        protected Component Component;

        public void SetComponent(Component component) => Component = component;
        public override void Operation() => Component?.Operation();
    }
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation() => base.Operation();
    }
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation() => base.Operation();
    }
}
