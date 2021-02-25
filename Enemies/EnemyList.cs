using System.Collections.Generic;

namespace DiscordRPG
{
    public class EnemyList
    {
        public static Enemy Goblin = new Enemy("Goblin", new List<string> { "Forest" }, 5, 5, 5, 3, MaterialList.LootGen(MaterialList.goblinEarOne, 10), MaterialList.LootGen(MaterialList.goblinEarTwo, 20), MaterialList.LootGen(MaterialList.goblinGem, 5));
    }
}
