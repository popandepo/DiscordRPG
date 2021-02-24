namespace DiscordRPG
{
    class Material : IMaterial
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Tier { get; set; }
        public string Identifier { get; set; } = "Material";
        public Material(string name, int amount, int tier)
        {
            Name = name;
            Amount = amount;
            Tier = tier;
        }
        new public string GetType()
        {
            return "Material";
        }
    }
}
