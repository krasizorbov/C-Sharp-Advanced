using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationRecruitment
{
    public class Astronaut
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public Astronaut(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
        public override string ToString()
        {
            return $"Astronaut: {Name}, {Age} ({Country})";
        }
    }
}
