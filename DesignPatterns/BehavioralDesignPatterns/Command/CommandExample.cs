using System;
using System.Collections.Generic;

namespace Command.Example
{
    abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }

    class TelevisorCommand : Command
    {
        Televisor Televisor;

        public TelevisorCommand(Televisor televisor) => Televisor = televisor;

        public override void Execute() => Televisor.On();
        public override void Undo() => Televisor.Off();
    }

    class VolumeCommand : Command
    {
        Volume Volume;

        public VolumeCommand(Volume volume) => Volume = volume;

        public override void Execute() => Volume.IncreaseVolume();
        public override void Undo() => Volume.DecreaseVolume();
    }

    class MicrowaveCommand : Command
    {
        Microwave Microwave;

        public MicrowaveCommand(Microwave microwave) => Microwave = microwave;

        public override void Execute() => Microwave.StartCooking();
        public override void Undo() => Microwave.StopCooking();
    }

    // Получатель команды (Телевизор).   
    class Televisor
    {
        public void On() => Console.WriteLine("Телевизор включен!");
        public void Off() => Console.WriteLine("Телевизор выключен...");
    }

    // Получатель команды (Громкость).   
    class Volume
    {
        const int MinVolume = 0;
        const int MaxVolume = 20;
        int CurrentVolume;

        public Volume() => CurrentVolume = MinVolume;

        public void IncreaseVolume()
        {
            if (CurrentVolume < MaxVolume)
                CurrentVolume++;
            Console.WriteLine($"Уровень звука {CurrentVolume}.");
        }
        public void DecreaseVolume()
        {
            if (CurrentVolume > MinVolume)
                CurrentVolume--;
            Console.WriteLine($"Уровень звука {CurrentVolume}.");
        }
    }

    // Получатель команды (Микроволновка).   
    class Microwave
    {
        public void StartCooking() => Console.WriteLine("Подогреваем еду");
        public void StopCooking() => Console.WriteLine("Еда подогрета!");
    }

    // Инициатор команды (Пульт).
    class RemoteСontrol
    {
        Queue<Command> CommandsQueue = new Queue<Command>();
        Stack<Command> CommandsHistory = new Stack<Command>();

        public void AddCommand(Command command) => CommandsQueue.Enqueue(command);
        public void PressButton()
        {
            Command command = CommandsQueue.Dequeue();
            command?.Execute();
            CommandsHistory.Push(command);
        }
        public void PressUndoButton()
        {
            if (CommandsHistory.Count > 0)
            {
                Command command = CommandsHistory.Pop();
                command?.Undo();
            }
        }
    }
}
