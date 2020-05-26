using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthyHeaven
{
    public class Restaurant
    {
        List<Salad> data;

        public string Name { get; set; }
        public Restaurant(string name)
        {
            data = new List<Salad>();
            Name = name;
        }
        public void Add(Salad salad)
        {
            data.Add(salad);
        }
        public bool Buy(string name)
        {
            if (data.Where(x => x.Name == name).ToList().Count > 0)
            {
                data = data.Where(x => x.Name != name).ToList();
                return true;
            }
            return false;
        }
        public Salad GetHealthiestSalad()
        {
            Salad salad = data.OrderBy(x => x.GetTotalCalories()).First();
            return salad;
        }
        public string GenerateMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name} have {data.Count} salads:");
            foreach (var d in data)
            {
                sb.Append(d.ToString());
            }
            return sb.ToString();
        }

    }
}
