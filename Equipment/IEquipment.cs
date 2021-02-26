namespace DiscordRPG
{
    interface IEquipment
    {
        string Name { get; set; }
        string Slot { get; set; }
        string EquipmentType { get; set; }
        int Defense { get; set; }
        int Attack { get; set; }
    }
}
