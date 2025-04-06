namespace ChainOfResponsibility.Pattern
{
    // Паттерны поведения: цепочка обязанностей (chain of responsibility).
    // Когда надо применять паттерн:
    // 1. Когда имеется более одного объекта, который может обработать определенный запрос.
    // 2. Когда надо передать запрос на выполнение одному из нескольких объектов.
    // 3. Когда набор объектов, выполняющих запрос, задается динамически.
    abstract class Handler
    {
        public Handler Successor { get; set; }

        public abstract void HandleRequest(int condition);
    }

    class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int condition)
        {
            // Некоторая обработка запроса.

            if (condition == 1)
            {
                // Завершение выполнения запроса.
            }
            // Передача запроса дальше по цепи при наличии в ней обработчиков.
            else if (Successor != null)
                Successor.HandleRequest(condition);
        }
    }
    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int condition)
        {
            // Некоторая обработка запроса.

            if (condition == 2)
            {
                // Завершение выполнения запроса.
            }
            // Передача запроса дальше по цепи при наличии в ней обработчиков.
            else if (Successor != null)
                Successor.HandleRequest(condition);
        }
    }

    class Client
    {
        void UseChainOfResponsibilityPattern()
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            h1.Successor = h2;
            h1.HandleRequest(2);
        }
    }
}
