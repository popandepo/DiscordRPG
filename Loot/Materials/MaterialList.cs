namespace DiscordRPG
{
    public class MaterialList
    {
        public static Material goblinEarOne = new Material("Goblin Ear", 1, 1, "Normal");
        public static Material goblinEarTwo = new Material("Goblin Ear", 2, 1, "Normal");
        public static Material goblinGem = new Material("Goblin Gem", 1, 2, "Magic");

        public static Material LootGen(Material material, int chance)
        {
            material.Chance = chance;
            return material;
        }
    }
}
