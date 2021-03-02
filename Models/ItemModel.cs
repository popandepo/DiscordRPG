using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int MaxAmount { get; set; }
        public string Type { get; set; }
        public string Identifier { get; set; } = "Item";
        public List<int> Attributes { get; set; }
        public int Chance { get; set; }
        public int PeakChance { get; set; }
        public int BaseChance { get; set; }
    }
}
