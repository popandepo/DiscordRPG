using Discord.WebSocket;
using System;
namespace DiscordRPG
{
    public class UserStorage
    {
        public ulong[] ID
        { get; set; }

        public SocketUser[] SocketUser
        { get; set; }

        public string[] UserName
        { get; set; }

        public string[] HashName
        { get; set; }

        public bool[] IsAdmin
        { get; set; }


        public UserStorage()
        {

            ID = new ulong[] { 235921495291854850 };
            SocketUser = new SocketUser[] { Program._client.GetGuild(800973317032771586).GetUser(235921495291854850) };
            UserName = new string[] { "popandepo" };
            HashName = new string[] { "popandepo#2378" };
            IsAdmin = new bool[] { true };
        }
        public string ToString(int index = -1)
        {
            string output = "";

            if (index != -1)
            {
                output += ID[index].ToString();
                output += ", ";
                output += UserName[index];
                output += ", ";
                output += HashName[index];
                output += ".";
            }
            else
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    output += $"{i + 1}: >{ID[i]}, {UserName[i]}, {HashName[i]}<\n";
                }
            }
            return output;

        }
        public int Find<T>(T input)
        {
            int index = -1;
            try
            {
                index = Array.IndexOf(ID, input);
            }
            catch
            {
                index = Array.IndexOf(UserName, input);
            }
            return index;

        }
        public int Edit<T, U>(T searchterm, Attributes target, U replacement)
        {
            int index = Find(searchterm);
            try
            {
                index = Int32.Parse(searchterm.ToString());
                index--;
            }
            catch
            {

            }
            switch (target)
            {
                case Attributes.ID:
                    ID[index] = ulong.Parse(replacement.ToString());
                    return index;
                case Attributes.UserName:
                    UserName[index] = replacement.ToString();
                    return index;
                case Attributes.HashName:
                    HashName[index] = replacement.ToString();
                    return index;
                case Attributes.IsAdmin:
                    IsAdmin[index] = bool.Parse(replacement.ToString());
                    return index;
                default:
                    return -1;
            }
            return index;
        }
        public int Add(ulong id = 0, SocketUser socketUser = null, string userName = "0", string hashName = "0", bool isAdmin = false)
        {
            int index = Find(id);
            if (index == -1)
            {
                ID = Tools.Append(ID, id);
                SocketUser = Tools.Append(SocketUser, socketUser);
                UserName = Tools.Append(UserName, userName);
                HashName = Tools.Append(HashName, hashName);
                IsAdmin = Tools.Append(IsAdmin, isAdmin);

                return ID.Length - 1;

            }
            else return index;

        }
    }
}
