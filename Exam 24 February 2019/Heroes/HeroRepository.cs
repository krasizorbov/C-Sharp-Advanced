using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        List<Hero> data;
        public HeroRepository()
        {
            data = new List<Hero>();
        }
        public int Count { get => data.Count; }

        public void Add(Hero hero)
        {
            data.Add(hero);
        }
        public void Remove(string name)
        {
            data = data.Where(x => x.Name != name).Select(y => y).ToList();
        }
        public Hero GetHeroWithHighestStrength()
        {
            int index = 0;
            int strength = int.MinValue;
            for (int i = 0; i < data.Count; i++)
            {           
                if (data[i].Item.Strength > strength)
                {
                    strength = data[i].Item.Strength;
                    index = i;
                }
            }
            return data[index];
        }
        public Hero GetHeroWithHighestAbility()
        {
            int index = 0;
            int ability = int.MinValue;
            for (int i = 0; i < data.Count; i++)
            {  
                if (data[i].Item.Ability > ability)
                {
                    ability = data[i].Item.Ability;
                    index = i;   
                }
            }
            return data[index];
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            int index = 0;
            int intelligence = int.MinValue;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Item.Intelligence > intelligence)
                {
                    intelligence = data[i].Item.Intelligence;
                    index = i;
                } 
            }
            return data[index];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var d in data)
            {
                sb.Append(d.ToString());
            }
            return sb.ToString();
        }
    }
}
