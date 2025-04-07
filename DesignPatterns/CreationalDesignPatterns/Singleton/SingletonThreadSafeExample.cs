namespace Singleton.ThreadSafeExample
{
    class OperationSystem2
    {
        static OperationSystem2 Instance;

        public string Name { get; private set; }
        static object SyncRoot = new object();

        protected OperationSystem2(string name) => Name = name;

        public static OperationSystem2 GetInstance(string name)
        {
            // Чтобы избежать одновременного доступа к коду из разных потоков критическая секция заключается в блок lock.
            lock (SyncRoot)
            {
                if (Instance == null)
                    Instance = new OperationSystem2(name);
            }
            return Instance;
        }
    }

    class Computer2
    {
        public OperationSystem2 OperationSystem { get; set; }

        public void Launch(string name) => OperationSystem = OperationSystem2.GetInstance(name);
    }
}
