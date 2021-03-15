using System.Collections.Generic;

namespace DiscordRPG
{
    public class AreaList
    {
        public static Area Tutorial = new Area("Tutorial", "A tutorial area", 1, new List<Enemy> { EnemyList.Goblin });
        public static Area Forest = new Area("Forest", "A lush forest with some weak enemies", 3, new List<Enemy> { EnemyList.Goblin, EnemyList.Slime });
        public static Area Desert = new Area("Desert", "A dry, hot and unforgiving place with no water for miles. Dangerous!", 5, new List<Enemy> { EnemyList.DesertWorm, EnemyList.Skeleton, EnemyList.DesertSlime });
    }
}
