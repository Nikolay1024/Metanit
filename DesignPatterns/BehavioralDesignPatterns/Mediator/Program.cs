using Mediator.Example;
using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var managerMediator = new ManagerMediator();
            Colleague customerColleague = new CustomerColleague(managerMediator);
            Colleague programmerColleague = new ProgrammerColleague(managerMediator);
            Colleague testerColleague = new TesterColleague(managerMediator);
            managerMediator.Customer = customerColleague;
            managerMediator.Programmer = programmerColleague;
            managerMediator.Tester = testerColleague;
            customerColleague.Send("Есть заказ, надо сделать программу");
            programmerColleague.Send("Программа готова, надо протестировать");
            testerColleague.Send("Программа протестирована и готова к продаже");

            Console.ReadLine();
        }
    }
}
