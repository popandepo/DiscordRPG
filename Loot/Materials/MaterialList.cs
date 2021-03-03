namespace DiscordRPG
{
    public class MaterialList
    {
        public static Material goblinEarOne = new Material("Goblin Ear", 1, 1, "Normal");
        public static Material goblinEarTwo = new Material("Goblin Ear", 2, 1, "Normal");
        public static Material goblinGem = new Material("Goblin Gem", 1, 2, "Magic");

        public static Material slimeGooOne = new Material("Slime Goo", 1, 1, "Normal");
        public static Material slimeGooTwo = new Material("Slime Goo", 2, 1, "Normal");
        public static Material slimeGem = new Material("Slime Gem", 1, 2, "Magic");

        public static Material skeletonBoneOne = new Material("Skeleton Bone", 1, 2, "Normal");
        public static Material skeletonBoneTwo = new Material("Skeleton Bone", 2, 2, "Normal");
        public static Material skeletonSkull = new Material("Skeleton Skull", 1, 2, "Normal");
        public static Material skeletonGem = new Material("Skeleton Gem", 1, 3, "Magic");


        public static Material LootGen(Material material, int chance)
        {
            material.Chance = chance;
            return material;
        }
    }
}
