

using Microsoft.VisualBasic;

namespace PersonInfo
{
    public class Citizen :IPerson,IBirthdays
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; }

        public string Id { get; private set; }
    }
}
