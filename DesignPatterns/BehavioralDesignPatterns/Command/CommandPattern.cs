namespace Command.Pattern
{
    // Паттерны поведения: команда (command).
    // Когда надо применять паттерн:
    // 1. Когда надо передавать в качестве параметров определенные действия, вызываемые в ответ на другие действия.
    // То есть когда необходимы функции обратного действия в ответ на определенные действия.
    // 2. Когда необходимо обеспечить выполнение очереди запросов, а также их возможную отмену.
    // 3. Когда надо поддерживать логгирование изменений в результате запросов.
    // Использование логов может помочь восстановить состояние системы.
    // Для этого необходимо будет использовать последовательность запротоколированных команд.
    abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }

    // Конкретная команда.
    class ConcreteCommand : Command
    {
        Receiver Receiver;

        public ConcreteCommand(Receiver receiver) => Receiver = receiver;

        public override void Execute() => Receiver.Operation();
        public override void Undo() { }
    }

    // Получатель команды.
    class Receiver
    {
        public void Operation() { }
    }
    
    // Инициатор команды.
    class Invoker
    {
        Command Command;

        public void SetCommand(Command command) => Command = command;
        public void Run() => Command.Execute();
        public void Cancel () => Command.Undo();
    }

    class Client
    {
        void Use()
        {
            var invoker = new Invoker();
            var receiver = new Receiver();
            var concreteCommand = new ConcreteCommand(receiver);
            invoker.SetCommand(concreteCommand);
            invoker.Run();
        }
    }
}
