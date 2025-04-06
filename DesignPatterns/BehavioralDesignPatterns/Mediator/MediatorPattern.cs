namespace Mediator.Pattern
{
    // Паттерны поведения: посредник (mediator).
    // Когда надо применять паттерн:
    // 1. Когда имеется множество взаимосвязаных объектов, связи между которыми сложны и запутаны.
    // 2. Когда необходимо повторно использовать объект, однако повторное использование затруднено в силу сильных связей с другими объектами.
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
    class ConcreteMediator : Mediator
    {
        public ConcreteColleague1 Colleague1 { get; set; }
        public ConcreteColleague2 Colleague2 { get; set; }

        public override void Send(string msg, Colleague colleague)
        {
            if (colleague == Colleague1)
                Colleague2.Notify(msg);
            else if (colleague == Colleague2)
                Colleague1.Notify(msg);
        }
    }

    abstract class Colleague
    {
        protected Mediator Mediator;

        public Colleague(Mediator mediator) => Mediator = mediator;
    }
    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator) { }

        public void Send(string message) => Mediator.Send(message, this);
        public void Notify(string message) { }
    }
    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator) { }

        public void Send(string message) => Mediator.Send(message, this);
        public void Notify(string message) { }
    }
}
