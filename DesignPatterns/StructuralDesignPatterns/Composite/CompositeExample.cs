using System.Collections.Generic;
using System;

namespace Composite.Example
{
    abstract class Component
    {
        protected string Name;

        public Component(string name) => Name = name;

        public virtual void Add(Component component) { }
        public virtual void Remove(Component component) { }
        public virtual void Print() => Console.WriteLine(Name);
    }

    class Directory : Component
    {
        List<Component> Components = new List<Component>();

        public Directory(string name) : base(name) { }

        public override void Add(Component component) => Components.Add(component);
        public override void Remove(Component component) => Components.Remove(component);
        public override void Print()
        {
            Console.WriteLine($"Узел {Name}");
            Console.WriteLine("Подузлы:");
            foreach (Component component in Components)
                component.Print();
        }
    }

    class File : Component
    {
        public File(string name) : base(name) { }
    }
}
