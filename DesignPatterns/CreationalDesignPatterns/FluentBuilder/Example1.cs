namespace FluentBuilder.Example1
{
    public class User1
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
        public bool IsMarried { get; set; }

        public User1(string name, int age, string company, bool isMarried)
        {
            Name = name;
            Age = age > 0 ? age : 18;
            Company = company;
            IsMarried = isMarried;
        }
    }

    public class User2
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
        public bool IsMarried { get; set; }

        public static UserBuilder2 CreateBuilder() => new UserBuilder2();
    }
    public class UserBuilder2
    {
        User2 User = new User2();

        public UserBuilder2 SetName(string name)
        {
            User.Name = name;
            return this;
        }
        public UserBuilder2 SetAge(int age)
        {
            User.Age = age > 0 ? age : 0;
            return this;
        }
        public UserBuilder2 SetCompany(string company)
        {
            User.Company = company;
            return this;
        }
        public UserBuilder2 IsMarried
        {
            get
            {
                User.IsMarried = true;
                return this;
            }
        }
        public User2 Build() => User;
        
        public static implicit operator User2(UserBuilder2 userBuilder)
        {
            return userBuilder.User;
        }
    }
}
