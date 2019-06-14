using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    class HeroRepository
    {
        public HeroRepository()
        {
            data = new List<Hero>();
        }

        private List<Hero> data;

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Hero hero)
        {
            data.Add(hero);
        }

        public void Remove(string name)
        {
            data.Remove(data.First(x => x.Name == name));
        }

        public Hero GetHeroWithHighestStrength()
        {
            return data.First(x => x.Item.Strength == data.Max(y => y.Item.Strength));
        }

        public Hero GetHeroWithHighestAbility()
        {
            return data.First(x => x.Item.Ability == data.Max(y => y.Item.Ability));
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return data.First(x => x.Item.Intelligence == data.Max(y => y.Item.Intelligence));
        }

        public override string ToString()
        {
            foreach (var item in data)
            {
                return item.ToString();
            }

            return string.Empty;
        }
    }
}