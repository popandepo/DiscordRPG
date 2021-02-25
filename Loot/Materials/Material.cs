namespace DiscordRPG
{
    public class Material : IMaterial
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Tier { get; set; }
        public string Element { get; set; }
        public string Identifier { get; set; } = "Material";
        public Material(string name, int amount, int tier, string element)
        {
            Name = name;
            Amount = amount;
            Tier = tier;
            Element = element;
        }
    }
}
