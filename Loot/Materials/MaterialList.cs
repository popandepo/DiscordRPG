namespace DiscordRPG
{
    public class MaterialList
    {
        public Material goblinEarOne = new Material("Goblin Ear", 1, 1, "Normal");
        public Material goblinEarTwo = new Material("Goblin Ear", 2, 1, "Normal");
        public Material goblinGem = new Material("Goblin Gem", 1, 2, "Magic");

        public Material slimeGooOne = new Material("Slime Goo", 1, 1, "Normal");
        public Material slimeGooTwo = new Material("Slime Goo", 2, 1, "Normal");
        public Material slimeGem = new Material("Slime Gem", 1, 2, "Magic");

        public Material LootGen(Material material, int chance)
        {
            material.Chance = chance;
            return material;
        }
    }
}
