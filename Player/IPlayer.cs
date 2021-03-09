﻿using Discord;
using Discord.WebSocket;
using System.Collections.Generic;

namespace DiscordRPG
{
    public interface IPlayer : ICreature

    {
        ulong ID { get; set; }
        bool HasReadTutorial { get; set; }
        IUserMessage LastMessage { get; set; }
        List<IEmote> RecievedEmotes { get; set; }
        List<IEmote> ExpectedEmotes { get; set; }
        List<string> ExpectedString { get; set; }
        List<int> ExpectedNumber { get; set; }
        SocketUser User { get; set; }
        string Hashname { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Bp { get; set; }
        int Money { get; set; }
        string State { get; set; }
        int Attack { get; set; } //TEMPORARY
        int Defense { get; set; } //TEMPORARY
        //List<Skill> Skills { get; set; }
        Armor CEquipment { get; set; }
        List<Equipment> SEquipment { get; set; }
        List<Item> CItems { get; set; }
        List<Item> SItems { get; set; }
        List<Material> CMaterials { get; set; }
        List<Material> SMaterials { get; set; }

        Combat Combat { get; set; }
        List<int> RecievedNumbers { get; set; }
        //int NumberOfSkills { get; }

        //list of skills
        //list of carried equipment
        //list of stored equipment
        //list of carried items
        //list of stored items
        //list of materials
        //a combat class containing everyone in the fight referenced by "player", "friend1", "enemy1", "enemy2" etc.
    }
}
