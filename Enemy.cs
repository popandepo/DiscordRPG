using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG
{
    class Enemy
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Enemy(string name, int level)
        {
            Create(name, level);
        }

        public Enemy Create(string name, int level)
        {
            Name = name;
            Level = level;
            Health = Tools.RandomWeighted(level, level / 2, (int)(level * 1.5));
            Attack = Tools.RandomWeighted(level, level / 2, (int)(level * 1.5));
            Defense = Tools.RandomWeighted(level, level / 2, (int)(level * 1.5));

            return this;
        }

        public override string ToString()
        {
            return ($"A level {Level} {Name} with health of {Health}, attack of {Attack} and defense of {Defense}.");
        }

    }
}
