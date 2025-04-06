using System;

namespace TellDontAsk.Example1
{
    // Принцип Tell-Don't-Ask позволяет объединить данные и связанное с ними поведение. Применение этого принципа позволяет вместо опроса данных и
    // последующих действий напрямую выполнять данные действия.
    class AlarmClock1
    {
        public int CurrentHour { get; set; }
        public int GetUpHour { get; set; }

        public AlarmClock1(int getUpHour) => GetUpHour = getUpHour;

        public void Alarm() => Console.WriteLine("Рота! Подъем!");
    }

    class AlarmClock2
    {
        int currentHour;
        public int CurrentHour
        {
            get => currentHour;
            set
            {
                // Tell.
                if (value == GetUpHour)
                    Alarm();
                currentHour = value;
            }
        }
        public int GetUpHour { get; set; }

        public AlarmClock2(int getUpHour) => GetUpHour = getUpHour;

        public void Alarm() => Console.WriteLine("Рота! Подъем!");
    }
}
