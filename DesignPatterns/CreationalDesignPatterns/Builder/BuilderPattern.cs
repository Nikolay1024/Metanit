using System.Collections.Generic;

namespace Builder.Pattern
{
    // Порождающие паттерны: строитель (builder).
    // Когда надо применять паттерн:
    // 1. Когда процесс создания нового объекта не должен зависеть от того, из каких частей этот объект состоит
    // и как эти части связаны между собой.
    // 2. Когда необходимо обеспечить получение различных вариаций объекта в процессе его создания.
    class Product
    {
        List<object> Parts = new List<object>();

        public void Add(string part) => Parts.Add(part);
    }

    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();
    }

    class ConcreteBuilder : Builder
    {
        Product Product = new Product();
        public override void BuildPartA() => Product.Add("Part A");
        public override void BuildPartB() => Product.Add("Part B");
        public override void BuildPartC() => Product.Add("Part C");
        public override Product GetResult() => Product;
    }

    class Director
    {
        Builder Builder;

        public Director(Builder builder) => Builder = builder;

        public void Construct()
        {
            Builder.BuildPartA();
            Builder.BuildPartB();
            Builder.BuildPartC();
        }
    }

}
