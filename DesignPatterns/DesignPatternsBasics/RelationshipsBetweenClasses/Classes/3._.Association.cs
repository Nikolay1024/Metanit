namespace DesignPatternsBasics.RelationshipsBetweenClasses.Classes
{
    // Отношения между классами: ассоциация (association).
    // Агрегация и композиция являются частными случаями ассоциации.
    class Team { }

    class Player
    {
        public Team Team { get; set; }
    }
}
