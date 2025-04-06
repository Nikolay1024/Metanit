using System.Collections;

namespace Iterator
{
    // Паттерны поведения: итератор / перечислитель (iterator / enumerator).
    // Когда надо применять паттерн:
    // 1. Когда необходимо осуществить обход объекта без раскрытия его внутренней структуры.
    // 2. Когда имеется набор составных объектов, и надо обеспечить единый интерфейс для их перебора.
    // 3. Когда необходимо предоставить несколько альтернативных вариантов перебора одного и того же объекта.
    abstract class Enumerator
    {
        public abstract object CurrentItem();
        public abstract object FirstItem();
        public abstract object NextItem();
        public abstract bool IsEnumerationCompleted();
    }

    class ConcreteEnumerator : Enumerator
    {
        readonly Enumerable Enumerable;
        int CurrentIndex;

        public ConcreteEnumerator(Enumerable enumerable) => Enumerable = enumerable;

        public override object CurrentItem() => Enumerable[CurrentIndex];
        public override object FirstItem() => Enumerable[0];
        public override object NextItem()
        {
            object nextItem = null;
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

        public abstract object this[int index] { get; }

        public abstract Enumerator GetEnumerator();
    }

    class ConcreteEnumerable : Enumerable
    {
        readonly ArrayList Items = new ArrayList();
        public override int Count => Items.Count;

        public override object this[int index] => Items[index];

        public override Enumerator GetEnumerator() => new ConcreteEnumerator(this);
    }

    class Client
    {
        public void Main()
        {
            Enumerable enumerable = new ConcreteEnumerable();
            Enumerator enumerator = enumerable.GetEnumerator();

            object item = enumerator.FirstItem();
            while (!enumerator.IsEnumerationCompleted())
                item = enumerator.NextItem();
        }
    }
}
