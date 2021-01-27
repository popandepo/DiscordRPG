using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;
namespace DiscordRPG
{
    public class DiscordTools
    {
        public static async Task ReactionHandler(Cacheable<IUserMessage, ulong> message, ISocketMessageChannel channel, SocketReaction reaction)//fires when anyone reacts to a message
        {
            if (!reaction.User.Value.IsBot)
            {

                SocketUser temp = Program._client.GetUser(reaction.UserId);

                int index = Program.group.Add(reaction.UserId, temp, temp.Username, temp.ToString());

                await Program.group.SocketUser[1].SendMessageAsync($"{Program.group.UserName[index]}, who has an ID of {Program.group.ID[index]} has reacted to the message which has the ID {reaction.MessageId} in {reaction.Channel} with {reaction.Emote}");
            }
        }

        public static async Task MessageHandler(SocketMessage message) //fires when anyone sends a message
        {
            if (!message.Author.IsBot)
            {
                int index = Program.group.Add(message.Author.Id, Program._client.GetUser(message.Author.Id), message.Author.Username, message.Author.ToString());

                await Program.group.SocketUser[1].SendMessageAsync($"{message.Author.Username}, who has an ID of {message.Author.Id} has sent the message \"{message.Content}\" with the ID {message.Id} in {message.Channel}");

                if (message.Content.StartsWith('|'))
                {
                    string[] command = message.Content.Split('|');
                    switch (command[1].Trim())
                    {
                        case "say":
                            index = Program.group.Find(message.Author.Id);
                            if (Program.group.IsAdmin[index])
                            {
                                string messageToSend = command[2].Trim();
                                await message.Channel.SendMessageAsync(messageToSend);
                            }
                            else
                            {
                                await message.Channel.SendMessageAsync("fuck you, you're not my dad");
                            }
                            break;

                        case "react":
                            await message.AddReactionAsync(Emojis.Sword);
                            await message.AddReactionAsync(Emojis.Shield);
                            await message.AddReactionAsync(Emojis.Shield2);
                            for (int i = 0; i < 11; i++)
                            {
                                await message.AddReactionAsync(Emojis.Numbers[i]);
                            }
                            await message.AddReactionAsync(Emojis.Bag);
                            await message.AddReactionAsync(Emojis.TurnBack);
                            await message.AddReactionAsync(Emojis.MagicWand);
                            await message.AddReactionAsync(Emojis.CheckMark);
                            await message.AddReactionAsync(Emojis.CrossMark);
                            await message.AddReactionAsync(Emojis.BackButton);
                            await message.AddReactionAsync(Emojis.PlayButton);
                            await message.AddReactionAsync(Emojis.QuestionMark);
                            break;

                        case "kill":
                            index = Program.group.Find(message.Author.Id);
                            if (Program.group.IsAdmin[index])
                            {
                                Program.SafeExit();
                            }
                            await message.Channel.SendMessageAsync($"I'm sorry {message.Author.Username}. I can't let you do that");
                            break;
                        default:
                            Console.WriteLine("a message has been recieved");
                            break;
                    }
                }
            }
        }

        public static async Task<Task> Broadcast(string message) //sends a message to the default channel in all servers
        {
            var temp = Program._client.Guilds;
            foreach (var guild in temp)
            {
                await guild.DefaultChannel.SendMessageAsync(message);
            }
            return Task.CompletedTask;
        }

        public static async Task<Task> InitUserStorage() //starts the user storage
        {
            //Broadcast("I'm online! Harvesting...");
            await Program._client.DownloadUsersAsync(Program._client.Guilds);
            Program.group = new UserStorage();
            Console.WriteLine("Users are downloaded!");
            Program.userStorageInit = true;
            return Task.CompletedTask;
        }

        public static string WriteOrReadFile(string fileName) //reads or writes a file
        {
            string token;

            if (File.Exists(fileName))
            {
                token = File.ReadAllText(fileName);
            }
            else
            {
                Console.WriteLine("Internal BotID missing, please provide BotID");
                token = Console.ReadLine();
                File.WriteAllText(fileName, token);
            }

            return token;
        }
    }
}
