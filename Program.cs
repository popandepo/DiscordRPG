using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPG
{
    class Program
    {
        public static DiscordSocketClient _client;
        public static List<Player> players = new List<Player>();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Initiating...");
            await BotInit();
            Console.WriteLine("Initiated!");
            Console.ReadLine();
        }

        /// <summary>
        /// Initiates the bot
        /// </summary>
        /// <returns>Nothing</returns>
        private static async Task BotInit() //starts the bot and initiates all handlers
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig() { AlwaysDownloadUsers = true });

            try
            {
                string token = FileManipulation.ReadFile("BotKey.txt");//Reads the token from file
                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();
                await _client.SetStatusAsync(UserStatus.Online);
            }
            catch (Exception)
            {
                Console.WriteLine("No Botkey found, please contact an administrator. Press any key to try again...");
                Console.ReadKey();
                await BotInit();
            }



            _client.MessageReceived += DiscordHandlers.MessageHandler;//Whenever a message is heard, push it to the message handler
            _client.ReactionAdded += DiscordHandlers.ReactionHandler;//Whenever a reaction is added, push it to the reaction handler
            _client.ReactionRemoved += DiscordHandlers.ReactionHandler;//Whenever a reaction is removed, push it to the reaction handler
        }
    }
}