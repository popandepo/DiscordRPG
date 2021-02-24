using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG
{
    interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        int Amount { get; set; }
        int MaxAmount { get; set; }
        string Type { get; set; }
        List<int> Attributes { get; set; }
    }
}
