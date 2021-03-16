﻿using System;
using System.Collections.Generic;

namespace DiscordRPG
{
    public class Area : IArea
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public int Fight { get; set; }
        public int MaxLength { get; set; }
        public List<Enemy> Enemies { get; set; }

        public Area(string name, string description, int length, List<Enemy> enemies)
        {
            Name = name;
            Description = description;
            Length = length;
            Fight = 1;
            MaxLength = Length;
            Enemies = enemies;
        }

        public Area(Area area)
        {
            Name = area.Name;
            Description = area.Description;
            Length = area.Length;
            Fight = 1;
            MaxLength = area.MaxLength;
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
            int enemyAmount = rng.Next(1, 3);
            for (int i = 0; i < enemyAmount; i++)
            {
                int enemyIndex = rng.Next(0, Enemies.Count);
                output.Add(Enemies[enemyIndex]);
            }

            return output;
        }
    }
}
