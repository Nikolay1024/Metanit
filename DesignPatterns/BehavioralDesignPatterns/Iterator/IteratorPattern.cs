using System.Collections.Generic;

namespace Iterator
{
    // Паттерны поведения: итератор / перечислитель (iterator / enumerator).
    // Когда надо применять паттерн:
    // 1. Когда необходимо осуществить обход объекта без раскрытия его внутренней структуры.
    // 2. Когда имеется набор составных объектов, и надо обеспечить единый интерфейс для их перебора.
    // 3. Когда необходимо предоставить несколько альтернативных вариантов перебора одного и того же объекта.
    abstract class Enumerator
    {
        public abstract int CurrentItem();
        public abstract int FirstItem();
        public abstract int? NextItem();
        public abstract bool IsEnumerationCompleted();
    }

    class ConcreteEnumerator : Enumerator
    {
        readonly Enumerable Enumerable;
        int CurrentIndex;

        public ConcreteEnumerator(Enumerable enumerable) => Enumerable = enumerable;

        public override int CurrentItem() => Enumerable[CurrentIndex];
        public override int FirstItem() => Enumerable[0];
        public override int? NextItem()
        {
            int? nextItem = null;
            if (CurrentIndex + 1 < Enumerable.Count)
            {
                CurrentIndex++;
                nextItem = Enumerable[CurrentIndex];
            }
            return nextItem;
        }
        public override bool IsEnumerationCompleted() => CurrentIndex + 1 == Enumerable.Count;
    }

    abstract class Enumerable
    {
        public abstract int Count { get; }

        public abstract int this[int index] { get; }

        public abstract Enumerator GetEnumerator();
    }

    class ConcreteEnumerable : Enumerable
    {
        readonly List<int> Items = new List<int>();
        public override int Count => Items.Count;

        public override int this[int index] => Items[index];

        public override Enumerator GetEnumerator() => new ConcreteEnumerator(this);
    }

    class Client
    {
        public void UsePatternEnumerator()
        {
            Enumerable enumerable = new ConcreteEnumerable();
            Enumerator enumerator = enumerable.GetEnumerator();

            int? item = enumerator.FirstItem();
            while (!enumerator.IsEnumerationCompleted())
                item = enumerator.NextItem();
        }
    }
}
