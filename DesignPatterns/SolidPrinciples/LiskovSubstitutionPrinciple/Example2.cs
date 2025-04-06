using System;

namespace LiskovSubstitutionPrinciple.Example2
{
    // Существует несколько типов правил, которые должны быть соблюдены для выполнения принципа подстановки Лисков. Прежде всего это правила
    // контракта. Контракт задает ряд правил, и производный класс должен выполнять эти правила:
    // 1. Предусловия (Preconditions) не могут быть усилены в подклассе. Т.е. подклассы не должны создавать больше предусловий, чем
    // это определено в базовом классе.
    class Account1
    {
        public int Deposit { get; protected set; }

        public virtual void MakeDeposit(int money)
        {
            // Предусловие (Precondition).
            if (money < 0)
                throw new Exception("Нельзя положить на счет меньше 0.");
            Deposit = money;
        }
    }
    class MicroAccount1 : Account1
    {
        public override void MakeDeposit(int money)
        {
            // Предусловие (Precondition).
            if (money < 0)
                throw new Exception("Нельзя положить на счет меньше 0.");

            // Предусловие (Precondition).
            // В этом случае подкласс MicroAccount добавляет дополнительное предусловие, то есть усиливает его, что недопустимо.
            // Поэтому в реальной задаче мы можем столкнуться с проблемой.
            if (money > 100)
                throw new Exception("Нельзя положить на счет больше 100.");

            Deposit = money;
        }
    }

    // 2. Постусловия (Postconditions) не могут быть ослаблены в подклассе. Т.е. подклассы должны выполнять все постусловия, которые
    // определены в базовом классе.
    class Account2
    {
        public virtual decimal GetInterest(decimal sum, int month, int rate)
        {
            // Предусловие (Precondition).
            if (sum < 0 || month < 1 || month > 12 || rate < 0)
                throw new Exception("Некорректные данные.");

            decimal result = sum;
            for (int i = 0; i < month; i++)
                result += result * (rate / 100);

            // Постусловие (Postcondition).
            if (sum >= 1000)
            {
                // Добавляем бонус к вкладу, если начальная сумма больше либо ровна 1000.
                result += 100;
            }

            return result;
        }
    }
    class MicroAccount2 : Account2
    {
        public override decimal GetInterest(decimal sum, int month, int rate)
        {
            // Предусловие (Precondition).
            if (sum < 0 || month > 12 || month < 1 || rate < 0)
                throw new Exception("Некорректные данные.");

            decimal result = sum;
            for (int i = 0; i < month; i++)
                result += result * (rate / 100);

            // Пропущено постусловие базового класса, что нарушает принцип подстановки Лисков.
            // Поэтому в реальной задаче мы можем столкнуться с проблемой.

            return result;
        }
    }

    // 3. Инварианты (Invariants) — все условия базового класса - также должны быть сохранены и в подклассе.
    // Инварианты - это некоторые условия, которые остаются истинными на протяжении всей жизни объекта.
    // Как правило, инварианты передают внутреннее состояние объекта.
    class Account3
    {
        public virtual int Deposit
        {
            get => Deposit;
            set
            {
                if (value < 100)
                    throw new Exception("Некорректная сумма");
                Deposit = value;
            }
        }

        public Account3(int sum) => Deposit = sum;
    }
    class MicroAccount3 : Account3
    {
        public override int Deposit { get; set; }

        public MicroAccount3(int sum) : base(sum) { }
    }
    // С точки зрения класса Account поле не может быть меньше 100, и в свойстве Deposit это гарантируется. А производный класс MicroAccount,
    // переопределяя свойство Deposit, этого не гарантирует. Поэтому инвариант класса Account нарушается.
    // Во всех трех вышеперечисленных случаях проблема решается в общем случае с помощью абстрагирования и выделения общего функционала, который уже
    // наследуют классы Account и MicroAccount. Т.е. не один из них не наследуется от другого, а оба они наследуются от одного базового класса.
}
