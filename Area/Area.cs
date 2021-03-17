using System.Collections.Generic;

namespace DiscordRPG
{
    public class Area : IArea
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public int Fight { get; set; } = 1;
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

            if (Fight == MaxLength)
            {
                if (Name == "Forest")
                {
                    output.Add(new Enemy("Goblin lord", 15, 10, 20, 20, 3));
                }
            }
            else
            {
                int enemyAmount = Tools.RandGen(1, 4, 2.2, 2);
                for (int i = 0; i < enemyAmount; i++)
                {
                    int enemy = Tools.RandGen(0, Enemies.Count - 1);
                    output.Add(Enemies[enemy]);
                }
            }

            return output;
        }
    }
}
