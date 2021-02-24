using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscordRPG.Items
{
    class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int MaxAmount { get; set; }
        public string Type { get; set; }
        public List<int> Attributes { get; set; }

        public Item(string name, int amount, string type, params int[] attributes )
        {
            Name = name;

            Amount = amount;
            Type = type;
            Attributes = attributes.ToList();
        }
    }
}
