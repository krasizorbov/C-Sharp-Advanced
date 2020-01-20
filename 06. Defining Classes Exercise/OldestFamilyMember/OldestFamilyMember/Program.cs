using System;
using System.Collections.Generic;
using System.Linq;

namespace Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                family.AddMember(new Person(name, age));
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
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

    public class Family
    {
        List<Person> members;

        public Family()
        {
            members = new List<Person>();
        }
        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestMember()
        {
            return members.OrderByDescending(x => x.Age).First();
        }
    }

}