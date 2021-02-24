using System.Collections.Generic;

namespace DiscordRPG
{
    interface IItem : ILootables
    {
        string Name { get; set; }
        string Description { get; set; }
        int Amount { get; set; }
        int MaxAmount { get; set; }
        string Type { get; set; }
        List<int> Attributes { get; set; }
        string Identifier { get; set; }
    }
}
