using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG.Models
{
    public class PlayerModel
    {
        public ulong Id { get; set; }
        public string Hashname { get; set; }
        public int Health { get; set; }
        public int MHealth { get; set; }
        public int Bp { get; set; }
        public int Money { get; set; }
        public int Attack { get; set; } 
        public int Defense { get; set; } 
        public List<SkillModel> Skills { get; set; }
        public List<EquipmentModel> CEquipment { get; set; } 
        public List<EquipmentModel> SEquipment { get; set; } 
        public List<ItemModel> CItems { get; set; } 
        public List<ItemModel> SItems { get; set; } 
        public List<MaterialModel> CMaterials { get; set; } 
        public List<MaterialModel> SMaterials { get; set; } 

    }
}
