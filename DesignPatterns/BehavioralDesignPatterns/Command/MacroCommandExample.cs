using System.Collections.Generic;
using System;

namespace Command.MacroCommandExample
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Класс макрокоманды.
    class MacroCommand : ICommand
    {
        List<ICommand> Commands;

        public MacroCommand(List<ICommand> commands) => Commands = commands;

        public void Execute()
        {
            foreach (ICommand command in Commands)
                command.Execute();
        }
        public void Undo()
        {
            foreach (ICommand command in Commands)
                command.Undo();
        }
    }

    class Programmer
    {
        public void StartCoding() => Console.WriteLine("Программист начинает писать код");
        public void StopCoding() => Console.WriteLine("Программист завершает писать код");
    }

    class Tester
    {
        public void StartTest() => Console.WriteLine("Тестировщик начинает тестирование");
        public void StopTest() => Console.WriteLine("Тестировщик завершает тестирование");
    }

    class Marketolog
    {
        public void StartAdvertize() => Console.WriteLine("Маркетолог начинает рекламировать продукт");
        public void StopAdvertize() => Console.WriteLine("Маркетолог прекращает рекламную кампанию");
    }

    class CodeCommand : ICommand
    {
        Programmer Programmer;

        public CodeCommand(Programmer programmer) => Programmer = programmer;

        public void Execute() => Programmer.StartCoding();
        public void Undo() => Programmer.StopCoding();
    }

    class TestCommand : ICommand
    {
        Tester Tester;

        public TestCommand(Tester tester) => Tester = tester;
        
        public void Execute() => Tester.StartTest();
        public void Undo() => Tester.StopTest();
    }

    class AdvertizeCommand : ICommand
    {
        Marketolog Marketolog;

        public AdvertizeCommand(Marketolog marketolog) => Marketolog = marketolog;
        
        public void Execute() => Marketolog.StartAdvertize();
        public void Undo() => Marketolog.StopAdvertize();
    }

    class Manager
    {
        ICommand Command;
        
        public void SetCommand(ICommand command) => Command = command;
        public void StartProject() => Command?.Execute();
        public void StopProject() => Command?.Undo();
    }
}
