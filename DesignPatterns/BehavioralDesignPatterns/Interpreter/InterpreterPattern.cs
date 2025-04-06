namespace Interpreter.Pattern
{
    // Паттерны поведения: интерпретатор (interpreter).
    // Определяет представление грамматики для заданного языка и интерпретатор предложений этого языка.
    // Как правило, данный шаблон проектирования применяется для часто повторяющихся операций.
    class Context { }

    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context) { }
    }

    class NonterminalExpression : AbstractExpression
    {
        AbstractExpression Expression1;
        AbstractExpression Expression2;
        
        public override void Interpret(Context context) { }
    }

    class Client
    {
        void UseInterpreter()
        {
            var context = new Context();

            var expression = new NonterminalExpression();
            expression.Interpret(context);

        }
    }
}
