using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiscordRPG.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int MaxAmount { get; set; }
        public string Type { get; set; }
        public string Identifier { get; set; } = "Item";
        
        [NotMapped]
        public List<int> Attributes { get; set; }
        public int Chance { get; set; }
        public int PeakChance { get; set; }
        public int BaseChance { get; set; }
    }
}
