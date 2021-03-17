using System.Collections.Generic;

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
                $"If you do have any issues or something doesn't make sense,\n" +
                $"please send a message to popandepo#2378\n" +
                $"\n" +
                $"Press any action you want to do\n" +
                $"Then press the 🏁 to send the command\n" +
                $"Only ⚔️,🛡️,💼  and ⚡ work right now.\n" +
                $"⚔️ = Attack, 🛡️ = Defend, 💼 = Show inventory\n⚡ = Use BP to enhance either attacks or defenses";

            return output;
        }
        public static string GetHome(Player player)
        {
            string output = $"Welcome home, {player.User.Username}." +
                $"What do you want to do?";

            return output;
        }

        public static string GetAreas(Player player)
        {
            string output = "Areas:";
            for (int i = 0; i < player.UnlockedAreas.Count; i++)
            {
                Area area = player.UnlockedAreas[i];
                output += $"\n{i + 1}: {area.Name}, {area.Description}. Battles: {area.Length}. Enemies: ";
                foreach (var enemy in area.Enemies)
                {
                    output += $"{enemy.Name}, ";
                }
                output = output.Trim(' ');
                output = output.Trim(',');
            }
            return output;
        }

        public static string GetCombat(Player player)
        {
            string output = "";
            string lineOne = GetCombatOne(player.Area);
            string lineTwo = GetCombatTwo(player.Combat.Enemies);
            string lineThree = "";
            string lineFour = "";
            string lineFive = GetCombatFive(player);

            output = $"{lineOne}\n{lineTwo}\n{lineThree}\n{lineFour}\n{lineFive}";
            return output;
        }
        public static string GetCombatOne(Area area)
        {
            string output = $"{area.Name}, Fight {area.Fight + 1}/{area.MaxLength}";

            return output;
        }
        public static string GetCombatTwo(List<Enemy> enemies)
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

            output += $"HP {player.Health}/{player.MaxHealth} BP {player.Bp}/3";

            return output;
        }

        /// <summary>
        /// Gets all the enemies
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns></returns>
        public static string GetEnemy(Player player)
        {
            string output = "Enemies: ";

            for (int i = 0; i < player.Combat.Enemies.Count; i++)
            {
                Enemy enemy = player.Combat.Enemies[i];
                output += $"{i + 1} = {enemy.Name}, ";
            }
            output = output.Trim(' ');
            output = output.Trim(',');
            output += '.';
            return output;
        }

        public static string GetEnemies(Player player)
        {
            string output = "Choose one or more to attack: ";

            for (int i = 0; i < player.Combat.Enemies.Count; i++)
            {
                Enemy enemy = player.Combat.Enemies[i];
                output += $"{i + 1} = {enemy.Name}, ";
            }
            output = output.Trim(' ');
            output = output.Trim(',');
            output += '.';
            return output;
        }

        /// <summary>
        /// Get an inventory of a player
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="invType">What inventory to search</param>
        /// <returns></returns>
        public static string GetInventory(Player player, string invType)
        {
            player.SortList();
            string output;
            if (invType == "Home")
            {
                output = "Total inventory:\n";
                output += GetCItems(player);
                output += GetSItems(player);
                output += GetSMaterials(player);


                return output;
            }

            output = $"{invType}:\n";
            if (invType == "Carried items")
            {
                output += GetCItems(player);
            }
            if (invType == "Carried materials")
            {
                output += GetCMaterials(player);
            }

            return output;
        }

        public static string GetCMaterials(Player player)
        {
            string output = "";
            for (int i = 0; i < player.CMaterials.Count; i++)
            {
                Material material = player.CMaterials[i];
                output += $"{material.Name} x {material.Amount}.\n";
            }

            return output;
        }

        public static string GetSMaterials(Player player)
        {
            string output = "";
            for (int i = 0; i < player.SMaterials.Count; i++)
            {
                Material material = player.SMaterials[i];
                output += $"{material.Name} x {material.Amount}.\n";
            }

            return output;
        }

        public static string GetCItems(Player player)
        {
            string output = "";
            for (int i = 0; i < player.CItems.Count; i++)
            {
                Item item = player.CItems[i];
                output += $"{i + 1}: {item.Name} x {item.Amount}/{item.MaxAmount},\n{item.Description}.\n";
            }

            return output;
        }
        public static string GetSItems(Player player)
        {
            string output = "";
            for (int i = 0; i < player.SItems.Count; i++)
            {
                Item item = player.SItems[i];
                output += $"{i + 1}: {item.Name} x {item.Amount}/{item.MaxAmount},\n{item.Description}.\n";
            }

            return output;
        }
    }
}
