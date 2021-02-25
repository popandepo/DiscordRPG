namespace DiscordRPG
{
    public interface ILootables
    {
        string Name { get; set; }
        int Amount { get; set; }
        string Identifier { get; set; }
        int Chance { get; set; }
    }
}
