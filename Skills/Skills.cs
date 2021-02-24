using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG
{
    /// <summary>
    /// All skills inherit from ISkill object that decides the "framework" for all skills created. 
    /// </summary>
    class Skills : ISkill
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SkillName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DescriptionText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
