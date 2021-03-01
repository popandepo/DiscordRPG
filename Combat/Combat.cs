using System.Collections.Generic;
using System.Linq;

namespace DiscordRPG
{
    public class Combat : ICombat
    {
        public List<Enemy> Enemies { get; set; }
        public int Turn { get; set; }

        public Combat(params Enemy[] enemies)
        {

            Turn = 1;

            Enemies = enemies.ToList();
        }
    }
}
