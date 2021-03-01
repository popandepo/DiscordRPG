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

            //write code here, get a random (between 1 and 4) amount of random enemies from the enemy list
            //if Name is "Tutorial", pull 2 enemies

            return output;
        }
    }
}
