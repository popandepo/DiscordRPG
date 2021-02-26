namespace DiscordRPG
{
    public class Equipment : IEquipment
    {
        public string Name { get; set; }
        public string Slot { get; set; }
        public int Defense { get; set; }

        public Equipment(string name, string slot, int defense)
        {
            Name = name;
            Slot = slot;
            Defense = defense;
        }
    }
}
