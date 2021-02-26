﻿using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;

namespace DiscordRPG
{
    public class Player : IPlayer
    {


        public ulong ID { get; set; }
        public IUserMessage LastMessage { get; set; }
        public SocketUser User { get; set; }
        public string Hashname { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Bp { get; set; }
        public int Money { get; set; }
        public string State { get; set; }
        public int Attack { get; set; } //TEMPORARY
        public int Defense { get; set; } //TEMPORARY
        public List<Skill> Skills { get; set; }
        public List<Equipment> CEquipment { get; set; } //Carried
        public List<Equipment> SEquipment { get; set; } //Stored
        public List<Item> CItems { get; set; } //Carried
        public List<Item> SItems { get; set; } //Stored
        public List<Material> CMaterials { get; set; } //Carried
        public List<Material> SMaterials { get; set; } //Stored
        public Combat Combat { get; set; }
        public int NumberOfSkills => Skills.Count();


        //list of skills
        //list of carried equipment
        //list of stored equipment
        //list of carried items
        //list of stored items
        //list of materials
        //a combat class containing everyone in the fight referenced by "player", "friend1", "enemy1", "enemy2" etc.

        /// <summary>
        /// Creates a player object
        /// </summary>
        /// <param name="id">The Discord ID of the Player</param>
        public Player(ulong id) //MOVE DEFAULT VALUES TO GETTER-SETTERS WHEN PROJECT IS DONE
        {
            ID = id;
            User = Program._client.GetUser(id);
            Hashname = User.ToString();
            Health = 10;
            MaxHealth = 10;
            Bp = 0;
            Money = 100;
            State = "IDLE";
            Attack = 5;
            Defense = 5;

            CEquipment = EquipmentList.leather;

            CItems = new List<Item>();
            CItems.Add(new Item("Potion", 3, 10, "POTION", 5));

            SItems = new List<Item>();

            SMaterials = new List<Material>();

            //CEquipment = starter equipment
            //SEquipment = nothing

            //CItems = starter items
            //SItems = nothing

            //Materials = nothing

            //Skills = starter skills (maybe nothing, maybe a low-level heal ability or something)

            //Combat = nothing
        }

        /// <summary>
        /// Gives a list of loot to the player
        /// </summary>
        /// <param name="loot">The list of loot to give to the player</param>
        public void RecieveLoot(List<ILootables> loot)
        {
            foreach (var item in loot)
            {
                if (item.Identifier == "Item")
                {
                    SItems.Add((Item)item);
                    User.SendMessageAsync($"You looted {item.Amount} {item.Name}");
                }
                else if (item.Identifier == "Material")
                {
                    SMaterials.Add((Material)item);
                    User.SendMessageAsync($"You looted {item.Amount} {item.Name}");
                }
            }
        }

        public override string ToString()
        {
            string output = $"{{\"ID\":{ID}, \"Hashname\":{Hashname}, \"Health\":{Health}, \"MHealth\":{MaxHealth}, \"Bp\":{Bp}, \"Money\":{Money}, \"State\":{State}, \"Attack\":{Attack}, \"Defense\":{Defense},";
            /*
            output += "\"CItems\":{";
            foreach (var item in CItems)
            {
                output += item.ToString();
            }
            output += "},";

            output += "\"SItems\":{";
            foreach (var item in SItems)
            {
                output += item.ToString();
            }
            output += "},";

            output += "\"CMaterials\":{";
            if (CMaterials.Count() != 0 && !(CMaterials is null))
            {
                CMaterials.ForEach(i => output += i);
            }
            output += "},";

            output += "\"SMaterials\":{";
            if (SMaterials.Count() != 0 && !(SMaterials is null))
            {
                SMaterials.ForEach(i => output += i);
            }
            output += "},";

            output += "\"CEquipment\":{";
            if (CEquipment.Count() != 0 && !(CEquipment is null))
            {
                CEquipment.ForEach(i => output += i);
            }
            output += "},";

            output += "\"SEquipment\":{";
            if (SEquipment.Count() != 0 && !(SEquipment is null))
            {
                SEquipment.ForEach(i => output += i);
            }*/
            output += "}";//}";
            System.Console.WriteLine(output);
            return output;
        }
    }
}
