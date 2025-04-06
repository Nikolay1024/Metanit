namespace Decorator.Example
{
    abstract class Pizza
    {
        public string Name { get; protected set; }

        public Pizza(string name) => Name = name;

        public abstract int GetCost();
    }
    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца") { }

        public override int GetCost() => 10;
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza() : base("Болгарская пицца") { }

        public override int GetCost() => 8;
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza Pizza;

        public PizzaDecorator(string name, Pizza pizza) : base(name) => Pizza = pizza;
    }
    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza pizza) : base(pizza.Name + ", с томатами", pizza) { }

        public override int GetCost() => Pizza.GetCost() + 3;
    }
    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza pizza) : base(pizza.Name + ", с сыром", pizza) { }

        public override int GetCost() => Pizza.GetCost() + 5;
    }
}
