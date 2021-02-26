using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG
{
    public class JSONhandler
    {
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


        public Object CreateObjectFromJson(string jsonString)
        {
            return new Object();
        }
    }
}
