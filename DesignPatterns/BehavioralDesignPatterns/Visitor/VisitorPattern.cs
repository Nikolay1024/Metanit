using System.Collections.Generic;

namespace Visitor.Pattern
{
    // Паттерны поведения: посетитель / двойная диспетчеризация (visitor / double dispatch).
    // Когда надо применять паттерн:
    // 1. Когда имеется много объектов разнородных классов с разными интерфейсами, и требуется выполнить ряд операций над каждым из этих объектов.
    // 2. Когда классам необходимо добавить одинаковый набор операций без изменения этих классов.
    // 3. Когда часто добавляются новые операции к классам, при этом общая структура классов стабильна и практически не изменяется.
    abstract class Visitor
    {
        public abstract void VisitElementA(ElementA elementA);
        public abstract void VisitElementB(ElementB elementB);
    }
    class ConcreteVisitor1 : Visitor
    {
        public override void VisitElementA(ElementA elementA) => elementA.OperationA();
        public override void VisitElementB(ElementB elementB) => elementB.OperationB();
    }
    class ConcreteVisitor2 : Visitor
    {
        public override void VisitElementA(ElementA elementA) => elementA.OperationA();
        public override void VisitElementB(ElementB elementB) => elementB.OperationB();
    }

    abstract class Element
    {
        public string SomeState { get; set; }

        public abstract void Accept(Visitor visitor);
    }
    class ElementA : Element
    {
        public override void Accept(Visitor visitor) => visitor.VisitElementA(this);
        public void OperationA() { }
    }
    class ElementB : Element
    {
        public override void Accept(Visitor visitor) => visitor.VisitElementB(this);
        public void OperationB() { }
    }

    class ObjectStructure
    {
        List<Element> Elements = new List<Element>();

        public void Add(Element element) => Elements.Add(element);
        public void Remove(Element element) => Elements.Remove(element);
        public void Accept(Visitor visitor)
        {
            foreach (Element element in Elements)
                element.Accept(visitor);
        }
    }

    class Client
    {
        void UseVisitorPattern()
        {
            var objectStructure = new ObjectStructure();
            objectStructure.Add(new ElementA());
            objectStructure.Add(new ElementB());
            objectStructure.Accept(new ConcreteVisitor1());
            objectStructure.Accept(new ConcreteVisitor2());
        }
    }
}
