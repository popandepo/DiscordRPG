namespace DiscordRPG
{
    public class ItemList
    {
        public static Item lowPotion = new Item("Low Potion", 1, 10, "Potion", 5);
        public static Item slimePotion = new Item("Slimy Potion", 1, 10, "Potion", 3);
        public static Item LootGen(Item item, int chance)
        {
            item.Chance = chance;
            return item;
        }
    }
}
