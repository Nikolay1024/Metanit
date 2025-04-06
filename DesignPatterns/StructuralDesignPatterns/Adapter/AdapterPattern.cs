namespace Adapter.Pattern
{
    // Структурные паттерны: адаптер (adapter).
    // Когда надо применять паттерн:
    // 1. Когда необходимо использовать имеющийся класс, но его интерфейс не соответствует потребностям.
    // 2. Когда надо использовать уже существующий класс совместно с другими классами, интерфейсы которых не совместимы.

    // Класс, к которому надо адаптировать другой класс.
    class Target
    {
        public virtual void Request() { }
    }

    // Адаптируемый класс.
    class Adaptable
    {
        public void SpecificRequest() { }
    }

    // Адаптер.
    class Adapter : Target
    {
        Adaptable Adaptable = new Adaptable();

        public override void Request() => Adaptable.SpecificRequest();
    }

    class Client
    {
        public void Request(Target target) => target.Request();
    }
}
