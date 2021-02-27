using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace DiscordRPG
{
    public class JSONhandler
    {
        // Add if Verbose for all methods

        /// <summary>
        /// Translates a object into a JSON formatted string of it's parameters
        /// </summary>
        /// <param name="obj">Input Object</param>
        /// <returns>JSON string</returns>
        public static string ObjectToJson(Object obj)
        {
            string jsonOut = "{";

            foreach (var property in obj.GetType().GetProperties())
            {
                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
                        && !typeof(string).IsAssignableFrom(property.PropertyType))
                { // Checks if the property is an enumerable. (List<T>)
                    jsonOut += $"\"{property.Name}\":[";
                    if (property.GetValue(obj) is null)
                    {
                        jsonOut += "],";
                        continue;
                    }
                    foreach (var item in (IEnumerable)property.GetValue(obj))
                    {
                        if (item is ValueType)
                        { // Value is a string
                            if (item is bool)
                            {
                                jsonOut += $"{item.ToString().ToLower()},";
                            }
                            else
                            {
                                jsonOut += $"{item},";
                            }
                        }
                        else
                        {
                            jsonOut += $"\"{item}\",";
                        }

                    }
                    jsonOut = jsonOut.Remove(jsonOut.Length - 1);
                    jsonOut += $"],";
                }
                else
                {
                    if (typeof(ValueType).IsAssignableFrom(property.PropertyType))
                    { // The value is a Value
                        if (property.GetValue(obj) is bool)
                        {
                            jsonOut += $"\"{property.Name}\":{property.GetValue(obj).ToString().ToLower()},";
                        }
                        else
                        {
                            jsonOut += $"\"{property.Name}\":{property.GetValue(obj)},";
                        }
                    }
                    else
                    {
                        jsonOut += $"\"{property.Name}\":\"{property.GetValue(obj)}\",";
                    }
                }
            }
            jsonOut = jsonOut.Remove(jsonOut.Length - 1);
            jsonOut += "}";
            return jsonOut;
        }


        /// <summary>
        /// Creates a dynamic object from a JSON formatted input string.
        /// Parameters are created automatically, but not functions atm. 
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns>DynamicObject representation from the inputted JSON</returns>
        public static dynamic CreateObjectFromJson(string jsonString)
        {
            var expand = new ExpandoObject() as IDictionary<string, Object>;
            Dictionary<string, string> translated = TranslateJson(jsonString);
            foreach (var entry in translated)
            {
                //Console.WriteLine($"key: {entry.Key}\t val: {entry.Value}");
                Console.WriteLine(entry.Key);
                expand.Add(entry.Key, entry.Value);
            }
            return expand;
        }

        /// <summary>
        /// Translates the json string into dictionary containing variable name and value
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        private static Dictionary<string, string> TranslateJson(string jsonString)
        {
            var content = jsonString.Substring(1, jsonString.Length - 2);
            var output = new Dictionary<string, string>();
            var elements = new List<string>();
            string element = "";
            string arrayContent = "";
            bool inArray = false;
            foreach (var character in content)
            {
                if (character == '[')
                {
                    // Start of an array
                    inArray = true;
                }
                else if (character == ']')
                {
                    // End of an array
                    inArray = false;
                    element += arrayContent;
                }
                else
                {
                    if (inArray)
                    {
                        if (character != '\\' || character != '"') arrayContent += character;
                    }
                    else
                    {
                        if (character != ',' || character != '\\' || character != '"') element += character;
                    }
                }
                if (character == ',' && !inArray)
                {
                    elements.Add(element);
                    element = "";
                }
            }
            var el = elements.Select(i => i.Replace(@"\\", "")).ToList();
            //el.ForEach(Console.WriteLine);

            // Split the formatted list

            foreach (var line in el)
            {
                var split = line.Split(':');
                output.Add(split[0].Replace("\"", ""), split[1].Remove(split[1].Length - 1, 1));
            }

            return output;
        }
    }
}
