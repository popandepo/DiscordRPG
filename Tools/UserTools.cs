#nullable enable

using System;
using System.IO;
using System.Threading.Tasks;

namespace DiscordRPG
{
    public class UserTools
    {

        public static Player? IsRegistered(ulong id)
        {
            return Program.players.Find(i => i.ID == id);
        }

        public static bool? IsAdmin(ulong id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves all users in Program.players to Json
        /// </summary>
        public static Task SaveUsersToJSON()
        {
            var outstring = "{";
            foreach (var player in Program.players)
            {
                outstring += $"\"{player.ID}\":{JSONhandler.GetProperties(player)},";
            }
            outstring = outstring.Remove(outstring.Length - 1, 1);
            outstring += "}";
            Console.WriteLine(outstring);
            using (StreamWriter outfile = new StreamWriter("Users.json"))
            {
                outfile.WriteLine(outfile);
            }
            return Task.CompletedTask;
        }
    }
}
