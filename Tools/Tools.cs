using System;

namespace DiscordRPG
{
    public class NumberTools
    {
        public static int GetRandRange(int min, int max, Random rng)
        {
            Random rnd = rng;
            int output = rnd.Next(min, max);
            return output;
        }
    }
}
