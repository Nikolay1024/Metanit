using LiskovSubstitutionPrinciple.Example1;
using LiskovSubstitutionPrinciple.Example2;
using System;
using System.Security.Principal;

namespace LiskovSubstitutionPrinciple
{
    class Program
    {
        static void Main()
        {
            Rectangle square = new Square();
            TestRectangleArea1(square);
            TestRectangleArea2(square);
            Console.ReadLine();

            Account1 microAccount1 = new MicroAccount1();
            InitializeAccount(microAccount1);
            Console.ReadLine();

            Account2 microAccount2 = new MicroAccount2();
            // Получаем 1100 без бонуса 100.
            CalculateInterest(microAccount2);
            Console.ReadLine();
        }

        // С точки зрения прямоугольника метод TestRectangleArea() выглядит нормально, но не с точки зрения квадрата. Мы ожидаем, что переданный
        // в метод TestRectangleArea() объект будет вести себя как стандартный прямоугольник. Однако квадрат, будучи в иерархии наследования
        // прямоугольником, все же ведет себя не как прямоугольник. В итоге программа вывалится в ошибку.
        static void TestRectangleArea1(Rectangle rectangle)
        {
            rectangle.Height = 5;
            // Изменение свойства Width переопределит также свойство Height, т.к. объект rectangle является Square.
            rectangle.Width = 10;
            if (rectangle.GetArea() != 50)
                throw new Exception("Некорректная площадь!");
        }
        // Иногда для выхода из подобных ситуаций прибегают к специальному хаку, который заключается в проверке объекта на соответствие типам.
        // Но такая проверка не отменяет того факта, что с архитектурой классов что-то не так. И проблема заключается в том, что производный
        // класс Square не ведет себя как базовый класс Rectangle, и поэтому его не следует наследовать от данного базового класса.
        // В этом и есть практический смысл принципа Лисков. Производный класс, который может делать меньше, чем базовый, обычно нельзя
        // подставить вместо базового, и поэтому он нарушает принцип подстановки Лисков.
        static void TestRectangleArea2(Rectangle rectangle)
        {
            if (rectangle is Square)
            {
                rectangle.Height = 5;
                if (rectangle.GetArea() != 25)
                    throw new Exception("Неправильная площадь!");
            }
            else if (rectangle is Rectangle)
            {
                rectangle.Height = 5;
                rectangle.Width = 10;
                if (rectangle.GetArea() != 50)
                    throw new Exception("Неправильная площадь!");
            }
        }

        // С точки зрения класса Account метод InitializeAccount() вполне является работоспособным. Однако при передаче в него объекта
        // MicroAccount мы столкнемся с ошибкой. В итоге принцип Лисков будет нарушен.
        static void InitializeAccount(Account1 account)
        {
            account.MakeDeposit(200);
            Console.WriteLine(account.Deposit);
        }

        static void CalculateInterest(Account2 account)
        {
            // Начальная сумма вклада + (Проценты по вкладу) + Бонус.
            // 1000 + (1000 * (10 / 100)) + 100 = 1200.
            decimal sum = account.GetInterest(1000, 1, 10);

            // Ожидаем 1200, по факту имеем 1100.
            if (sum != 1200) 
                throw new Exception("Неожиданная сумма при вычислениях.");
        }
    }
}
