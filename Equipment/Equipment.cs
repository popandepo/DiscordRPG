namespace DiscordRPG
{
    public class Equipment : IEquipment
    {
        public string Name { get; set; }
        public string Slot { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public string EquipmentType { get; set; }

        public Equipment(string name, string slot, string equipmentType, int defense, int attack)
        {
            Name = name;
            Slot = slot;
            EquipmentType = equipmentType;
            Defense = defense;
            Attack = attack;
        }
    }
}
