using System.Collections.Generic;

namespace DiscordRPG
{
    public class EnemyList
    {
        public static ItemList items = new ItemList();
        public static MaterialList materials = new MaterialList();

        public Enemy Goblin = new Enemy("Goblin",
            new List<string> { "Forest", "Plains" },
            5, //attack
            5, //defense
            5, //health
            5, //max health
            3, //pulls
            MaterialList.LootGen(materials.goblinEarOne, 20),
            MaterialList.LootGen(materials.goblinEarTwo, 10),
            MaterialList.LootGen(materials.goblinGem, 5)
            );

        public Enemy Slime = new Enemy("Slime",
            new List<string> { "Forest", "Plains" },
            4, //attack
            6, //defense
            6, //health
            6, //max health
            3, //pulls
            MaterialList.LootGen(materials.slimeGooOne, 20),
            MaterialList.LootGen(materials.slimeGooTwo, 10),
            MaterialList.LootGen(materials.slimeGem, 5),
            ItemList.LootGen(items.slimePotion, 2)
            );
    }
}