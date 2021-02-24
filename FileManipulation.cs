using System.IO;

namespace DiscordRPG
{
    public class FileManipulation
    {

        /// <summary>
        /// Reads a file with the given filename
        /// </summary>
        /// <param name="fileName">The name of the file to read</param>
        /// <returns>A string with the contents of the file</returns>
        public static string ReadFile(string fileName)
        {
            var filePath = Path.GetFullPath(fileName);

            string output = File.ReadAllText(filePath);

            return output;
        }
    }
}