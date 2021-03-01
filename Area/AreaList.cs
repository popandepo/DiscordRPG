using System.Collections.Generic;

namespace DiscordRPG
{
    public class AreaList
    {
        public static Area Tutorial = new Area("Tutorial", new List<Enemy> { EnemyList.Goblin });
        public static Area Forest = new Area("Forest", new List<Enemy> { EnemyList.Goblin, EnemyList.Slime });
    }
}
