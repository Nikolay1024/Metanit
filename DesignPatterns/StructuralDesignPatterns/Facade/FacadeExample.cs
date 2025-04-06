using System;

namespace Facade.Example
{
    // Текстовый редактор.
    class TextEditor
    {
        public void CreateCode() => Console.WriteLine("Написание кода");
        public void Save() => Console.WriteLine("Сохранение кода");
    }
    // Компилятор.
    class Compiler
    {
        public void Compile() => Console.WriteLine("Компиляция приложения");
    }
    // Common Language Runtime (Общеязыковая Среда Исполнения).
    class Clr
    {
        public void Execute() => Console.WriteLine("Выполнение приложения");
        public void Finish() => Console.WriteLine("Завершение работы приложения");
    }

    class VisualStudioFacade
    {
        TextEditor TextEditor;
        Compiler Compiler;
        Clr Clr;

        public VisualStudioFacade(TextEditor textEditor, Compiler compiler, Clr clr)
        {
            TextEditor = textEditor;
            Compiler = compiler;
            Clr = clr;
        }

        public void Start()
        {
            TextEditor.CreateCode();
            TextEditor.Save();
            Compiler.Compile();
            Clr.Execute();
        }
        public void Stop() => Clr.Finish();
    }

    class Programmer
    {
        public void CreateApplication(VisualStudioFacade visualStudioFacade)
        {
            visualStudioFacade.Start();
            visualStudioFacade.Stop();
        }
    }
}
