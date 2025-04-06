using Bridge.Example;
using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем нового программиста, он работает с C++.
            Programmer freelancer = new FreelanceProgrammer(new CppLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();

            // Пришел новый заказ, но теперь нужен C#.
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();

            Console.ReadLine();
        }
    }
}
