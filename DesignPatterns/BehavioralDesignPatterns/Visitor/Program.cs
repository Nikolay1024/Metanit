using System;
using Visitor.Example;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();
            bank.Add(new PersonAccount() { Name = "Иван Алексеев", Number = "82184931" });
            bank.Add(new CompanyAccount() { Name = "Microsoft", RegNumber = "ewuir32141324", Number = "3424131445" });
            bank.Accept(new HtmlVisitor());
            bank.Accept(new XmlVisitor());

            Console.ReadLine();
        }
    }
}
