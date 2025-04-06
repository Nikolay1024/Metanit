using System.Collections.Generic;
using System;

namespace Composite.Pattern
{
    // Структурные паттерны: компоновщик (composite).
    // Когда надо применять паттерн:
    // 1. Когда объекты должны быть реализованы в виде иерархической древовидной структуры.
    // 2. Когда клиенты единообразно должны управлять как целыми объектами, так и их составными частями.
    // То есть целое и его части должны реализовать один и тот же интерфейс.

    // Определяет интерфейс для всех компонентов в древовидной структуре.
    abstract class Component
    {
        protected string Name;

        public Component(string name) => Name = name;

        public abstract void Display();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
    }

    // Составной компонент, который может содержать другие компоненты.
    class Composite : Component
    {
        List<Component> Children = new List<Component>();

        public Composite(string name) : base(name) { }

        public override void Add(Component component) => Children.Add(component);
        public override void Remove(Component component) => Children.Remove(component);
        public override void Display()
        {
            Console.WriteLine(Name);
            foreach (Component component in Children)
                component.Display();
        }
    }

    // Листовой компонент, который не может содержать другие компоненты.
    class Leaf : Component
    {
        public Leaf(string name) : base(name) { }

        public override void Display() => Console.WriteLine(Name);
        public override void Add(Component component) => throw new NotImplementedException();
        public override void Remove(Component component) => throw new NotImplementedException();
    }

    class Client
    {
        public void UseCompositePattern()
        {
            Component root = new Composite("Root");
            Component leaf = new Leaf("Leaf");
            Composite subtree = new Composite("Subtree");
            root.Add(leaf);
            root.Add(subtree);
            root.Display();
        }
    }
}
