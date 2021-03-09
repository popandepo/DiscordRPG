namespace DiscordRPG
{
    public class Armor
    {
        public Equipment Head { get; set; }
        public Equipment Chest { get; set; }
        public Equipment Arms { get; set; }
        public Equipment Waist { get; set; }
        public Equipment Legs { get; set; }
        public Equipment Weapon { get; set; }
        public Equipment Shield { get; set; }


        public Armor(Equipment head, Equipment chest, Equipment arms, Equipment waist, Equipment legs, Equipment weapon, Equipment shield)
        {
            Head = head;
            Chest = chest;
            Arms = arms;
            Waist = waist;
            Legs = legs;
            Weapon = weapon;
            Shield = shield;
        }
    }
}
