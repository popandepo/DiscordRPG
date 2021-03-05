using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiscordRPG.Models
{
    public class SkillModel// : ISkill
    {
        [Key]
        public int ID { get; set; }
        public string SkillName { get; set; }
        public string DescriptionText { get; set; }
    }
}
