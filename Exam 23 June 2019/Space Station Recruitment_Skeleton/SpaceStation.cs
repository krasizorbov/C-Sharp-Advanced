using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        List<Astronaut> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public SpaceStation(string name, int capacity)
        {
            data = new List<Astronaut>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Astronaut astronaut)
        {
            if (data.Count < Capacity)
            {
                data.Add(astronaut);
            }
        }
        public bool Remove(string name)
        {
            foreach (var item in data)
            {
                if (item.Name == name)
                {
                    data.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Astronaut GetOldestAstronaut()
        {
            //return the oldest
            Astronaut astronaut = data.OrderByDescending(x => x.Age).First();
            return astronaut;
        }
        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronaut = data.Where(x => x.Name == name).FirstOrDefault();
            return astronaut;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
