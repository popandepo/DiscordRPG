using Discord;
using System;
using System.Collections.Generic;

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
                //await Task.Delay(100);

                for (int i = 0; i < Program.holding.Count; i++)
                {
                    try
                    {
                        Player newPlayer = Program.holding[i];
                        Program.players.Add(newPlayer);
                        Program.holding.Remove(newPlayer);
                    }
                    catch
                    {
                    }
                }
                ConsoleLog(Program.players);

                foreach (var player in Program.players)
                {
                    switch (player.State)
                    {
                        case State.Begin_battle:
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
                                if (player.ID == 236940355730145281) //easter egg
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
                                        player.Combat.Enemies.Add(new Enemy("Amongus drip",
                                                                            6, //attack
                                                                            9, //defense
                                                                            69, //health
                                                                            420, //maxHealth
                                                                            1, //pulls
                                                                            new Material("Drip", 1, 10, "Normal", 1)));
                                    }
                                }
                            }

                            player.State = State.Pre_player_turn;
                            break;

                        case State.Pre_player_turn:
                            player.ReturnState = State.Pre_player_turn;
                            player.ClearBuffer();

                            if (player.Bp < 3)
                            {
                                player.Bp += 1;
                            }

                            player.ShowMainCombat();
                            player.State = State.Player_turn;
                            break;

                        case State.Player_turn:

                            player.ReturnState = State.Player_turn;

                            if (player.RecievedEmotes.Contains(Emote.Zap) && player.Bp > 0)
                            {
                                player.State = State.Check_bp;
                                break;
                            }

                            if (player.RecievedEmotes.Contains(Emote.Sword))
                            {
                                player.State = State.Get_single_target;
                                break;
                            }
                            else if (player.RecievedEmotes.Contains(Emote.Shield))
                            {
                                player.UpdateStats();
                                player.Defense += player.CEquipment.Shield.Defense;

                                player.State = State.Enemy_turn;
                                break;
                            }
                            else if (player.RecievedEmotes.Contains(Emote.Bag))
                            {
                                await player.User.SendMessageAsync(Text.GetInventory(player, "Carried materials"));
                                player.LastMessage = player.User.SendMessageAsync(Text.GetInventory(player, "Carried items")).Result;

                                player.RecievedEmotes.Clear();

                                player.GetNum("Items");

                                player.State = State.Use_item;
                                break;
                            }
                            break;

                        case State.Check_bp:
                            player.GetNum("Bp");
                            player.State = State.Awaiting_bp;
                            break;

                        case State.Awaiting_bp:
                            if (player.RecievedEmotes.Count > 0)
                            {
                                if (player.ReturnCheck())
                                {
                                    break;
                                }

                                string emotes = "";

                                foreach (var emote in player.RecievedEmotes)
                                {
                                    emotes += emote.Name;
                                }

                                for (int i = 0; i < Emote.Numbers.Length; i++)
                                {
                                    IEmote number = Emote.Numbers[i];

                                    if (emotes.Contains(number.Name))
                                    {
                                        if (player.Bp - i >= 0)
                                        {
                                            player.BpToUse = i;
                                            player.SendMessage("What do you want to do?", true, Emote.Sword, Emote.Shield, Emote.TurnBack, Emote.Flag);
                                            player.State = State.Use_bp;
                                            break;
                                        }
                                        else
                                        {
                                            await player.User.SendMessageAsync("You don't have that many BP");
                                        }
                                    }
                                }
                            }
                            break;

                        case State.Use_bp:
                            if (player.RecievedEmotes.Count > 0)
                            {
                                if (player.ReturnCheck())
                                {
                                    break;
                                }

                                string emotes = "";

                                foreach (var emote in player.RecievedEmotes)
                                {
                                    emotes += emote.Name;
                                }

                                if (emotes.Contains(Emote.Sword.Name))
                                {
                                    player.State = State.Bp_get_multiple_targets;
                                    break;
                                }
                                else if (emotes.Contains(Emote.Shield.Name))
                                {
                                    player.Defense += (player.CEquipment.Shield.Defense * player.BpToUse);
                                    player.Bp -= player.BpToUse + 1;
                                    player.State = State.Enemy_turn;
                                    break;
                                }
                            }
                            break;

                        case State.Bp_get_multiple_targets:
                            player.GetNum("EnemiesM");
                            player.State = State.Awaiting_bp_enemies;
                            break;

                        case State.Awaiting_bp_enemies:
                            if (player.RecievedEmotes.Count > 0)
                            {
                                if (player.ReturnCheck())
                                {
                                    break;
                                }

                                string emotes = "";

                                foreach (var emote in player.RecievedEmotes)
                                {
                                    emotes += emote.Name;
                                }

                                for (int i = 0; i < Emote.Numbers.Length; i++)
                                {
                                    IEmote number = Emote.Numbers[i];

                                    if (emotes.Contains(number.Name))
                                    {
                                        player.RecievedNumbers.Add(i);
                                        player.State = State.Attacking_multiple;
                                    }
                                }
                            }
                            break;

                        case State.Use_item:
                            if (player.RecievedEmotes.Count > 0)
                            {
                                if (player.ReturnCheck())
                                {
                                    break;
                                }

                                player.UseItem();
                                player.State = State.Enemy_turn;
                            }
                            break;

                        case State.Get_single_target:
                            player.GetNum("Enemies");
                            player.State = State.Awaiting_enemy;
                            break;

                        case State.Awaiting_enemy:
                            if (player.RecievedEmotes.Count > 0)
                            {
                                string emotes = "";

                                foreach (var emote in player.RecievedEmotes)
                                {
                                    emotes += emote.Name;
                                }

                                for (int i = 0; i < Emote.Numbers.Length; i++)
                                {
                                    IEmote number = Emote.Numbers[i];

                                    if (emotes.Contains(number.Name))
                                    {
                                        player.RecievedNumbers.Add(i);
                                        player.State = State.Attacking_one;
                                    }
                                }
                            }
                            break;

                        case State.Attacking_one:
                            if (player.RecievedEmotes.Count > 0)
                            {
                                if (player.ReturnCheck())
                                {
                                    break;
                                }

                                player.AttackEnemy();

                                for (int i = 0; i < player.Combat.Enemies.Count; i++)
                                {
                                    Enemy enemy = player.Combat.Enemies[i];
                                    if (enemy.Health <= 0)
                                    {
                                        await player.RecieveLootAsync(player.Combat.Enemies[player.RecievedNumbers[0] - 1].Kill());
                                        player.Combat.Enemies.RemoveAt(i);
                                    }
                                }

                                player.ClearBuffer();

                                if (player.Combat.Enemies.Count <= 0)
                                {
                                    if (player.Area.Length > 1)
                                    {
                                        player.Area.Length--;
                                        player.State = State.Battle_over;
                                        break;
                                    }
                                    else if (player.Area.Length == 1)
                                    {
                                        player.State = State.Returning_home;
                                        break;
                                    }
                                }

                                player.State = State.Enemy_turn;
                            }
                            break;

                        case State.Attacking_multiple:
                            if (player.RecievedNumbers.Count > 0)
                            {

                                if (player.ReturnCheck())
                                {
                                    break;
                                }

                                player.AttackEnemies();
                                for (int i = player.Combat.Enemies.Count - 1; i >= 0; i--)
                                {
                                    Enemy enemy = player.Combat.Enemies[i];
                                    if (enemy.Health <= 0)
                                    {
                                        await player.RecieveLootAsync(enemy.Kill());
                                        player.Combat.Enemies.RemoveAt(i);
                                    }
                                }

                                player.ClearBuffer();
                                player.Bp -= player.BpToUse + 1;

                                if (player.Combat.Enemies.Count <= 0)
                                {
                                    if (player.Area.Length > 1)
                                    {
                                        player.Area.Fight++;
                                        player.Area.Length--;
                                        player.State = State.Battle_over;
                                        break;
                                    }
                                    else if (player.Area.Length == 1)
                                    {
                                        player.State = State.Returning_home;
                                        break;
                                    }
                                }
                                player.State = State.Enemy_turn;
                            }
                            break;

                        case State.Battle_over:
                            player.SendMessage($"You won the battle! there are {player.Area.MaxLength - player.Area.Fight} fights left. you can use items to heal up or you can keep going.\nHP: {player.Health}/{player.MaxHealth}.", true, Emote.Sword, Emote.Bag, Emote.Flag);
                            player.State = State.At_camp;
                            player.ReturnState = State.At_camp;
                            break;

                        case State.At_camp:
                            if (player.RecievedEmotes.Count > 0)
                            {
                                if (player.RecievedEmotes.Contains(Emote.Sword))
                                {
                                    player.State = State.Begin_battle;
                                }
                                else if (player.RecievedEmotes.Contains(Emote.Bag))
                                {
                                    await player.User.SendMessageAsync(Text.GetInventory(player, "Carried materials"));
                                    player.LastMessage = player.User.SendMessageAsync(Text.GetInventory(player, "Carried items")).Result;

                                    player.RecievedEmotes.Clear();

                                    player.GetNum("Items");

                                    player.State = State.Use_item_at_camp;
                                }
                            }
                            break;

                        case State.Use_item_at_camp:
                            if (player.RecievedEmotes.Count > 0)
                            {
                                if (player.ReturnCheck())
                                {
                                    break;
                                }

                                player.UseItem();

                                player.SendMessage($"Do you want to heal some more or continue adventuring?\nHP: {player.Health}/{player.MaxHealth}.", true, Emote.Sword, Emote.Bag, Emote.Flag);

                                player.State = State.At_camp;
                            }
                            break;

                        case State.Enemy_turn:
                            foreach (var enemy in player.Combat.Enemies)
                            {
                                if (enemy.Bonus > 0)
                                {
                                    enemy.Bonus -= 1;
                                }

                                player.Damage(enemy.Attack);
                            }

                            player.State = State.Pre_player_turn;
                            break;

                        case State.Returning_home:

                            if (player.CMaterials.Count > 0)
                            {
                                player.UnlockArea(player.Area);
                            }

                            foreach (var item in player.CMaterials)
                            {
                                player.SMaterials.Add(item);
                            }
                            player.CMaterials.Clear();
                            player.SortList();

                            player.Restore();
                            player.ShowHome();

                            player.State = State.Home;
                            break;

                        case State.Home:
                            if (player.RecievedEmotes.Contains(Emote.Bag))
                            {
                                player.LastMessage = player.User.SendMessageAsync(Text.GetInventory(player, "Home")).Result;

                                player.RecievedEmotes.Clear();

                                player.ShowHome();
                            }
                            else if (player.RecievedEmotes.Contains(Emote.Sword))
                            {
                                player.ReturnState = State.Returning_home;

                                player.LastMessage = player.User.SendMessageAsync(Text.GetAreas(player)).Result;

                                player.State = State.Prepare_to_go_out;
                            }
                            break;

                        case State.Prepare_to_go_out:
                            player.GetNum("Areas");
                            player.State = State.Going_out;
                            break;

                        case State.Going_out:
                            if (player.RecievedEmotes.Count > 0)
                            {

                                string emotes = "";

                                foreach (var emote in player.RecievedEmotes)
                                {
                                    emotes += emote.Name;
                                }

                                if (player.ReturnCheck())
                                {
                                    return;
                                }

                                for (int i = 0; i < Emote.Numbers.Length; i++)
                                {
                                    IEmote number = Emote.Numbers[i];

                                    if (emotes.Contains(number.Name))
                                    {
                                        player.Area = new Area(player.UnlockedAreas[i - 1]);
                                        player.State = State.Begin_battle;
                                    }
                                }
                            }
                            break;

                        case State.Dead:
                            await player.User.SendMessageAsync("Your body turns to dust, you lose all carried materials and you respawn in the town.");
                            player.CMaterials.Clear();
                            player.State = State.Returning_home;
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private static void ConsoleLog(List<Player> players)
        {
            string output = "Debug:\n";
            for (int i = 0; i < players.Count; i++)
            {
                Player player = (Player)players[i];
                output += $"Player {i + 1}: {player.ID}, {player.Hashname}.\nState: {player.State}.\n";
                output += $"Health: {player.Health}/{player.MaxHealth}, BP: {player.Bp}/{3}.\n";

                output += Text.GetEnemy(player) + "\n\n";

                output += Text.GetCItems(player) + "\n";
                output += Text.GetCMaterials(player) + "\n";
                output += Text.GetSItems(player);
                output += Text.GetSMaterials(player);
                output += "\n\n";
            }
            if (Program.debugHolder != output)
            {
                Console.Clear();
                Console.WriteLine(output);
                Program.debugHolder = output;
            }
        }
    }
}
