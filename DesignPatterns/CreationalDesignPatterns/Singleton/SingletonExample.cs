namespace Singleton.Example
{
    // Одиночка.
    class OperationSystem1
    {
        static OperationSystem1 Instance;
        public string Name { get; private set; }

        protected OperationSystem1(string name) => Name = name;

        public static OperationSystem1 GetInstance(string name)
        {
            if (Instance == null)
                Instance = new OperationSystem1(name);
            return Instance;
        }
    }

    class Computer1
    {
        public OperationSystem1 OperationSystem { get; set; }
        
        public void Launch(string name) => OperationSystem = OperationSystem1.GetInstance(name);
    }
}
