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
        public bool Verbose { get; set; } = false;
        // Add if Verbose for all methods

        /// <summary>
        /// Translates the object into JSON, fields, properties and methods
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>JSON formatted String</returns>
        public static string ObjectToJson(Object obj)
        {
            string jsonOut = $"{{\"name\":\"{obj.GetType().Name}\",";
            jsonOut += GetFields(obj) + ",";
            jsonOut += GetProperties(obj) + ",";
            jsonOut += GetMethods(obj);

            jsonOut += "}";
            return jsonOut;
        }

        /// <summary>
        /// Internally used
        /// Translates the objects methods into JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>JSON formatted String</returns>
        private static string GetMethods(object obj)
        {
            // Not needed for project
            string jsonString = "\"methods\":[";
            foreach (var method in obj.GetType().GetMethods())
            {
                var methodInputs = "[";
                bool gotInputs = false;
                foreach (var inputVar in method.GetParameters())
                {
                    gotInputs = true;
                    methodInputs += $"{{\"name\":\"{inputVar.Name}\",\"type\":\"{inputVar.ParameterType.Name.Replace("`1", "")}\"}},";
                }
                if (gotInputs) methodInputs = methodInputs.Remove(methodInputs.Length - 1, 1);
                methodInputs += "]";

                var methodOutput = $"";
                var methodBody = "";

                try
                {
                    methodBody = method.GetMethodBody().ToString();
                }
                catch (Exception e)
                {
                    // Threw a exeption, so do nothing. 
                }
            
                var methodReturnType = method.ReturnType.Name.Replace("`1", "");
                jsonString += $"{{\"name\":\"{method.Name}\", \"inputs\":{methodInputs}, \"body\":\"{methodBody}\",\"returnType\":\"{methodReturnType}\"}},";
            }
            jsonString = jsonString.Remove(jsonString.Length - 1, 1);
            jsonString += "]";
            return jsonString;
        }

        /// <summary>
        /// Gets the Properties when run in static context
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="standalone"></param>
        /// <returns>Json Formatted string</returns>
        public static string GetProperties(object obj, bool standalone = true)
        {
            string jsonString = "{\"properties\":[";
            foreach (var property in obj.GetType().GetProperties())
            {

                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
                        && !typeof(string).IsAssignableFrom(property.PropertyType))
                { // Checks if the property is an enumerable. (List<T>)
                    var fieldValue = property.GetValue(obj);
                    var fieldType = $"\"{property.PropertyType.Name}";
                    var fieldContent = "[";

                    if (fieldValue is null)
                    {
                        fieldType += "<null>\"";
                        fieldContent += "]";
                    }
                    else
                    {
                        var entries = (IEnumerable)property.GetValue(obj);
                        foreach (var entry in entries) // A stupid hack because i'm too fucking tired to think properly
                        {
                            fieldType += $"<{entry.GetType().Name}>\"";
                            break;
                        }
                        foreach (var entry in (IEnumerable)property.GetValue(obj))
                        {
                            if (entry is ValueType)
                            {
                                fieldContent += $"{entry},";
                            }
                            else
                            {
                                fieldContent += $"\"{entry}\",";
                            }

                        }

                        fieldContent = fieldContent.Remove(fieldContent.Length - 1, 1);
                        fieldContent += "]";
                    }
                    jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldContent},\"type\":{fieldType.Replace("`1", "")}}},";
                }
                else
                {
                    var fieldValue = property.GetValue(obj);
                    if (typeof(ValueType).IsAssignableFrom(property.PropertyType))
                    {
                        if (fieldValue is bool)
                        {
                            jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldValue.ToString().ToLower()},\"type\":\"{property.PropertyType.Name.Replace("`1", "")}\"}},";
                        }
                        else
                        {
                            jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldValue},\"type\":\"{property.PropertyType.Name.Replace("`1", "")}\"}},";
                        }
                    }
                    else
                    {
                        jsonString += $"{{\"name\":\"{property.Name}\",\"value\":\"{fieldValue.ToString().Replace("`1", "")}\",\"type\":\"{property.PropertyType.Name.Replace("`1", "")}\"}},";
                    }
                }
            }
            jsonString = jsonString.Remove(jsonString.Length - 1, 1);
            jsonString += "]}";
            return jsonString;
        }

        /// <summary>
        /// Internal
        /// Gets the properties on the object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>formatted string to be inserted into json</returns>
        private protected static string GetProperties(object obj)
        {
            string jsonString = "\"properties\":[";
            foreach (var property in obj.GetType().GetProperties())
            {

                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
                        && !typeof(string).IsAssignableFrom(property.PropertyType))
                { // Checks if the property is an enumerable. (List<T>)
                    var fieldValue = property.GetValue(obj);
                    var fieldType = $"\"{property.PropertyType.Name}";
                    var fieldContent = "[";

                    if (fieldValue is null)
                    {
                        fieldType += "<null>\"";
                        fieldContent += "]";
                    }
                    else
                    {
                        var entries = (IEnumerable)property.GetValue(obj);
                        foreach (var entry in entries) // A stupid hack because i'm too fucking tired to think properly
                        {
                            fieldType += $"<{entry.GetType().Name}>\"";
                            break;
                        }
                        foreach (var entry in (IEnumerable)property.GetValue(obj))
                        {
                            if (entry is ValueType)
                            {
                                fieldContent += $"{entry},";
                            }
                            else
                            {
                                fieldContent += $"\"{entry}\",";
                            }

                        }

                        fieldContent = fieldContent.Remove(fieldContent.Length - 1, 1);
                        fieldContent += "]";
                    }
                    jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldContent},\"type\":{fieldType.Replace("`1", "")}}},";
                }
                else
                {
                    var fieldValue = property.GetValue(obj);
                    if (typeof(ValueType).IsAssignableFrom(property.PropertyType))
                    {
                        if (fieldValue is bool)
                        {
                            jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldValue.ToString().ToLower()},\"type\":\"{property.PropertyType.Name.Replace("`1", "")}\"}},";
                        }
                        else
                        {
                            jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldValue},\"type\":\"{property.PropertyType.Name.Replace("`1", "")}\"}},";
                        }
                    }
                    else
                    {
                        jsonString += $"{{\"name\":\"{property.Name}\",\"value\":\"{fieldValue.ToString().Replace("`1", "")}\",\"type\":\"{property.PropertyType.Name.Replace("`1", "")}\"}},";
                    }
                }
            }
            jsonString = jsonString.Remove(jsonString.Length - 1, 1);
            jsonString += "]";
            return jsonString;
        }

        private static bool IsVal(Object x)
        {
            if (typeof(ValueType).IsAssignableFrom((System.Type)x))
            {
                return true;
            }
            return false;
        }

        private protected static string GetFields(object obj)
        {
            string jsonString = "\"fields\":[";
            foreach (var property in obj.GetType().GetFields())
            {
                if (typeof(IEnumerable).IsAssignableFrom(property.FieldType)
                        && !typeof(string).IsAssignableFrom(property.FieldType))
                { // Checks if the property is an enumerable. (List<T>)
                    var fieldValue = property.GetValue(obj);
                    var fieldType = $"\"{property.FieldType.Name}";
                    var fieldContent = "[";
                    if (fieldValue is null)
                    {
                        fieldType += "<null>\"";
                        fieldContent += "]";
                    }
                    else
                    {
                        var entries = (IEnumerable)property.GetValue(obj);
                        foreach (var entry in entries) // A stupid hack because i'm too fucking tired to think properly
                        {
                            fieldType += $"<{entry.GetType().Name}>\"";
                            break;
                        }
                        foreach (var entry in (IEnumerable)property.GetValue(obj))
                        {
                            if (entry is ValueType)
                            {
                                fieldContent += $"{entry},";
                            }
                            else
                            {
                                fieldContent += $"\"{entry}\",";
                            }

                        }

                        fieldContent = fieldContent.Remove(fieldContent.Length - 1, 1);
                        fieldContent += "]";
                    }
                    jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldContent},\"type\":{fieldType.Replace("`1", "")}}},";
                }
                else
                {
                    var fieldValue = property.GetValue(obj);
                    if (typeof(ValueType).IsAssignableFrom(property.FieldType))
                    {
                        if (fieldValue is bool)
                        {
                            jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldValue.ToString().ToLower()},\"type\":\"{property.FieldType.Name.Replace("`1", "")}\"}},";
                        }
                        else
                        {
                            jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldValue},\"type\":\"{property.FieldType.Name.Replace("`1", "")}\"}},";
                        }
                    }
                    else
                    {
                        jsonString += $"{{\"name\":\"{property.Name}\",\"value\":\"{fieldValue.ToString().Replace("`1", "")}\",\"type\":\"{property.FieldType.Name.Replace("`1", "")}\"}},";
                    }
                }
            }
            jsonString = jsonString.Remove(jsonString.Length - 1, 1);
            jsonString += "]";
            return jsonString;
        }

        /// <summary>
        /// When run in static context
        /// Gets the fields on the object and returs as json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="standalone"></param>
        /// <returns>JSON formatted string</returns>
        public static string GetFields(object obj, bool standalone = true)
        {
            string jsonString = "{\"fields\":[";
            foreach (var property in obj.GetType().GetFields())
            {
                if (typeof(IEnumerable).IsAssignableFrom(property.FieldType)
                        && !typeof(string).IsAssignableFrom(property.FieldType))
                { // Checks if the property is an enumerable. (List<T>)
                    var fieldValue = property.GetValue(obj);
                    var fieldType = $"\"{property.FieldType.Name}";
                    var fieldContent = "[";
                    if (fieldValue is null)
                    {
                        fieldType += "<null>\"";
                        fieldContent += "]";
                    }
                    else
                    {
                        var entries = (IEnumerable)property.GetValue(obj);
                        foreach (var entry in entries) // A stupid hack because i'm too fucking tired to think properly
                        {
                            fieldType += $"<{entry.GetType().Name}>\"";
                            break;
                        }
                        foreach (var entry in (IEnumerable)property.GetValue(obj))
                        {
                            if (entry is ValueType)
                            {
                                fieldContent += $"{entry},";
                            }
                            else
                            {
                                fieldContent += $"\"{entry}\",";
                            }

                        }

                        fieldContent = fieldContent.Remove(fieldContent.Length - 1, 1);
                        fieldContent += "]";
                    }
                    jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldContent},\"type\":{fieldType.Replace("`1", "")}}},";
                }
                else
                {
                    var fieldValue = property.GetValue(obj);
                    if (typeof(ValueType).IsAssignableFrom(property.FieldType))
                    {
                        if (fieldValue is bool)
                        {
                            jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldValue.ToString().ToLower()},\"type\":\"{property.FieldType.Name.Replace("`1", "")}\"}},";
                        }
                        else
                        {
                            jsonString += $"{{\"name\":\"{property.Name}\",\"value\":{fieldValue},\"type\":\"{property.FieldType.Name.Replace("`1", "")}\"}},";
                        }
                    }
                    else
                    {
                        jsonString += $"{{\"name\":\"{property.Name}\",\"value\":\"{fieldValue.ToString().Replace("`1", "")}\",\"type\":\"{property.FieldType.Name.Replace("`1", "")}\"}},";
                    }
                }
            }
            jsonString = jsonString.Remove(jsonString.Length - 1, 1);
            jsonString += "]}";
            return jsonString;
        }

        /// <summary>
        /// Creates a ExpandoObject from the inputted json formatted string
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns>ExpoandoObject representation of the input</returns>
        public static dynamic CreateObjectFromJson(string jsonString)
        {
            var expand = new ExpandoObject() as IDictionary<string, Object>;
            Dictionary<string, string> translated = TranslateJson(jsonString);
            foreach (var entry in translated)
            {
                //Console.WriteLine($"key: {entry.Key}\t val: {entry.Value}");
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
