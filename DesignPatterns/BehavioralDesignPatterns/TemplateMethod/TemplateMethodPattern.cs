namespace TemplateMethod.Pattern
{
    // Паттерны поведения: шаблонный метод (template method).
    // Когда надо применять паттерн:
    // 1. Когда планируется, что в будущем подклассы должны будут переопределять различные этапы алгоритма без изменения его структуры.
    // 2. Когда в классах, реализующим схожий алгоритм, происходит дублирование кода.
    // Вынесение общего кода в шаблонный метод уменьшит его дублирование в подклассах.
    abstract class AbstractClass
    {
        public abstract void Operation1();
        public abstract void Operation2();
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
        }
    }

    class ConcreteClass : AbstractClass
    {
        public override void Operation1() { }
        public override void Operation2() { }
    }
}
