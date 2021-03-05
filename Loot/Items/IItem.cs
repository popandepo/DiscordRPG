using System.Collections.Generic;

namespace DiscordRPG
{
    public interface IItem : ILootables
    {
        new string Name { get; set; }
        string Description { get; set; }
        new int Amount { get; set; }
        int MaxAmount { get; set; }
        string Type { get; set; }
        List<int> Attributes { get; set; }
        new string Identifier { get; set; }
    }
}
