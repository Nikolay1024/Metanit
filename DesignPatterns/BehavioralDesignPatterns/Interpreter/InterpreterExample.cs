using System.Collections.Generic;

namespace Interpreter.Example
{
    class Context
    {
        Dictionary<string, int> Variables = new Dictionary<string, int>();

        // Получаем значение переменной по ее имени.
        public int GetVariable(string name) => Variables[name];
        public void SetVariable(string name, int value)
        {
            if (Variables.ContainsKey(name))
                Variables[name] = value;
            else
                Variables.Add(name, value);
        }
    }
    // Интерфейс интерпретатора.
    interface IExpression
    {
        int Interpret(Context context);
    }

    // Терминальное выражение.
    class NumberExpression : IExpression
    {
        // Имя переменной.
        string Name;

        public NumberExpression(string name) => Name = name;

        public int Interpret(Context context) => context.GetVariable(Name);
    }
    // Нетерминальное выражение для сложения.
    class AddExpression : IExpression
    {
        IExpression LeftExpression;
        IExpression RightExpression;

        public AddExpression(IExpression leftExpression, IExpression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public int Interpret(Context context) => LeftExpression.Interpret(context) + RightExpression.Interpret(context);
    }
    // Нетерминальное выражение для вычитания.
    class SubtractExpression : IExpression
    {
        IExpression LeftExpression;
        IExpression RightExpression;

        public SubtractExpression(IExpression leftExpression, IExpression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public int Interpret(Context context) => LeftExpression.Interpret(context) - RightExpression.Interpret(context);
    }
}
