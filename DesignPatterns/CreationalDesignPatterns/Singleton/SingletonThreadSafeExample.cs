namespace Singleton.ThreadSafeExample
{
    class OperationSystem
    {
        static OperationSystem Instance;

        public string Name { get; private set; }
        static object SyncRoot = new object();

        protected OperationSystem(string name) => Name = name;

        public static OperationSystem GetInstance(string name)
        {
            // Чтобы избежать одновременного доступа к коду из разных потоков критическая секция заключается в блок lock.
            lock (SyncRoot)
            {
                if (Instance == null)
                    Instance = new OperationSystem(name);
            }
            return Instance;
        }
    }

    class Computer
    {
        public OperationSystem OperationSystem { get; set; }

        public void Launch(string name) => OperationSystem = OperationSystem.GetInstance(name);
    }
}
