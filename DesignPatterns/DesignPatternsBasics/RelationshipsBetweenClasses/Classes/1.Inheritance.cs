namespace DesignPatternsBasics.RelationshipsBetweenClasses.Classes
{
    // Отношения между классами: наследование (inheritance).
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Manager : User
    {
        public string Company { get; set; }
    }
}
