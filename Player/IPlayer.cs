using Discord.WebSocket;
using System.Collections.Generic;

namespace DiscordRPG
{
    interface IPlayer
    {
        ulong ID { get; set; }
        SocketUser User { get; set; }
        string Hashname { get; set; }
        int Health { get; set; }
        int MHealth { get; set; }
        int Bp { get; set; }
        int Money { get; set; }
        string State { get; set; }
        int Attack { get; set; } //TEMPORARY
        int Defence { get; set; } //TEMPORARY
        List<ISkill> Skills { get; set; }
        List<IEquipment> CEquipment { get; set; }
        List<IEquipment> SEquipment { get; set; }
        List<IItem> CItems { get; set; }
        List<IItem> SItems { get; set; }
        List<IMaterial> CMaterials { get; set; }
        List<IMaterial> SMaterials { get; set; }
        int NumberOfSkills { get; }
        //list of skills
        //list of carried equipment
        //list of stored equipment
        //list of carried items
        //list of stored items
        //list of materials
        //a combat class containing everyone in the fight referenced by "player", "friend1", "enemy1", "enemy2" etc.
    }
}
