using Interpreter.Example;
using System;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            // Определяем набор переменных.
            int x = 5;
            int y = 8;
            int z = 2;

            // Добавляем переменные в контекст.
            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);
            // Создаем объект для вычисления выражения x + y - z.
            IExpression expression = new SubtractExpression(
                new AddExpression(new NumberExpression("x"), new NumberExpression("y")),
                new NumberExpression("z"));

            int result = expression.Interpret(context);
            Console.WriteLine($"Результат: {result}.");

            Console.ReadLine();
        }
    }
}
