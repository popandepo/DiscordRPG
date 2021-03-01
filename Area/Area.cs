using System;
using System.Collections.Generic;

namespace DiscordRPG
{
    public class Area : IArea
    {

        public string Name { get; set; }
        public List<Enemy> Enemies { get; set; }


        public Area(string name, List<Enemy> enemies)
        {
            Name = name;
            Enemies = enemies;
        }

        public Area(Area area)
        {
            Name = area.Name;
            Enemies = area.Enemies;
        }

        public List<Enemy> Pull()
        {
            List<Enemy> output = new List<Enemy>();

            if (Name == "Tutorial")
            {
                output.Add(new Enemy(EnemyList.Goblin));
                output.Add(new Enemy(EnemyList.Goblin));
                return output;
            }

            var rng = new Random();
            int enemyAmount = rng.Next(1, 5);
            for (int i = 0; i < enemyAmount; i++)
            {
                int enemyIndex = rng.Next(0, Enemies.Count);
                output.Add(Enemies[enemyIndex]);
            }

            return output;
        }
    }
}
