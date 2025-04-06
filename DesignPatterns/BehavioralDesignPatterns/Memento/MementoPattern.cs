namespace Memento.Pattern
{
    // Паттерны поведения: хранитель (memento).
    // Когда надо применять паттерн:
    // 1. Когда нужно сохранить состояние объекта для возможного последующего восстановления.
    // 2. Когда сохранение состояния должно проходить без нарушения принципа инкапсуляции.
    
    // Хранитель.
    class Memento
    {
        public string State { get; private set; }

        public Memento(string state) => State = state;
    }

    // Смотритель.
    class Caretaker
    {
        public Memento Memento { get; private set; }
    }

    // Создатель.
    class Originator
    {
        public string State { get; set; }

        public Memento SaveState() => new Memento(State);
        public void RestoreState(Memento memento) => State = memento.State;
    }
}
