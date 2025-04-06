using System;

namespace SingleResponsibilityPrinciple.Example1
{
    // SOLID. S - Принцип Единственной Обязанности (Single Responsibility Principle) можно сформулировать так:
    // Каждый компонент должен иметь одну и только одну причину для изменения.
    // В C# в качестве компонента может выступать класс, структура, метод. А под обязанностью здесь понимается набор действий,
    // которые выполняют единую задачу.
    // Т.е. суть принципа заключается в том, что класс/структура/метод должны выполнять одну единственную задачу.
    class Report1
    {
        public string Text { get; set; } = string.Empty;

        // Обязанность - навигация по отчету.
        public void GoToFirstPage() => Console.WriteLine("Переход к первой странице.");
        public void GoToLastPage() => Console.WriteLine("Переход к последней странице.");
        public void GoToPage(int pageNumber) => Console.WriteLine($"Переход к странице {pageNumber}.");

        // Обязанность - печать отчета.
        public void Print() => Console.WriteLine($"Печать отчета.\n{Text}");
    }

    // Первые три метода класса относятся к навигации по отчету. Print() производит печать.
    // Что если нам понадобится передать отчет на принтер для физической печати на бумаге. Мы можем для этого поменять нужным образом
    // метод Print(). Однако это вряд ли затронет остальные методы, которые относятся к навигации. Также верно и обратное - изменение методов
    // навигации не повлияет на возможность печати отчета.
    // Таким образом, прослеживаются две причины для изменения, значит, класс Report обладает двумя обязанностями, и от одной из них этот класс
    // надо освободить. Решением было бы вынести каждую обязанность в отдельный компонент (в данном случае в отдельный класс).
    class Report2
    {
        public string Text { get; set; } = string.Empty;

        // Обязанность - навигация по отчету.
        public void GoToFirstPage() => Console.WriteLine("Переход к первой странице");
        public void GoToLastPage() => Console.WriteLine("Переход к последней странице");
        public void GoToPage(int pageNumber) => Console.WriteLine($"Переход к странице {pageNumber}");
    }

    // Обязанность - печать отчета.
    class Printer
    {
        public void Print(Report2 report) => Console.WriteLine($"Печать отчета.\n{report.Text}");
    }
}
