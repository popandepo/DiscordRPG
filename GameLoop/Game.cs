using System;

namespace DiscordRPG
{
    class Game
    {
        public static void GameLoop()
        {
            while (true)
            {
                foreach (var player in Program.players)
                {
                    switch (player.State)
                    {
                        case "BEGIN BATTLE":
                            var enemies = player.Area.Pull();
                            foreach (var enemy in enemies)
                            {
                                player.Combat.Enemies.Add(enemy);

                                if (player.ID == 236267360502153217) //easter egg don't worry
                                {
                                    var rand = new Random();
                                    if (rand.Next(1,101)==1)
                                    {
                                        player.Combat.Enemies.RemoveAt(player.Combat.Enemies.Count);
                                        player.Combat.Enemies.Add(new Enemy("Bidoof", 5, 5, 5, 5, 1, new Material("Bidoof Head", 1, 10, "Normal", 1)));
                                    }
                                }
                            }

                            player.Act();

                            player.State = "AWAIT BATTLE";

                            break;
                        case "AWAIT BATTLE":
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
