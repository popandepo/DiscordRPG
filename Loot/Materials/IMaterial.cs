namespace DiscordRPG
{
    public interface IMaterial : ILootables
    {
        new string Identifier { get; set; }
    }
}
