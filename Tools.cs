using System;

namespace UsefulTools
{
    public static class Tools
    {

        public static string GetChar()
        {

            return Console.ReadKey().KeyChar.ToString();
        }

        public static string GetString()
        {
            return Console.ReadLine();
        }

        public static int[] Range(int startPoint = 0, int endPoint = 0)
        {
            int arrayLength = Math.Max(startPoint, endPoint) - Math.Min(startPoint, endPoint) + 1;
            int[] rangeOut = new int[arrayLength];
            if (startPoint < endPoint)
            {
                for (int i = 0; i < arrayLength; i++)
                {
                    rangeOut[i] = i + startPoint;
                }
            }
            else
            {
                for (int i = 0; i < arrayLength; i++)
                {
                    rangeOut[i] = startPoint - i;
                }
            }

            return rangeOut;
        }

        public static string Convert<T>(T[] input, string sepString = ",") //CONVERTS AN ARRAY INTO A STRING SEPARATED BY WHATEVER CHARACTER YOU CHOOSE. BY DEFAULT ","
        {
            string output = "";
            foreach (var entry in input)
            {
                output += entry;
                output += sepString;
            }
            output = output.Substring(0, output.Length - sepString.Length);
            return output;
        }

        public static T[] Append<T>(T[] inputArray, params T[] input) //ADDS A NEW FIELD TO AN ARRAY AND FILLS IT
        {
            int posIndex = 0;
            T[] output = new T[inputArray.Length + input.Length];
            foreach (var item in inputArray)
            {
                output[posIndex] = item;
                posIndex++;
            }
            foreach (var item in input)
            {
                output[posIndex] = item;
                posIndex++;
            }
            return output;
        }

        public static string Replace(string modifier, string input, string find, string replace) //REPLACES TEXT IN A STRING
        {
            string output = "";
            string tempstring = input;
            int location;
            int length = replace.Length;

            switch (modifier)
            {
                case "first":
                    location = input.IndexOf(find);
                    output = Edit(input, replace, location, length);
                    break;
                case "last":
                    location = input.LastIndexOf(find);
                    output = Edit(input, replace, location, length);
                    break;
                case "all":
                    while (tempstring.Contains(find))
                    {
                        tempstring = tempstring.Replace(find, replace);
                    }
                    output = tempstring;
                    break;
                default:
                    Console.WriteLine("Invalid modifier. Valid modifiers are \"first\", \"last\" and \"all\".");
                    break;
            }

            return output;
        }

        private static string Edit(string input, string replace, int location, int length)
        {
            input = input.Remove(location, length);
            string output = input.Insert(location, replace);
            return output;
        }
    }
}
