using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    class Arena
    {
        public Arena(string name)
        {
            gladiators = new List<Gladiator>();
            Name = name;
        }

        private List<Gladiator> gladiators;
        public string Name { get; set; }
        public int Count
        {
            get
            {
                return gladiators.Count;
            }
        }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            gladiators.RemoveAll(x => x.Name == name);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator biggestGlad = gladiators.FirstOrDefault();

            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].GetStatPower() > biggestGlad.GetStatPower())
                {
                    biggestGlad = gladiators[i];
                }
            }

            return biggestGlad;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator biggestGlad = gladiators.FirstOrDefault();

            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].GetWeaponPower() > biggestGlad.GetWeaponPower())
                {
                    biggestGlad = gladiators[i];
                }
            }

            return biggestGlad;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator biggestGlad = gladiators.FirstOrDefault();

            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].GetTotalPower() > biggestGlad.GetTotalPower())
                {
                    biggestGlad = gladiators[i];
                }
            }

            return biggestGlad;
        }

        public override string ToString()
        {
            return $"{Name} - {Count} gladiators are participating.";
        }
    }
}