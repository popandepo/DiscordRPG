using System;

namespace DiscordRPG
{
    public class Tools
    {
        public static int GetRandRange(int min, int max, Random rng)
        {
            Random rnd = rng;
            int output = rnd.Next(min, max);
            return output;
        }
    }
}
