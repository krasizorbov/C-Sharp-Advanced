using System;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person(32);
            Person person3 = new Person("Ivo", 45);
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

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age)
        {
            Name = "No name";
            Age = age;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}