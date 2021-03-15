using Discord;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPG
{
    class Game
    {
        /// <summary>
        /// The main game loop that runs for every player
        /// </summary>
        public static async void GameLoop()
        {
            while (true)
            {
                await Task.Delay(100);

                foreach (var newPlayer in Program.holding)
                {
                    Program.players.Add(newPlayer);
                }
                Program.holding.Clear();

                await Task.Delay(100);

                //ConsoleLog(Program.players);

                foreach (var player in Program.players)
                {



                    switch (player.State)
                    {
                        case "BEGIN BATTLE":
                            var enemies = player.Area.Pull();
                            foreach (var enemy in enemies)
                            {
                                enemy.Bonus = 3;
                                player.Combat.Enemies.Add(new Enemy(enemy));

                                if (player.ID == 236267360502153217) //easter egg
                                {
                                    var rand = new Random();
                                    if (rand.Next(1, 101) == 1)
                                    {
                                        try
                                        {
                                            player.Combat.Enemies.RemoveAt(player.Combat.Enemies.Count);
                                        }
                                        catch
                                        {

                                        }
                                        player.Combat.Enemies.Add(new Enemy("Bidoof",
                                                                            5, //attack
                                                                            5, //defense
                                                                            10, //health
                                                                            10, //maxHealth
                                                                            1, //pulls
                                                                            new Material("Bidoof Head", 1, 10, "Normal", 1)));
                                    }
                                }
                            }

                            player.State = "PRE PLAYER TURN";
                            break;

                        case "PRE PLAYER TURN":
                            player.ReturnState = "PRE PLAYER TURN";
                            player.ClearBuffer();

                            if (player.Bp < 3)
                            {
                                player.Bp += 1;
                            }

                            player.ShowMainCombat();
                            // setup for the player turn

                            player.State = "PLAYER TURN";
                            break;

                        case "PLAYER TURN":

                            if (player.ReturnCheck())
                            {
                                break;
                            }

                            if (player.RecievedEmotes.Contains(Emote.Zap) && player.Bp > 0)
                            {
                                player.State = "CHECK BP";
                                break;
                            }

                            if (player.RecievedEmotes.Contains(Emote.Sword))
                            {
                                //if (player.RecievedEmotes.Contains(Emote.Zap))
                                //{
                                //    if (player.Bp > 0)
                                //    {
                                //        player.Bp -= 2;
                                //        player.Attack += player.Attack;
                                //    }
                                //}
                                player.State = "GET SINGLE TARGET";
                                break;
                            }
                            else if (player.RecievedEmotes.Contains(Emote.Shield))
                            {
                                player.UpdateStats();
                                //if (player.RecievedEmotes.Contains(Emote.Zap))
                                //{
                                //    if (player.Bp > 0)
                                //    {
                                //        player.Bp -= 2;
                                //        player.Defense += player.CEquipment.Shield.Defense * 2;
                                //    }
                                //}
                                player.Defense += player.CEquipment.Shield.Defense;

                                player.State = "ENEMY TURN";
                                break;
                            }
                            else if (player.RecievedEmotes.Contains(Emote.Bag))
                            {
                                await player.User.SendMessageAsync(Text.GetInventory(player, "Carried materials"));
                                player.LastMessage = player.User.SendMessageAsync(Text.GetInventory(player, "Carried items")).Result;

                                player.RecievedEmotes.Clear();

                                player.GetNum("Items");

                                player.State = "USE ITEM";
                                break;
                            }
                            break;

                        case "CHECK BP":
                            player.GetNum("Bp");
                            player.State = "AWAITING BP";
                            break;

                        case "USE ITEM":
                            if (player.RecievedEmotes.Count > 0)
                            {
                                player.UseItem();
                                player.State = "ENEMY TURN";
                            }
                            break;

                        case "GET SINGLE TARGET":
                            player.GetNum("Enemies");
                            player.State = "AWAITING ENEMY";
                            break;

                        case "ATTACKING ONE":
                            if (player.RecievedEmotes.Count > 0)
                            {
                                player.AttackEnemy();

                                for (int i = 0; i < player.Combat.Enemies.Count; i++)
                                {
                                    Enemy enemy = player.Combat.Enemies[i];
                                    if (enemy.Health <= 0)
                                    {
                                        player.RecieveLoot(player.Combat.Enemies[player.RecievedNumbers[0] - 1].Kill());
                                        player.Combat.Enemies.RemoveAt(i);
                                    }
                                }

                                player.ClearBuffer();

                                if (player.Combat.Enemies.Count <= 0)
                                {
                                    if (player.Area.Length > 1)
                                    {
                                        player.Area.Length--;
                                        player.State = "BEGIN BATTLE";
                                        break;
                                    }
                                    else if (player.Area.Length == 1)
                                    {
                                        player.State = "RETURNING HOME";
                                        break;
                                    }
                                }

                                player.State = "ENEMY TURN";
                            }
                            break;

                        case "ENEMY TURN":
                            foreach (var enemy in player.Combat.Enemies)
                            {
                                if (enemy.Bonus > 0)
                                {
                                    enemy.Bonus -= 1;
                                }

                                player.Damage(enemy.Attack);
                            }

                            player.State = "PRE PLAYER TURN";
                            break;

                        case "RETURNING HOME":
                            foreach (var item in player.CMaterials)
                            {
                                player.SMaterials.Add(item);
                            }
                            player.CMaterials.Clear();
                            player.SortList();

                            player.Restore();
                            player.ShowHome();

                            player.State = "HOME";
                            break;

                        case "HOME":
                            if (player.RecievedEmotes.Contains(Emote.Bag))
                            {
                                player.LastMessage = player.User.SendMessageAsync(Text.GetInventory(player, "Home")).Result;

                                player.RecievedEmotes.Clear();

                                player.ShowHome();
                            }
                            else if (player.RecievedEmotes.Contains(Emote.Sword))
                            {
                                player.ReturnState = "RETURNING HOME";

                                player.LastMessage = player.User.SendMessageAsync(Text.GetAreas(player)).Result;

                                player.State = "GOING OUT";
                            }
                            break;

                        case "GOING OUT":
                            player.GetNum("Areas");
                            break;

                        case "DEAD":
                            await player.User.SendMessageAsync("Your body turns to dust, you lose all carried materials and you respawn in the town.");
                            player.CMaterials.Clear();
                            player.State = "RETURNING HOME";
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private static void ConsoleLog(List<Player> players)
        {
            Console.Clear();
            string output = "Player log\n";
            for (int i = 0; i < players.Count; i++)
            {
                Player player = (Player)players[i];
                output += $"Player {i + 1}: {player.ID}, {player.Hashname}.\nState: {player.State}.\n";
                output += $"Health: {player.Health}/{player.MaxHealth}, BP: {player.Bp}/{3}.\n";

                output += Text.GetEnemy(player) + "\n\n";

                output += Text.GetCItems(player) + "\n\n";
                output += Text.GetCMaterials(player) + "\n";
                output += Text.GetSItems(player);
                output += Text.GetSMaterials(player);
            }
            Console.WriteLine(output);
        }
    }
}
