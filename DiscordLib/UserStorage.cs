using System;
using UsefulTools;
namespace DiscordLib
{
    public class UserStorage
    {
        public ulong[] ID
        { get; set; }

        public string[] UserName
        { get; set; }

        public string[] AtName
        { get; set; }

        public bool[] IsAdmin
        { get; set; }

        public UserStorage()
        {
            ID = new ulong[] { 235921495291854850 };
            UserName = new string[] { "popandepo" };
            AtName = new string[] { "popandepo#2378" };
            IsAdmin = new bool[] { true };
        }
        public string MyToString(int index = -1)
        {
            string output = "";

            output += ID[index].ToString();
            output += ", ";
            output += UserName[index];
            output += ", ";
            output += AtName[index];
            output += ".";
            return output;

        }
        public int Find<T>(T input)
        {
            int index = -1;
            if (input.GetType().ToString() == "ulong")
            {
                index = Array.IndexOf(ID, input);
            }
            else if (input.GetType().ToString() == "string")
            {
                index = Array.IndexOf(UserName, input);
            }
            return index;

        }
        public int Edit<T,U>(T searchterm, Attributes attributes, U replacement)
        {
            int index = Find(searchterm);
            try
            {
                index = int.Parse(searchterm.ToString());
            }
            catch
            {

            }
            switch (target)
            {
                case "id":
                    ID[index] = ulong.Parse(replacement.ToString());
                    return index;
                case "username":
                    UserName[index] = replacement.ToString();
                    return index;
                case "atname":
                    AtName[index] = replacement.ToString();
                    return index;
                case "isadmin":
                    IsAdmin[index] = bool.Parse(replacement.ToString());
                    return index;
                default:
                    return -1;
            }
            return index;
        }
        public int Add(ulong id = 0, string userName = "0", string atName = "0", bool isAdmin = false)
        {
            int index = Find(id);
            if (index == -1)
            {
                ID = Tools.Append(ID, id);
                UserName = Tools.Append(UserName, userName);
                AtName = Tools.Append(AtName, atName);
                IsAdmin = Tools.Append(IsAdmin, isAdmin);
                return ID.Length - 1;

            }
            else return index;

        }
    }
}
