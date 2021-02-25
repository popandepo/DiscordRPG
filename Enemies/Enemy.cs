using System.Collections.Generic;
using System.Linq;

namespace DiscordRPG
{
    public class Enemy : IEnemy
    {
        public string Name { get; set; }
        public List<string> Environment { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int Bonus { get; set; } = 0;
        public int Pulls { get; set; }
        public List<ILootables> Loot { get; set; }

        /// <summary>
        /// Creates an Enemy object
        /// </summary>
        /// <param name="name">The name of the enemy</param>
        /// <param name="environment">A list of environments the enemy can be in</param>
        /// <param name="attack">The attack of the enemy</param>
        /// <param name="defense">The defense of the enemy</param>
        /// <param name="health">The health of the enemy</param>
        /// <param name="loot">What the enemy can drop when killed</param>
        public Enemy(string name, List<string> environment, int attack, int defense, int health, int pulls, params ILootables[] loot)
        {
            Name = name;
            Environment = environment;
            Attack = attack;
            Defense = defense;
            Health = health;
            Pulls = pulls;
            Loot = loot.ToList();
        }

        /// <summary>
        /// Grabs loot from the enemy
        /// </summary>
        /// <returns>A list of ILootables</returns>
        public List<ILootables> Pull()
        {
            List<ILootables> loot = new List<ILootables>();

            return loot;
        }
    }
}
