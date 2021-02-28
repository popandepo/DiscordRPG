﻿using System.Collections.Generic;

namespace DiscordRPG
{
    public static class Text
    {
        public static string Tutorial(Player player)
        {
            string output = $"Welcome {player.User.Username}.\n" +
                $"This is a combat focused RPG where you fight enemies and gather loot.\n" +
                $"Then you use what you've gathered to create more powerful items and equipment.\n" +
                $"To play the game, you select any of the icons below the most recent message.\n" +
                $"The icons are meant to be self-explanatory\n" +
                $"If you do have any issues or something doesn't make sense, please send a message to popandepo#2378";

            return output;
        }
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

        public static string GetEnemy(Player player)
        {
            string output = "Select a target: ";

            for (int i = 0; i < player.Combat.Enemies.Count; i++)
            {
                Enemy enemy = player.Combat.Enemies[i];
                output += $"{Emote.Numbers[i + 1]} = {enemy.Name}, ";
            }
            output = output.Trim(' ');
            output = output.Trim(',');
            output += '.';
            return output;
        }
    }
}
