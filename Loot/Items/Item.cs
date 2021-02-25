using System.Collections.Generic;
using System.Linq;

namespace DiscordRPG
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int MaxAmount { get; set; }
        public string Type { get; set; }
        public string Identifier { get; set; } = "Item";
        public List<int> Attributes { get; set; }
        public int Chance { get; set; }

        /// <summary>
        /// Creates an Item object
        /// </summary>
        /// <param name="name">The name of the Item</param>
        /// <param name="amount">The current Amount of the Item</param>
        /// <param name="maxAmount">The Max Amount of the Item</param>
        /// <param name="type">The Type of the Item</param>
        /// <param name="chance">The chance to pull the Item when killing an enemy</param>
        /// <param name="attributes">Any Attributes the Item has</param>
        public Item(string name, int amount, int maxAmount, string type, int chance, params int[] attributes)
        {
            Name = name;
            MaxAmount = maxAmount;
            Amount = amount;
            Type = type;
            Chance = chance;
            Attributes = attributes.ToList();
        }
    }
}
