using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG.Tools
{
    class Tools
    {
        public int GetRandRange(int min, int max)
        {
            Random rnd = new Random();
            int output = rnd.Next(min, max);
            return output;
        }
    }
}
