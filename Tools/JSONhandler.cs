using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG
{
    public class JSONhandler<T>
    {
        public static string ObjectToJson(Object obj)
        {
            string jsonOut = "{";

            foreach (var property in obj.GetType().GetProperties())
            {
                //Console.WriteLine(property);
                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
                        && !typeof(string).IsAssignableFrom(property.PropertyType))
                { // Checks if the property is an enumerable. (List<T>)
                    jsonOut += $"\"{property.Name}\":[";

                    foreach (var item in (IEnumerable)property.GetValue(obj))
                    {
                        //if (typeof(string).IsAssignableFrom(property.PropertyType))
                        if (item.PropertyType.Name == "string")
                        { // Value is a string
                            jsonOut += $"\"{item}\",";
                        }
                        else
                        {
                            jsonOut += $"{item},";
                        }

                    }
                    jsonOut = jsonOut.Remove(jsonOut.Length - 1);
                    jsonOut += $"],";
                }
                else
                {
                    //if (typeof(string).IsAssignableFrom(property.PropertyType))
                    if (property.PropertyType.Name == "string")
                    { // The value is a string
                        jsonOut += $"\"{property.Name}\":\"{property.GetValue(obj)}\",";
                    }
                    else
                    {
                        jsonOut += $"\"{property.Name}\":{property.GetValue(obj)},";
                    }

                }
            }
            jsonOut = jsonOut.Remove(jsonOut.Length - 1);
            jsonOut += "}";
            return jsonOut;
        }

        /// <summary>
        /// If the unknown type matches the typename, return true
        /// </summary>
        /// <param name="unknown"></param>
        /// <param name="typename"></param>
        /// <returns></returns>
        private static bool CheckType(T unknown, string typename)
        {
            return unknown.GetType().Name == typename;
        }
    }
}
