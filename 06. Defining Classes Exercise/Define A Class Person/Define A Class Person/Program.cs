using System;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person();
            firstPerson.Name = "Pesho";
            firstPerson.Age = 20;

            Person secondPerson = new Person();
            secondPerson.Name = "Gosho";
            secondPerson.Age = 18;

            Person thirdPerson = new Person
            {
                Name = "Stamat",
                Age = 43
            };
        }
    }

    public class StartUp
    {

    }

    public class Person
    {
        string name;
        int age;

        public string Name { get { return name; } set { name = value; } }

        public int Age { get { return age; } set { age = value; } }
    }
}
