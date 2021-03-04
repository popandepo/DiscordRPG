namespace DiscordRPG
{
    public class EnemyList
    {
        private static int globalPulls;

        public static Enemy Goblin = new Enemy("Goblin",
            10, //attack
            5, //defense
            5, //health
            5, //max health
            globalPulls, //pulls
            MaterialList.LootGen(new Material(MaterialList.goblinLeatherOne), 44),
            MaterialList.LootGen(new Material(MaterialList.goblinLeatherTwo), 23),
            MaterialList.LootGen(new Material(MaterialList.goblinEarOne), 18),
            MaterialList.LootGen(new Material(MaterialList.goblinEarTwo), 10),
            MaterialList.LootGen(new Material(MaterialList.goblinGem), 5)
            );

        public static Enemy Slime = new Enemy("Slime",
            7, //attack
            6, //defense
            5, //health
            10, //max health
            globalPulls, //pulls
            MaterialList.LootGen(new Material(MaterialList.slimeGooOne), 20),
            MaterialList.LootGen(new Material(MaterialList.slimeGooTwo), 10),
            MaterialList.LootGen(new Material(MaterialList.slimeGem), 5),
            ItemList.LootGen(new Item(ItemList.slimePotion), 5)
            );

        public static Enemy Skeleton = new Enemy("Skeleton",
            4, //attack
            1, //defense
            10, //health
            20, //max health
            globalPulls, //pulls
            MaterialList.LootGen(new Material(MaterialList.skeletonBoneOne), 30),
            MaterialList.LootGen(new Material(MaterialList.skeletonBoneTwo), 20),
            MaterialList.LootGen(new Material(MaterialList.skeletonSkull), 10),
            MaterialList.LootGen(new Material(MaterialList.skeletonGem), 5)
            );
    }
}