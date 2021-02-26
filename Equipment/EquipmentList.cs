using System.Collections.Generic;

namespace DiscordRPG
{
    public class EquipmentList
    {
        public static Equipment leatherCap = new Equipment("Leather Cap", "Head", "Armor", 2, 0);
        public static Equipment leatherVest = new Equipment("Leather Vest", "Chest", "Armor", 2, 0);
        public static Equipment leatherGlove = new Equipment("Leather Glove", "Hand", "Armor", 1, 0);
        public static Equipment leatherPants = new Equipment("Leather Pants", "Legs", "Armor", 2, 0);
        public static Equipment leatherBoot = new Equipment("Leather Boot", "Foot", "Armor", 1, 0);

        public static Equipment leatherSword = new Equipment("Leather Sword", "WeaponR", "Weapon", 0, 10);

        public static Equipment leatherShield = new Equipment("Leather Shield", "WeaponL", "Shield", 10, 0);

        public static List<Equipment> leather = new List<Equipment> {
            leatherCap, //head
            leatherVest, //chest
            leatherGlove, leatherGlove, //hands
            leatherPants, //pants
            leatherBoot, leatherBoot, //feet

            leatherSword, //right hand weapon
            leatherShield //left hand weapon
        };
    }
}
