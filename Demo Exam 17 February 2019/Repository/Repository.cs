using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        Dictionary<int,Person> data;
        int id = -1;
        public int Count { get => data.Count; }
        public Repository()
        {
            data = new Dictionary<int, Person>();
        }
        public void Add(Person person)
        {
            data.Add(++id, person);
        }
        public Person Get(int id)
        {
            foreach (var p in data)
            {
                if (p.Key == id)
                {
                    return p.Value;
                }
            }
            return null;
        }
        public bool Update(int id, Person newPerson)
        {
            foreach (var p in data)
            {
                if (p.Key == id)
                {
                    data[id] = newPerson;
                    return true;
                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            foreach (var p in data)
            {
                if (p.Key == id)
                {
                    data.Remove(p.Key);
                    return true;
                }
            }
            return false;
        }
    }
}
