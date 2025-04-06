using System;

namespace Mediator.Example
{
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
    class ManagerMediator : Mediator
    {
        public Colleague Customer { get; set; }
        public Colleague Programmer { get; set; }
        public Colleague Tester { get; set; }

        public override void Send(string msg, Colleague colleague)
        {
            // Если отправитель заказчик, значит есть новый заказ.
            // Отправляем сообщение программисту.
            if (colleague == Customer)
                Programmer.Notify(msg);
            // Если отправитель программист, то можно приступать к тестированию.
            // Отправляем сообщение тестеру.
            else if (colleague == Programmer)
                Tester.Notify(msg);
            // Если отправитель тестер, значит продукт готов.
            // Отправляем сообщение заказчику.
            else if (colleague == Tester)
                Customer.Notify(msg);
        }
    }

    abstract class Colleague
    {
        protected Mediator Mediator;

        public Colleague(Mediator mediator) => Mediator = mediator;

        public virtual void Send(string message) => Mediator.Send(message, this);
        public abstract void Notify(string message);
    }
    // Класс заказчика.
    class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator) : base(mediator) { }

        public override void Notify(string message) => Console.WriteLine($"Сообщение заказчику: {message}");
    }
    // Класс программиста.
    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator) : base(mediator) { }

        public override void Notify(string message) => Console.WriteLine($"Сообщение программисту: {message}");
    }
    // Класс тестера.
    class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator) : base(mediator) { }

        public override void Notify(string message) => Console.WriteLine($"Сообщение тестеру: {message}");
    }
}
