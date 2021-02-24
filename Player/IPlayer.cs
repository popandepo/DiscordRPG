using System;
using System.Collections.Generic;
using DiscordRPG.Skills;
using DiscordRPG.Equipment;
using DiscordRPG.Items;
using System.Text;

namespace DiscordRPG.Player
{
    interface IPlayer
    {
        ulong ID { get; set; }
        string Hashname { get; set; }
        int Health { get; set; }
        int Bp { get; set; }
        string State { get; set; }
        int Attack { get; set; } //TEMPORARY
        int Defence { get; set; } //TEMPORARY
        List<ISkill> Skills { get; set; }
        List<IEquipment> Equipment { get; set; }
        List<IItem> Items { get; set; }
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
