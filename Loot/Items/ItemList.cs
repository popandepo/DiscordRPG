namespace DiscordRPG
{
    public class ItemList
    {
        public Item lowPotion = new Item("Low Potion", 1, 10, "Potion", 5);
        public Item slimePotion = new Item("Slimy Potion", 1, 20, "Potion", 3);
        public Item LootGen(Item item, int chance)
        {
            item.Chance = chance;
            return item;
        }
    }
}
