using System.Collections.Generic;

namespace DiscordRPG
{
    public class EnemyList
    {
        public static Enemy Goblin = new Enemy("Goblin",
            new List<string> { "Forest", "Plains" },
            5, //attack
            5, //defense
            5, //health
            5, //max health
            3, //pulls
            MaterialList.LootGen(MaterialList.goblinEarOne, 20),
            MaterialList.LootGen(MaterialList.goblinEarTwo, 10),
            MaterialList.LootGen(MaterialList.goblinGem, 5)
            );

        public static Enemy Slime = new Enemy("Slime",
            new List<string> { "Forest", "Plains" },
            4, //attack
            6, //defense
            6, //health
            6, //max health
            3, //pulls
            MaterialList.LootGen(MaterialList.slimeGooOne, 20),
            MaterialList.LootGen(MaterialList.slimeGooTwo, 10),
            MaterialList.LootGen(MaterialList.slimeGem, 5),
            ItemList.LootGen(ItemList.slimePotion, 2)
            );
    }
}