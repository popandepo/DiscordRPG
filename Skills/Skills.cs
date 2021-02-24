using System;

namespace DiscordRPG
{
    class Skills : ISkill
    {
        public int ID { get; set; }
        public string SkillName { get; set; }
        public string DescriptionText { get; set; }
    }
}
