using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Tools;
using Microsoft.EntityFrameworkCore.SqlServer;
using DiscordRPG;

namespace DiscordRPG
{
    class Program
    {
        public static DiscordSocketClient _client;
        public static List<Player> players = new List<Player>();
        public static DatabaseHandler DbHandler = new DatabaseHandler();
        private CommandService _commands;
        private CommandHandler _handler;

        public static void Main(string[] args)
        {
            Console.WriteLine("Initiating...");
            new Program().BotInit().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Initiates the bot
        /// </summary>
        /// <returns>Nothing</returns>
        public async Task BotInit() //starts the bot and initiates all handlers
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig() { AlwaysDownloadUsers = true });
            _commands = new CommandService();
            _handler = new CommandHandler(_client, _commands);

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
            Console.WriteLine("Initiated!");

            _client.ReactionAdded += ReactionHandler.Send;//Whenever a reaction is added, push it to the reaction handler
            _client.ReactionRemoved += ReactionHandler.Send;//Whenever a reaction is removed, push it to the reaction handler
            //_client.Ready += TestDatabase;

            await Task.Delay(-1);
        }
    }
}