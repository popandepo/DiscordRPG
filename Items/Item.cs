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

        /// <summary>
        /// Creates an Item object
        /// </summary>
        /// <param name="name">The name of the Item</param>
        /// <param name="amount">The current Amount of the Item</param>
        /// <param name="maxAmount">The Max Amount of the Item</param>
        /// <param name="type">The Type of the Item</param>
        /// <param name="attributes">Any Attributes the Item has</param>
        public Item(string name, int amount, int maxAmount, string type, params int[] attributes )
        {
            Name = name;
            MaxAmount = maxAmount;
            Amount = amount;
            Type = type;
            Attributes = attributes.ToList();
        }
    }
}
