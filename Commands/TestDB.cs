using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRPG;

namespace DiscordRPG.Commands
{
    public class TestDB : ModuleBase<SocketCommandContext>
    {
        [Command("TestDB")] // RequireUserPermission(permission)
        [Alias("TestDB")]
        [Summary("")]
        public async Task TestDBAsync()
        {
            Console.WriteLine("In testdb");
            var userid = Context.User.Id;
            var p = new Player(userid);
            Console.WriteLine("Going to add");
            await Program.DbHandler.AddUserToDatabase(p);
            Console.WriteLine("ADDING");
        }
    }
}
