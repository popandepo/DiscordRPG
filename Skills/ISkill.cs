using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG.Skills
{
    interface ISkill
    {
        public int ID { get; set; }
        public string SkillName { get; set; }
        public string DescriptionText { get; set; }
        
    }
}
