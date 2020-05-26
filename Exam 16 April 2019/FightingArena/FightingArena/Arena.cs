using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        List<Gladiator> gladiators;
        public string Name { get; set; }
        public int Count
        {
            get => gladiators.Count;
        }
        public Arena(string name)
        {
            Name = name;
            gladiators = new List<Gladiator>();
        }
        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }
        public void Remove(string name)
        {
            Gladiator gladiator = gladiators.FirstOrDefault(x => x.Name == name);
            if (gladiator.Name == name)
            {
                gladiators.Remove(gladiator);
            }
        }
        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator gladiator = gladiators.OrderByDescending(x => x.GetStatPower()).First();
            return gladiator;
        }
        public Gladiator GetGladitorWithHeighestWeaponPower()
        {
            Gladiator gladiator = gladiators.OrderByDescending(x => x.GetWeaponPower()).First();
            return gladiator;
        }
        public Gladiator GetGladitorWithHeighestTotalPower()
        {
            Gladiator gladiator = gladiators.OrderByDescending(x => x.GetTotalPower()).First();
            return gladiator;
        }
        public override string ToString()
        {
            return $"[{Name}] - [{Count}] gladiators are participating.";
        }
    }
}
