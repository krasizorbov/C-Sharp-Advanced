using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int num = int.Parse(Console.ReadLine());

            const int ageLimit = 30;

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(new Person(name, age));
            }

            var result = people.Where(p => p.Age > ageLimit).OrderBy(p => p.Name);

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
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
}