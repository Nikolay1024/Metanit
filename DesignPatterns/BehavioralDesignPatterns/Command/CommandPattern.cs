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

    // Инициатор команды.
    class Invoker
    {
        Command Command;

        public void SetCommand(Command command) => Command = command;
        public void Execute() => Command.Execute();
        public void Undo() => Command.Undo();
    }

    // Получатель команды.
    class Receiver
    {
        public void Execute() { }
        public void Undo() { }
    }

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

        public override void Execute() => Receiver.Execute();
        public override void Undo() => Receiver.Undo();
    }
    
    class Client
    {
        public void UseCommandPattern()
        {
            var invoker = new Invoker();
            var receiver = new Receiver();
            Command concreteCommand = new ConcreteCommand(receiver);
            invoker.SetCommand(concreteCommand);
            invoker.Execute();
            invoker.Undo();
        }
    }
}
