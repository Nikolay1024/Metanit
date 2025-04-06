namespace Facade.Pattern
{
    // Структурные паттерны: адаптер (adapter).
    // Когда надо применять паттерн:
    // 1. Когда имеется сложная система, и необходимо упростить с ней работу.
    // Фасад позволит определить одну точку взаимодействия между клиентом и системой.
    // 2. Когда надо уменьшить количество зависимостей между клиентом и сложной системой.
    // Фасадные объекты позволяют отделить, изолировать компоненты системы от клиента и развивать и работать с ними независимо.
    // 3. Когда нужно определить подсистемы компонентов в сложной системе. Создание фасадов для компонентов каждой отдельной подсистемы
    // позволит упростить взаимодействие между ними и повысить их независимость друг от друга.
    class SubsystemA
    {
        public void A1() { }
    }
    class SubsystemB
    {
        public void B1() { }
    }
    class SubsystemC
    {
        public void C1() { }
    }

    class Facade
    {
        SubsystemA SubsystemA;
        SubsystemB SubsystemB;
        SubsystemC SubsystemC;

        public Facade(SubsystemA subsystemA, SubsystemB subsystemB, SubsystemC subsystemC)
        {
            SubsystemA = subsystemA;
            SubsystemB = subsystemB;
            SubsystemC = subsystemC;
        }
        public void Operation1()
        {
            SubsystemA.A1();
            SubsystemB.B1();
            SubsystemC.C1();
        }
        public void Operation2()
        {
            SubsystemB.B1();
            SubsystemC.C1();
        }
    }

    class Client
    {
        public void UseFacadePattern()
        {
            var facade = new Facade(new SubsystemA(), new SubsystemB(), new SubsystemC());
            facade.Operation1();
            facade.Operation2();
        }
    }
}
