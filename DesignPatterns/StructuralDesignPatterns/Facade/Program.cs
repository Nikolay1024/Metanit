using Facade.Example;
using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var textEditor = new TextEditor();
            var compiller = new Compiler();
            var clr = new Clr();

            var visualStudioFacade = new VisualStudioFacade(textEditor, compiller, clr);
            var programmer = new Programmer();
            programmer.CreateApplication(visualStudioFacade);

            Console.ReadLine();
        }
    }
}
