using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetWeaponPower()
        {
            return Weapon.Sharpness + Weapon.Solidity + Weapon.Size;
        }

        public int GetStatPower()
        {
            return Stat.Flexibility + Stat.Agility + Stat.Intelligence
                + Stat.Skills + Stat.Strength;
        }

        public int GetTotalPower()
        {
            return GetWeaponPower() + GetStatPower();
        }

        public override string ToString()
        {
            return $"{Name} - {GetTotalPower()}" + Environment.NewLine +
                $" Weapon Power: {GetWeaponPower()}" + Environment.NewLine +
                $" Stat Power: {GetStatPower()}";

        }
    }
}
