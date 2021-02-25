using System;

namespace DiscordRPG
{
    public class Tools
    {
        public int GetRandRange(int min, int max)
        {
            Random rnd = new Random();
            int output = rnd.Next(min, max);
            return output;
        }
    }
}
