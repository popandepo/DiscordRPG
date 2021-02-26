using System.Collections.Generic;

namespace DiscordRPG
{
    public class EquipmentList
    {
        public static Equipment leatherCap = new Equipment("Leather Cap", "Head", 2);
        public static Equipment leatherVest = new Equipment("Leather Vest", "Chest", 2);
        public static Equipment leatherGlove = new Equipment("Leather Glove", "Hand", 1);
        public static Equipment leatherPants = new Equipment("Leather Pants", "Legs", 2);
        public static Equipment leatherBoot = new Equipment("Leather Boot", "Foot", 1);

        public static List<Equipment> leather = new List<Equipment> {
            leatherCap, //head
            leatherVest, //chest
            leatherGlove, leatherGlove, //hands
            leatherPants, //pants
            leatherBoot, leatherBoot //feet
        };
    }
}
