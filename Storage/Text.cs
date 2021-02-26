using System.Collections.Generic;

namespace DiscordRPG
{
    public static class Text
    {
        public static string GetCombat(Player player)
        {
            string output = "";
            string lineOne = GetCombatOne(player.Combat.Enemies);
            string lineTwo = "";
            string lineThree = "";
            string lineFour = "";
            string lineFive = GetCombatFive(player);

            output = $"{lineOne}\n{lineTwo}\n{lineThree}\n{lineFour}\n{lineFive}";
            return output;
        }
        public static string GetCombatOne(List<Enemy> enemies)
        {
            string output = "";

            foreach (var enemy in enemies)
            {
                output += $"{enemy.Name}: HP {enemy.Health}/{enemy.MaxHealth}. ";
            }

            return output;
        }
        public static string GetCombatFive(Player player)
        {
            string output = "";

            output += $"HP {player.Health}/{player.MaxHealth} BP {player.Bp}";

            return output;
        }
    }
}
