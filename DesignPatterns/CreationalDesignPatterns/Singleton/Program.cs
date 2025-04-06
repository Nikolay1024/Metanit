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
            var computer = new Example.Computer();
            computer.Launch("Windows 8.1");
            Console.WriteLine(computer.OperationSystem.Name);

            // Не получится изменить операционную систему, так как объект уже создан.
            computer.OperationSystem = Example.OperationSystem.GetInstance("Windows 10");
            Console.WriteLine(computer.OperationSystem.Name);

            Console.ReadLine();
        }

        static void SingletonThreadSafe()
        {
            Console.WriteLine("-> Singleton безопасный к потокам");
            var thread = new Thread(() =>
            {
                var computer2 = new ThreadSafeExample.Computer();
                computer2.OperationSystem = ThreadSafeExample.OperationSystem.GetInstance("Windows 10");
                Console.WriteLine(computer2.OperationSystem.Name);

            });
            thread.Start();

            var computer3 = new ThreadSafeExample.Computer();
            computer3.Launch("Windows 8.1");
            Console.WriteLine(computer3.OperationSystem.Name);

            Console.ReadLine();
        }
    }
}
