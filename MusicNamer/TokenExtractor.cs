//#define TE_DEBUG
#define DEBUG

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicNamer
{
    class ExpectedValue
    {
        public int type;
        public string value;
        public ExpectedValue(int name, string value)
        {
            this.type = name;
            this.value = value;
        }
    }

    class TokenExtractor
    {
        public string name;
        public char[] delimiters;
        public Dictionary<int, ExpectedValue> indexMap;

        public TokenExtractor()
        {

        }

        public TokenExtractor(char[] delimiters, Dictionary<int,ExpectedValue> indexMap)
        {
            this.delimiters = delimiters;
            this.indexMap = indexMap;
        }

        // returns a map of property to property value e.g. artist : stevie wonder
        public Track extractProperties(string str)
        {
#if (DEBUG && TE_DEBUG)
            Console.WriteLine($"Using TokenExtractor {name}");
#endif
            Track track = new Track();

            var split = str.Split(delimiters);

            if(indexMap.Count != split.Length)
            {
#if (DEBUG && TE_DEBUG)
                Console.WriteLine("Number of key/value pairs ("+indexMap.Count+") does not match the split string length ("+split.Length+")");
                for (int i=0;i<split.Length;i++)
                {
                    Console.WriteLine("split[" + i + "] '" + split[i] + "'");
                }
#endif
                return null;
            }
            
            foreach (KeyValuePair<int, ExpectedValue> entry in indexMap)
            {
                if (entry.Key > split.Length)
                {
#if (DEBUG && TE_DEBUG)
                    Console.WriteLine("Tried matching a key that is at a position longer than the input");
#endif
                    return null;
                }

                split[entry.Key] = split[entry.Key].Trim(); // remove whitespace
#if (DEBUG && TE_DEBUG)
                Console.WriteLine("Position: " + entry.Key + ", '" + split[entry.Key] + "', should be type " + entry.Value.type + " and expected value '" + entry.Value.value + "'");
#endif
                if (split[entry.Key].Equals("")) // if the input is empty
                {
                    if(entry.Value.type.Equals(Track.IGNORE)) // should it be empty?
                    {
#if (DEBUG && TE_DEBUG)
                        Console.WriteLine("Found an expected blank index");
#endif
                        continue;
                    } else
                    {
#if (DEBUG && TE_DEBUG)
                        Console.WriteLine("Found an unexpected blank index");
#endif
                        return null;
                    }
                }

                if(!entry.Value.value.Equals("")) // if we have a expected value
                {
                    if(!split[entry.Key].Equals(entry.Value.value)) // check if it's the right value
                    {
#if (DEBUG && TE_DEBUG)
                        Console.WriteLine("Expected value is not present");
#endif
                        return null;
                    }
                }

                track.fromKeyPair(entry.Value.type, split[entry.Key]);
            }
#if (DEBUG && TE_DEBUG)
            Console.WriteLine("Got to the end :)");
#endif
            return track;
        }

        public override string ToString()
        {
            string str = "Name: " + name + ", Delimiters: ";
            foreach (char d in delimiters)
            {
                str += d + ", ";
            }
            str += "\n";
            if (indexMap != null)
            {
                foreach (KeyValuePair<int, ExpectedValue> entry in indexMap)
                {
                    str += "Pos: " + entry.Key + ", type: " + entry.Value.type + ", expected value: " + entry.Value.value + "\n";
                }
            } else
            {
                str += "indexMap is empty";
            }

            return str;
        }

    }

    public class TokenExtractorConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            if(objectType == typeof(TokenExtractor))
            {
                return true;
            }
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            var tc = new TokenExtractor();

            tc.name = (string)obj["name"];

            List<char> delimiters = new List<char>();

            foreach (char o in obj["delimiters"])
            {
                delimiters.Add((char)o);
            }
            tc.delimiters = delimiters.ToArray();

            JArray arr = obj["positions"].ToObject<JArray>();

            tc.indexMap = new Dictionary<int, ExpectedValue>();
            for (int i=0;i<arr.Count;i++)
            {
                tc.indexMap[i] = new ExpectedValue((int)arr[i][i.ToString()]["type"], (string)arr[i][i.ToString()]["expected"]);
            }
            return tc;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            TokenExtractor tc = (TokenExtractor)value;
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            using (var jsonWriter = new JsonTextWriter(sw))
            {

                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartObject(); // Write the opening of the root object

                jsonWriter.WritePropertyName("name");
                jsonWriter.WriteValue(tc.name);

                jsonWriter.WritePropertyName("delimiters");
                jsonWriter.WriteStartArray();
                foreach(char d in tc.delimiters)
                {
                    jsonWriter.WriteValue(d);
                }
                jsonWriter.WriteEndArray();

                jsonWriter.WritePropertyName("positions");
                jsonWriter.WriteStartArray();
                foreach (KeyValuePair<int, ExpectedValue> entry in tc.indexMap)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName(entry.Key.ToString());
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("type");
                    jsonWriter.WriteValue(entry.Value.type.ToString());
                    jsonWriter.WritePropertyName("expected");
                    jsonWriter.WriteValue(entry.Value.value);
                    jsonWriter.WriteEndObject();
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();

                jsonWriter.WriteEndObject(); // Write the closing of the root object
                                             // No need to close explicitly when inside a using statement
            }

            Console.WriteLine("Output: " + sb);
        }
    }
}