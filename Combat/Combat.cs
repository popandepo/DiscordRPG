using System.Collections.Generic;
using System.Linq;

namespace DiscordRPG
{
    public class Combat : ICombat
    {
        public List<Enemy> Enemies { get; set; }
        public int Turn { get; set; }
        public List<ICreature> Combatants { get; set; }

        public Combat(Player player, params Enemy[] enemies)
        {
            Combatants = new List<ICreature>();
            Combatants.Add(player);

            Turn = 1;

            Enemies = enemies.ToList();
            Enemies.ForEach(e => Combatants.Add(e));
        }
    }
}
