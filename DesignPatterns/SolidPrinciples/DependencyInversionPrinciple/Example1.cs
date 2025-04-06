using System;

namespace DependencyInversionPrinciple.Example1
{
    // SOLID D - Принцип инверсии зависимостей (Dependency Inversion Principle).
    // Служит для создания слабосвязанных сущностей, которые легко тестировать, модифицировать и обновлять. Этот принцип можно сформулировать
    // следующим образом:
    // 1. Модули верхнего уровня не должны зависеть от модулей нижнего уровня. И те и другие должны зависеть от абстракций.
    // 2. Абстракции не должны зависеть от деталей реализации. Детали реализации должны зависеть от абстракций.
    class ConsolePrinter1
    {
        public void Print(string text) => Console.WriteLine(text);
    }

    class Book1
    {
        public string Text { get; set; }
        public ConsolePrinter1 ConsolePrinter { get; set; }

        public void Print() => ConsolePrinter.Print(Text);
    }

    // При подобном определении класс Book зависит от класса ConsolePrinter. Более того мы жестко определили, что печать книгу можно только на
    // консоли с помощью класса ConsolePrinter. Например, вывод в файл в данном случае исключен. Печать книги не отделена от деталей класса
    // ConsolePrinter. Все это является нарушением Принципа Инверсии Зависимостей.
    // Теперь приведем классы в соответствие с Принципом Инверсии Зависимостей, использовав абстракцию IPrinter внутри модуля верхнего уровня.
    // Инверсия зависимостей достигается за счет того, что изначально модуль верхнего уровеня напрямую зависел от модуля нижнего уровня,
    // а после внесенных изменений модуль нижнего уровня зависит от абстракции, которая используется внутри модуля верхнего уровня.
    
    // Абстракция.
    interface IPrinter
    {
        void Print(string text);
    }
    // Модуль нижнего уровня.
    class ConsolePrinter2 : IPrinter
    {
        public void Print(string text) => Console.WriteLine("Печать на консоли.");
    }
    // Модуль нижнего уровня.
    class HtmlPrinter2 : IPrinter
    {
        public void Print(string text) => Console.WriteLine("Печать в HTML.");
    }

    // Модуль верхнего уровня.
    class Book2
    {
        public string Text { get; set; }
        public IPrinter Printer { get; set; }

        public Book2(IPrinter printer) => Printer = printer;

        public void Print() => Printer.Print(Text);
    }
}
