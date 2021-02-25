using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPG
{
    class CommandHandler
    {
        public static Task Send(ulong id, string command)
        {
            var author = Program._client.GetUser(id);
            if (command.Contains("!join")) //Separate commands into a command handler and find an intelligent way to deal with it
            {
                Program.players.Add(new Player(author.Id));
                foreach (var player in Program.players) //IS THERE A BETTER WAY TO FIND A PLAYER WITH A SINGLE ID?
                {
                    if (player.ID == author.Id)
                    {
                        MessageHandler.SendMessage(player, "You have been added to the list of players, please use this channel for any future messages");
                        Console.WriteLine($"{player.Hashname} has been added");
                    }
                }
            }
            else if (command.Contains("!leave"))
            {
                foreach (var player in Program.players)
                {
                    if (player.ID == author.Id)
                    {
                        Console.WriteLine($"{player.Hashname} has left");
                        Program.players.Remove(player);
                    }
                }
            }
            else if (command.Contains("!test")) //REMOVE AFTER TESTING IS DONE
            {
                foreach (var player in Program.players)
                {
                    if (player.ID == author.Id)
                    {
                        MessageHandler.SendMessage(player, "I recieved a test order, responding as ordered!");
                        Console.WriteLine($"{player.Hashname} sent a test message");
                    }
                }
            }
            else if (command.Contains("!edit"))
            {
                foreach (var player in Program.players)
                {
                    if (player.ID == author.Id)
                    {
                        MessageHandler.EditMessage(player, command.Remove(0, 5));
                        Console.WriteLine($"{player.Hashname} edited a message");
                    }
                }
            }
            else if (command.Contains("!loot")) //GIVE THE PLAYER SOME LOOT TO TEST HOW THE PROGRAM HANDLES IT //REMOVE AFTER TESTING IS DONE
            {
                foreach (var player in Program.players)
                {
                    if (player.ID == author.Id)
                    {
                        List<ILootables> loot = new List<ILootables>();
                        loot.Add(new Item("testitem", 1, 1, "TEST", 1));
                        loot.Add(new Material("testmaterial", 1, 1, "Normal"));

                        Console.WriteLine($"{player.Hashname} looted some stuff");

                        player.RecieveLoot(loot);

                    }
                }


            }

            return Task.CompletedTask;
        }
    }
}
