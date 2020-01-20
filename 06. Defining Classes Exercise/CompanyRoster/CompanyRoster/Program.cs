using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                if (input.Length == 4)
                {
                    employees.Add(new Employee(input[0], decimal.Parse(input[1]), input[2], input[3]));
                }
                else if (input.Length == 5)
                {
                    if (input[4].Contains("@"))
                    {
                        employees.Add(new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], input[4]));
                    }
                    else
                    {
                        employees.Add(new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], int.Parse(input[4])));
                    }
                }
                else if (input.Length == 6)
                {
                    employees.Add(new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], input[4], int.Parse(input[5])));
                }
            }

            string bestPaidDept = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, AvgSalary = g.Average(e => e.Salary) })
            .OrderByDescending(o => o.AvgSalary).First().Department;

            //string bestPaidDept = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, AvgSalary = g.Average(e => e.Salary), indexCount = g.Count() })
            //.OrderByDescending(o => o.indexCount).First().Department;

            Console.WriteLine($"Highest Average Salary: {bestPaidDept}");

            employees.Where(e => e.Department == bestPaidDept).OrderByDescending(e => e.Salary).ToList().ForEach(Console.WriteLine);
        }
    }

    public class Employee
    {
        string name;
        decimal salary;
        string position;
        string department;
        string email;
        int age;

        public string Name { get {return name; } set {name = value; } }

        public decimal Salary { get {return salary; } set { salary = value; } }

        public string Position { get { return position; } set { position = value; } }

        public string Department { get { return department; } set { department = value; } }

        public string Email { get { return email; } set { email = value; } }

        public int Age { get { return age; } set { age = value; } }

        public Employee(string name, decimal salary, string position, string department)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = "n/a";
            Age = -1;
        }

        public Employee(string name, decimal salary, string position, string department, string email)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = email;
            Age = -1;
        }

        public Employee(string name, decimal salary, string position, string department, int age)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = "n/a";
            Age = age;
        }
        public Employee(string name, decimal salary, string position, string department, string email, int age)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = email;
            Age = age;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{this.Name} ");
            builder.Append($"{this.Salary:F2} ");
            builder.Append($"{(this.Email == null ? "n/a" : this.Email)} ");
            builder.Append($"{(this.Age == null ? -1 : this.Age)}");

            return builder.ToString();
        }
    }
}
