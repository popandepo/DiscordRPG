namespace DiscordRPG
{
    interface IEquipment
    {
        string Name { get; set; }
        string Slot { get; set; }
        int Defense { get; set; }
    }
}
