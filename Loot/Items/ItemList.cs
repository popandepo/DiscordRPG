namespace DiscordRPG
{
    public class ItemList
    {
        public static Item lowPotion = new Item("Low Potion", "A weak potion, only heals 5 HP", 1, 10, "Potion", 5);
        public static Item slimePotion = new Item("Slimy Potion", "An odd potion looted from a slime, heals 3 HP", 1, 20, "Potion", 3);
        public static Item LootGen(Item item, int chance)
        {
            item.Chance = chance;
            return item;
        }
    }
}
