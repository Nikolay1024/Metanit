using System.Text;

namespace Builder.Example
{
    // Мука.
    class Flour
    {
        // Cорт.
        public string Sort { get; set; }
    }
    
    // Соль.
    class Salt { }
    
    // Пищевые добавки.
    class Additives
    {
        public string Name { get; set; }
    }

    // Хлеб.
    class Bread
    {
        // Мука.
        public Flour Flour { get; set; }
        // Соль.
        public Salt Salt { get; set; }
        // Пищевые добавки.
        public Additives Additives { get; set; }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (Flour != null)
                stringBuilder.Append(Flour.Sort + "\n");
            if (Salt != null)
                stringBuilder.Append("Соль \n");
            if (Additives != null)
                stringBuilder.Append("Добавки: " + Additives.Name + " \n");
            
            return stringBuilder.ToString();
        }
    }

    // Абстрактный класс строителя (пекаря).
    abstract class BreadBuilder
    {
        public Bread Bread { get; private set; }

        public void CreateBread() => Bread = new Bread();
        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }

    // Строитель для ржаного хлеба.
    class RyeBreadBuilder : BreadBuilder
    {
        public override void SetFlour() => Bread.Flour = new Flour { Sort = "Ржаная мука 1 сорт" };

        public override void SetSalt() => Bread.Salt = new Salt();

        public override void SetAdditives() { /* не используется */ }
    }

    // Строитель для пшеничного хлеба.
    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetFlour() => Bread.Flour = new Flour { Sort = "Пшеничная мука 1 сорт" };

        public override void SetSalt() => Bread.Salt = new Salt();

        public override void SetAdditives() => Bread.Additives = new Additives { Name = "Улучшитель хлебопекарный" };
    }

    // Пекарь.
    class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }
}
