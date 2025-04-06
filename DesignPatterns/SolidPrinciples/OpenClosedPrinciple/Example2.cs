using System;

namespace OpenClosedPrinciple.Example2
{
    // Другим распространенным способом применения Принципа Открытости/Закрытости представляет паттерн Шаблонный Метод (Template Method).
    // Переделаем предыдущую задачу с помощью этого паттерна.
    abstract class Meal
    {
        protected abstract void Prepare();
        protected abstract void Cook();
        protected abstract void FinalSteps();

        // Шаблонный Метод (Template Method).
        public void Make()
        {
            Prepare();
            Cook();
            FinalSteps();
        }
    }

    class PotatoMeal3 : Meal
    {
        protected override void Prepare() => Console.WriteLine("Чистим и моем картошку.");
        protected override void Cook()
        {
            Console.WriteLine("Ставим почищенную картошку на огонь.");
            Console.WriteLine("Варим около 30 минут.");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре.");
        }
        protected override void FinalSteps()
        {
            Console.WriteLine("Посыпаем пюре специями и зеленью.");
            Console.WriteLine("Картофельное пюре готово.");
        }
    }

    class SaladMeal3 : Meal
    {
        protected override void Prepare() => Console.WriteLine("Моем помидоры и огурцы.");
        protected override void Cook()
        {
            Console.WriteLine("Нарезаем помидоры и огурцы.");
            Console.WriteLine("Посыпаем зеленью, солью и специями.");
        }
        protected override void FinalSteps()
        {
            Console.WriteLine("Поливаем подсолнечным маслом.");
            Console.WriteLine("Салат готов.");
        }
    }

    class Cook3
    {
        public string Name { get; set; }

        public Cook3(string name) => Name = name;

        public void MakeDinner(Meal[] meals)
        {
            foreach (Meal meal in meals)
                meal.Make();
        }
    }
}
