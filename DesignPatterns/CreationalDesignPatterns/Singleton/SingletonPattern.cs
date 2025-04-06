namespace Singleton.Pattern
{
    // Порождающие паттерны: одиночка (singleton).
    // Когда надо применять паттерн:
    // 1. Когда необходимо, чтобы для класса существовал только один экземпляр.
    class Singleton
    {
        static Singleton Instance;

        Singleton() { }

        public static Singleton GetInstance()
        {
            if (Instance == null)
                Instance = new Singleton();
            return Instance;
        }
    }
}
