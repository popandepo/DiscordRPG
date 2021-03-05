using System.ComponentModel.DataAnnotations;

namespace DiscordRPG.Models
{
    public class PlayerModel
    {
        [Key]
        public ulong Id { get; set; }
        public string Hashname { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Bp { get; set; }
        public int Money { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        //public List<ISkill> Skills { get; set; }
        //public List<IEquipment> CEquipment { get; set; } 
        //public List<IEquipment> SEquipment { get; set; } 
        //public List<IItem> CItems { get; set; } 
        //public List<IItem> SItems { get; set; } 
        //public List<IMaterial> CMaterials { get; set; } 
        //public List<IMaterial> SMaterials { get; set; } 

    }
}
