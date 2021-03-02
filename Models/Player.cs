using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG.Models
{
    public class Player
    {
        public ulong Id { get; set; }
        public string Hashname { get; set; }
        public int Health { get; set; }
        public int MHealth { get; set; }
        public int Bp { get; set; }
        public int Money { get; set; }
        public int Attack { get; set; } 
        public int Defense { get; set; } 
        public List<Skill> Skills { get; set; }
        public List<Equipment> CEquipment { get; set; } 
        public List<Equipment> SEquipment { get; set; } 
        public List<Item> CItems { get; set; } 
        public List<Item> SItems { get; set; } 
        public List<Material> CMaterials { get; set; } 
        public List<Material> SMaterials { get; set; } 

    }
}
