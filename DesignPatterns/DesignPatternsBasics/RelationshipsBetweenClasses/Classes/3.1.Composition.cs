namespace DesignPatternsBasics.RelationshipsBetweenClasses.Classes
{
    // Отношения между классами: композиция (composition).
    // Агрегация и композиция являются частными случаями ассоциации.
    
    // При этом класс автомобиля полностью управляет жизненным циклом объекта двигателя.
    // При уничтожении объекта автомобиля в области памяти вместе с ним будет уничтожен и объект двигателя.
    // И в этом плане объект автомобиля является главным, а объект двигателя - зависимым.
    public class ElectricEngine { }

    public class ElectricCar
    {
        ElectricEngine Engine;

        public ElectricCar() => Engine = new ElectricEngine();
    }
}
