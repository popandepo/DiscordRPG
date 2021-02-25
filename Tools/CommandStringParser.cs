using System;
using System.Linq;

namespace DiscordRPG
{
    public class CommandStringParser
    {
        public char Delimiter { get; set; } = ' '; // Default split delimiter. 
        public char Prefix { get; set; } = '!'; // Default prefix.

        /// <summary>
        ///  Removes the command parameter annoted by the default prefix '!'
        /// </summary>
        /// <param name="input"> Input string </param>
        /// <param name="prefix"> Command prefix </param>
        /// <param name="delim"> Delimiter between message arguments </param>
        /// <returns> Returns the body of the command message </returns>
        public static string RemoveCommand(string input, char prefix = '!', char delim = ' ')
        {
            input = input.TrimStart(' '); // Removes any leading whitespaces
            if (input.Length <= 0) throw new Exception("Input string has no content!");
            if (input[0] != prefix) throw new Exception("Unable to locate command prefix");
            var splitString = input.Split(delim).ToList();
            splitString.RemoveAt(0);
            if (splitString.Count() <= 1) throw new Exception($"No arguments");
            string outputString = splitString.Aggregate((i, j) => i + delim + j);

            return outputString;
        }

        /// <summary>
        /// Removes the command parameter based on preset delimiter and prefix
        /// </summary>
        /// <param name="input"></param>
        /// <returns> Returns the body of the command message </returns>
        public string RemoveCommand(string input)
        {
            input = input.TrimStart(' '); // Removes any leading whitespaces
            if (input.Length <= 0) throw new Exception("Input string has no content!");
            if (input[0] != Prefix) throw new Exception("Unable to locate command prefix");
            var splitString = input.Split(Delimiter).ToList();
            splitString.RemoveAt(0);
            if (splitString.Count() <= 1) throw new Exception($"No arguments");
            string outputString = splitString.Aggregate((i, j) => i + Delimiter + j);

            return outputString;
        }

        /// <summary>
        /// Extracts the command given from the raw input message
        /// </summary>
        /// <param name="input"></param>
        /// <param name="prefix"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public static string ExtractCommand(string input, char prefix = '!', char delim = ' ')
        {
            input = input.TrimStart(' '); // Removes any leading whitespaces
            if (input.Length <= 0) throw new Exception("Input string has no content!");
            if (input[0] != prefix) throw new Exception("Unable to locate command prefix");
            var splitString = input.Split(delim).ToList();
            splitString.RemoveRange(1, splitString.Count() - 1);
            var command = splitString[0].Substring(1);
            return command;
        }

        public string ExtractCommand(string input)
        {
            input = input.TrimStart(' '); // Removes any leading whitespaces
            if (input.Length <= 0) throw new Exception("Input string has no content!");
            if (input[0] != Prefix) throw new Exception("Unable to locate command prefix");
            var splitString = input.Split(Delimiter).ToList();
            splitString.RemoveRange(1, splitString.Count() - 1);
            var command = splitString[0].Substring(1);
            return command;
        }
    }
}
