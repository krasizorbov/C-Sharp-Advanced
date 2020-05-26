using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        public int GetStatPower()
        {
            return Stat.Agility + Stat.Flexibility + Stat.Intelligence + Stat.Skills + Stat.Strength;
        }

        public int GetWeaponPower()
        {
            return Weapon.Sharpness + Weapon.Size + Weapon.Solidity;
        }

        public int GetTotalPower()
        {
            return GetStatPower() + GetWeaponPower();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"[{Name}] - [{GetTotalPower()}]");
            builder.AppendLine($"  Weapon Power: [{GetWeaponPower()}]");
            builder.AppendLine($"  Stat Power: [{GetStatPower()}]");
            return builder.ToString();
        }
    }
}
