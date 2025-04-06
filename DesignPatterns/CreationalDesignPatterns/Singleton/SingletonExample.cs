namespace Singleton.Example
{
    // Одиночка.
    class OperationSystem
    {
        static OperationSystem Instance;
        public string Name { get; private set; }

        protected OperationSystem(string name) => Name = name;

        public static OperationSystem GetInstance(string name)
        {
            if (Instance == null)
                Instance = new OperationSystem(name);
            return Instance;
        }
    }

    class Computer
    {
        public OperationSystem OperationSystem { get; set; }
        
        public void Launch(string name) => OperationSystem = OperationSystem.GetInstance(name);
    }
}
