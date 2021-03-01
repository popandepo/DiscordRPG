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
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
