﻿namespace DiscordRPG
{
    public class Material : IMaterial
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Tier { get; set; }
        public string Element { get; set; }
        public string Identifier { get; set; } = "Material";
        public int Chance { get; set; }
        public int PeakChance { get; set; }
        public int BaseChance { get; set; }

        /// <summary>
        /// Creates a Material
        /// </summary>
        /// <param name="name">The name of the material</param>
        /// <param name="amount">The amount of the material</param>
        /// <param name="tier">The tier of the material</param>
        /// <param name="element">The element of the material</param>
        /// <param name="chance">The chance to pull the material when killing an enemy</param>
        public Material(string name, int amount, int tier, string element, int chance = 0)
        {
            Name = name;
            Amount = amount;
            Tier = tier;
            Element = element;
            Chance = chance;
        }

        public Material(Material material)
        {
            Name = material.Name;
            Amount = material.Amount;
            Tier = material.Tier;
            Element = material.Element;
            Chance = material.Chance;
        }


        public override string ToString()
        {
            string output = $"Name:{Name} Amount:{Amount} Tier:{Tier} Element:{Element} Identifier:{Identifier}";

            return output;
        }
    }
}
