using Singleton.Example;
using Singleton.ThreadSafeExample;
using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Singleton");
            Singleton();
            SingletonThreadSafe();
        }

        static void Singleton()
        {
            Console.WriteLine("-> Singleton не безопасный к потокам");
            var computer = new Computer1();
            computer.Launch("Windows 8.1");
            Console.WriteLine(computer.OperationSystem.Name);

            // Не получится изменить операционную систему, так как объект уже создан.
            computer.OperationSystem = OperationSystem1.GetInstance("Windows 10");
            Console.WriteLine(computer.OperationSystem.Name);

            Console.ReadLine();
        }

        static void SingletonThreadSafe()
        {
            Console.WriteLine("-> Singleton безопасный к потокам");
            var thread = new Thread(() =>
            {
                var computer1 = new Computer2();
                computer1.OperationSystem = OperationSystem2.GetInstance("Windows 10");
                Console.WriteLine(computer1.OperationSystem.Name);

            });
            thread.Start();

            var computer2 = new Computer2();
            computer2.Launch("Windows 8.1");
            Console.WriteLine(computer2.OperationSystem.Name);

            Console.ReadLine();
        }
    }
}
