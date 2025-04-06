using System;

namespace DesignPatternsBasics.RelationshipsBetweenClasses.Classes
{
    // Отношения между классами: реализация (implementation).
    public interface IMovable
    {
        void Move();
    }

    public class Car : IMovable
    {
        public void Move() => Console.WriteLine("Машина едет");
    }
}
