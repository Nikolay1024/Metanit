using System;

namespace TemplateMethod.Example
{
    abstract class Learning
    {
        public abstract void Learn();
    }

    abstract class Education : Learning
    {
        public abstract void Enter();
        public abstract void Study();
        public virtual void PassExams() => Console.WriteLine("Сдаем выпускные экзамены");
        public abstract void GetDocument();

        // Шаблонный метод (template method).
        public sealed override void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }
    }

    class School : Education
    {
        public override void Enter() => Console.WriteLine("Идем в первый класс");
        public override void Study()
        {
            Console.WriteLine("Посещаем уроки");
            Console.WriteLine("Делаем домашние задания");
        }
        public override void GetDocument() => Console.WriteLine("Получаем аттестат о среднем образовании");
    }

    class University : Education
    {
        public override void Enter() => Console.WriteLine("Сдаем вступительные экзамены и поступаем в ВУЗ");
        public override void Study()
        {
            Console.WriteLine("Посещаем лекции");
            Console.WriteLine("Проходим практику");
        }
        public override void PassExams() => Console.WriteLine("Сдаем экзамен по специальности");
        public override void GetDocument() => Console.WriteLine("Получаем диплом о высшем образовании");
    }
}
