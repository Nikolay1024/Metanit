using FluentBuilder.Example1;
using System;

namespace FluentBuilder
{
    class Program
    {
        static void Main()
        {
            var sam = new User1("Sam", 29, "Google", true);
            var kate = new User1("Kate", 21, null, false);

            User2 tom = new UserBuilder2().SetName("Tom").SetAge(23).SetCompany("Microsoft").Build();
            User2 alice = User2.CreateBuilder().SetName("Alice").SetAge(25).IsMarried.Build();
            // Выполняется неявное приведение типа UserBuilder2 к User2.
            User2 nik = User2.CreateBuilder().SetName("Nik").IsMarried.SetAge(25);

            Console.ReadLine();
        }
    }
}
