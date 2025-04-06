using System;

namespace Bridge.Example
{
    // Реализация.
    interface ILanguage
    {
        void Build();
        void Execute();
    }
    class CppLanguage : ILanguage
    {
        public void Build() => Console.WriteLine("С помощью компилятора C++ компилируем программу в бинарный код.");
        public void Execute() => Console.WriteLine("Запускаем исполняемый файл программы.");
    }
    class CSharpLanguage : ILanguage
    {
        public void Build() => Console.WriteLine("С помощью компилятора Roslyn компилируем исходный код в файл exe.");
        public void Execute()
        {
            Console.WriteLine("JIT компилирует программу бинарный код.");
            Console.WriteLine("CLR выполняет скомпилированный бинарный код.");
        }
    }

    // Абстракция.
    abstract class Programmer
    {
        public ILanguage Language { protected get; set; }

        public Programmer(ILanguage language) => Language = language;

        public virtual void DoWork()
        {
            Language.Build();
            Language.Execute();
        }
        public abstract void EarnMoney();
    }
    class FreelanceProgrammer : Programmer
    {
        public FreelanceProgrammer(ILanguage language) : base(language) { }

        public override void EarnMoney() => Console.WriteLine("Получаем оплату за выполненный заказ.");
    }
    class CorporateProgrammer : Programmer
    {
        public CorporateProgrammer(ILanguage language) : base(language) { }

        public override void EarnMoney() => Console.WriteLine("Получаем в конце месяца зарплату.");
    }
}
