using ChainOfResponsibility.Example;
using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = new Receiver(false, true, true);
            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            bankPaymentHandler.Handle(receiver);
            Console.ReadLine();

            receiver = new Receiver(false, false, false);
            bankPaymentHandler.Handle(receiver);
            Console.ReadLine();
        }
    }
}
