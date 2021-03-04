using System;
using System.Threading.Tasks;

namespace DiscordRPG
{
    class Game
    {
        public static async void GameLoop()
        {
            while (true)
            {
                await Task.Delay(10);
                foreach (var player in Program.players)
                {
                    switch (player.State)
                    {
                        case "BEGIN BATTLE":
                            var enemies = player.Area.Pull();
                            foreach (var enemy in enemies)
                            {
                                enemy.Bonus = 5;
                                player.Combat.Enemies.Add(enemy);

                                if (player.ID == 236267360502153217) //easter egg
                                {
                                    var rand = new Random();
                                    if (rand.Next(1, 101) == 1)
                                    {
                                        player.Combat.Enemies.RemoveAt(player.Combat.Enemies.Count);
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
                            player.Act();

                            // setup for the player turn

                            player.State = "PLAYER TURN";
                            break;

                        case "PLAYER TURN":

                            if (player.RecievedEmotes.Contains(Emote.Sword))
                            {
                                player.State = "GET SINGLE TARGET";
                            }
                            break;

                        case "GET SINGLE TARGET":
                            player.GetNum();
                            player.State = "AWAITING NUMBER";
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

                        default:
                            break;
                    }
                }
            }
        }
    }
}
