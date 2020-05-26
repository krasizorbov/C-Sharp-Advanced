using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }
        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            Item = item;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Hero: {Name} - {Level}lvl");
            sb.AppendLine($"{Item}");
            return sb.ToString();
        }
    }
}
