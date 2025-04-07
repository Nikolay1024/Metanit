using System;

namespace AbstractFactory.Example
{
    // Абстрактный класс движения.
    abstract class Movement
    {
        public abstract void Move();
    }
    // Абстрактный класс оружия.
    abstract class Weapon
    {
        public abstract void Hit();
    }

    // Класс движения бега.
    class RunMovement : Movement
    {
        public override void Move() => Console.WriteLine("Бежим");
    }
    // Класс движения полета.
    class FlyMovement : Movement
    {
        public override void Move() => Console.WriteLine("Летим");
    }
    // Класс оружия меча.
    class SwordWeapon : Weapon
    {
        public override void Hit() => Console.WriteLine("Бьем мечом");
    }
    // Класс оружия арбалета.
    class CrossbowWeapon : Weapon
    {
        public override void Hit() => Console.WriteLine("Стреляем из арбалета");
    }

    // Класс абстрактной фабрики создания героя.
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    // Класс фабрики создания бегущего героя с мечом (Воина).
    class WarriorFactory : HeroFactory
    {
        public override Movement CreateMovement() => new RunMovement();
        public override Weapon CreateWeapon() => new SwordWeapon();
    }
    // Класс фабрики создания летящего героя с арбалетом (Лучника).
    class ArcherFactory : HeroFactory
    {
        public override Movement CreateMovement() => new FlyMovement();
        public override Weapon CreateWeapon() => new CrossbowWeapon();
    }

    // Клиент создает любого героя в зависимости от переденного объекта фабрики.
    class Hero
    {
        Movement Movement;
        Weapon Weapon;

        public Hero(HeroFactory heroFactory)
        {
            Movement = heroFactory.CreateMovement();
            Weapon = heroFactory.CreateWeapon();
        }

        public void Move() => Movement.Move();
        public void Hit() => Weapon.Hit();
    }
}
