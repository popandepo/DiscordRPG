using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiscordRPG.Models
{
    public class MaterialModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Tier { get; set; }
        public string Element { get; set; }
        public string Identifier { get; set; } = "Material";
        public int Chance { get; set; }
        public int PeakChance { get; set; }
        public int BaseChance { get; set; }
    }
}
