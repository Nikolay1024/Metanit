using Command.Example;
using Command.MacroCommandExample;
using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Command");
            Command();
            MacroCommand();
        }

        static void Command()
        {
            Console.WriteLine("-> Command");
            var remoteСontrol = new RemoteСontrol();
            var televisor = new Televisor();
            remoteСontrol.AddCommand(new TelevisorCommand(televisor));
            // Включаем телевизор.
            remoteСontrol.PressButton();
            remoteСontrol.PressUndoButton();
            Console.ReadLine();

            remoteСontrol = new RemoteСontrol();
            var microwave = new Microwave();
            remoteСontrol.AddCommand(new MicrowaveCommand(microwave));
            // Включаем микроволновку.
            remoteСontrol.PressButton();
            Console.ReadLine();

            remoteСontrol = new RemoteСontrol();
            microwave = new Microwave();
            televisor = new Televisor();
            var volume = new Volume();
            remoteСontrol.AddCommand(new MicrowaveCommand(microwave));
            remoteСontrol.AddCommand(new TelevisorCommand(televisor));
            remoteСontrol.AddCommand(new VolumeCommand(volume));
            remoteСontrol.AddCommand(new VolumeCommand(volume));

            // Включаем микроволновку.
            remoteСontrol.PressButton();
            // Включаем телевизор.
            remoteСontrol.PressButton();
            // Увеличиваем громкость.
            remoteСontrol.PressButton();
            remoteСontrol.PressButton();

            // Уменьшаем громкость.
            remoteСontrol.PressUndoButton();
            remoteСontrol.PressUndoButton();
            // Выключаем телевизор.
            remoteСontrol.PressUndoButton();
            // Выключаем микроволновку.
            remoteСontrol.PressUndoButton();
            Console.ReadLine();
        }

        static void MacroCommand()
        {
            var programmer = new Programmer();
            var tester = new Tester();
            var marketolog = new Marketolog();
            var macroCommand = new MacroCommand(
                new List<ICommand>()
                {
                    new CodeCommand(programmer),
                    new TestCommand(tester),
                    new AdvertizeCommand(marketolog)
                });
            var manager = new Manager();
            manager.SetCommand(macroCommand);
            manager.StartProject();
            manager.StopProject();

            Console.ReadLine();
        }
    }
}
