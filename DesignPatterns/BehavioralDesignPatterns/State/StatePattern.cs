namespace State.Pattern
{
    // Паттерны поведения: состояние (state).
    // Когда надо применять паттерн:
    // 1. Когда поведение объекта должно зависеть от его состояния и может изменяться динамически во время выполнения.
    // 2. Когда в коде методов объекта используются многочисленные условные конструкции, выбор которых зависит от текущего состояния объекта.
    abstract class State
    {
        public abstract void Handle(Context context);
    }

    class StateA : State
    {
        public override void Handle(Context context) => context.State = new StateB();
    }
    class StateB : State
    {
        public override void Handle(Context context) => context.State = new StateA();
    }

    class Context
    {
        public State State { get; set; }

        public Context(State state) => State = state;

        public void Request() => State.Handle(this);
    }

    class Client
    {
        static void UseStatePattern()
        {
            var context = new Context(new StateA());
            // Переход в состояние StateB.
            context.Request();
            // Переход в состояние StateA.
            context.Request();  
        }
    }

}
