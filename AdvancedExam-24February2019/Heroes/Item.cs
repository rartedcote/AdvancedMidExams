﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            Strength = strength;
            Ability = ability;
            Intelligence = intelligence;
        }

        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public override string ToString()
        {
            return $"Item:" +
                $" * Strength: {Strength}" + Environment.NewLine +
                $" * Ability: {Ability}" + Environment.NewLine +
                $" * Intelligence: {Intelligence}";
        }
    }
}
