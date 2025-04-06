namespace DesignPatternsBasics.RelationshipsBetweenClasses.Classes
{
    // Отношения между классами: агрегация (aggregation).
    // Агрегация и композиция являются частными случаями ассоциации.

    // При агрегации реализуется слабая связь, то есть в данном случае объекты Car и Engine будут равноправны.
    // В конструктор Car передается ссылка на уже имеющийся объект Engine.
    // И, как правило, определяется ссылка не на конкретный класс, а на абстрактный класс или интерфейс, что увеличивает гибкость программы.
    public abstract class GasolineEngine { }

    public class GasolineCar
    {
        GasolineEngine Engine;

        public GasolineCar(GasolineEngine engine) => Engine = engine;
    }
}
