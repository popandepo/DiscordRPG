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
                                        player.Combat.Enemies.Add(new Enemy("Bidoof", 5, 5, 5, 5, 1, new Material("Bidoof Head", 1, 10, "Normal", 1)));
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
                            player.State = "ATTACKING ONE";
                            break;

                        case "ATTACKING ONE":
                            if (player.RecievedEmotes.Count > 0)
                            {
                                player.AttackEnemy();
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
