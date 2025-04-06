using System;

namespace ChainOfResponsibility.Example
{
    class Receiver
    {
        // Банковские переводы.
        public bool BankTransfer { get; set; }
        // Перевод через PayPal.
        public bool PayPalTransfer { get; set; }
        // Денежные переводы (WesternUnion, Unistream).
        public bool MoneyTransfer { get; set; }

        public Receiver(bool bankTransfer, bool payPalTransfer, bool moneyTransfer)
        {
            BankTransfer = bankTransfer;
            PayPalTransfer = payPalTransfer;
            MoneyTransfer = moneyTransfer;
        }
    }

    abstract class PaymentHandler
    {
        public abstract PaymentHandler Successor { get; }

        public abstract void Handle(Receiver receiver);
    }

    class BankPaymentHandler : PaymentHandler
    {
        public override PaymentHandler Successor => new PayPalPaymentHandler();

        public override void Handle(Receiver receiver)
        {
            if (receiver.BankTransfer)
                Console.WriteLine("Выполняем банковский перевод");
            else if (Successor != null)
                Successor.Handle(receiver);
            else
                Console.WriteLine("Перевод выполнить не удалось.");
        }
    }

    class PayPalPaymentHandler : PaymentHandler
    {
        public override PaymentHandler Successor => new MoneyPaymentHandler();

        public override void Handle(Receiver receiver)
        {
            if (receiver.PayPalTransfer)
                Console.WriteLine("Выполняем перевод через PayPal");
            else if (Successor != null)
                Successor.Handle(receiver);
            else
                Console.WriteLine("Перевод выполнить не удалось.");
        }
    }

    class MoneyPaymentHandler : PaymentHandler
    {
        public override PaymentHandler Successor => null;

        public override void Handle(Receiver receiver)
        {
            if (receiver.MoneyTransfer)
                Console.WriteLine("Выполняем перевод через систему денежных переводов");
            else if (Successor != null)
                Successor.Handle(receiver);
            else
                Console.WriteLine("Перевод выполнить не удалось.");
        }
    }
}
