using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicNamer
{
    class APIEndPoint
    {
        //@"https://itunes.apple.com/search?term=" + term;
        public string name;
        public string filename;
        public string url;
        public string requestParam;

        public Dictionary<string, string> extraParams;

        public APIEndPoint()
        {

        }

        public APIEndPoint(string url, string requestParam)
        {
            this.url = url;
            this.requestParam = requestParam;
        }

        public JObject getRawInformation(string term)
        {
            string html = string.Empty;
            string requestURL = url + "?";

            if(extraParams!=null)
            {
                foreach(KeyValuePair<string, string> extraParam in extraParams)
                {
                    requestURL += extraParam.Key + "=" + extraParam.Value + "&";
                }
            }

            requestURL += requestParam + "=" + term;
            Console.WriteLine("New request: " + requestURL);
            //Console.WriteLine($"Terms were {term}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURL);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return JObject.Parse(html);
        }

        public JObject getRawInformation(string[] terms)
        {
            if (terms.Length == 1) return getRawInformation(terms[0]);
            String last = terms.Last();
            String first = terms.First();

            string requestParams = first.Trim();

            foreach (string k in terms)
            {
                if (k.Equals(first)) continue;
                string s = Regex.Replace(k.Replace("&", ""), @"\s+", " ").Trim();
                if (s.Equals("&")) continue;
                requestParams += "+" + s;
            }

            return getRawInformation(requestParams.Replace(' ', '+'));
        }

        public override string ToString()
        {
            string str = $"{name}, {url} RP: {requestParam}";
            if(extraParams!=null)
            {
                foreach(KeyValuePair<string, string> item in extraParams)
                {
                    str += $", {item.Key}: {item.Value}";
                }
            }
            return str;
        }

        public bool isDisabled()
        {
            if(Properties.Settings.Default.disabledAPIs!=null)
            {
                if(Properties.Settings.Default.disabledAPIs.Contains(filename))
                {
                    return true;
                }
            }
            return false;
        }
    }

    class MusicDiscoverer
    {
        APIEndPoint appleTest = new APIEndPoint(@"https://itunes.apple.com/search", "term");

        public enum termType { artist, track, album, dunno }

        public PropertyPair getNumberOfType(string term, string type, JObject rawData)
        {
            int numberOfType = 0;

            int resultCount = (int)rawData["resultCount"];

            //Console.WriteLine("Found " + resultCount.ToString() + " results for '" + term + "'");

            for (int i = 0; i < resultCount; i++)
            {
                if (((string)rawData["results"][i][type]).Contains(term, StringComparison.OrdinalIgnoreCase))
                {
                    numberOfType++;
                }
            }

            return new PropertyPair(type, numberOfType);
        }

        public PropertyPair getNumberOfType(string term, string type)
        {
            Console.WriteLine("----------CHANGE THIS? BECAUSE I DON'T THINK WE USE IT (ADD MULTIPLE API ENDPOINTS");
            return getNumberOfType(term, type, appleTest.getRawInformation(term));
        }

        public PropertyPair[] getSuggestedTypes(string term)
        {
            JObject rawData = appleTest.getRawInformation(term);

            PropertyPair[] numProperties = new PropertyPair[3];

            numProperties[0] = getNumberOfType(term, "artistName", rawData);
            numProperties[1] = getNumberOfType(term, "trackName", rawData);
            numProperties[2] = getNumberOfType(term, "collectionName", rawData);

            numProperties.OrderBy(propPair => propPair.count);

            return numProperties;
        }

        public Track[] getSuggestedSongs(string[] keywords, int suggestionCount)
        {
            List<Track> returnTracks = new List<Track>();

            APIEndPoint[] apis = getAPIs();
            //Console.WriteLine($"Found {apis.Length} api(s)");

            foreach (APIEndPoint api in apis)
            {
                //Console.WriteLine($"Using api {api.name}");
                JObject rawData = api.getRawInformation(keywords);
                int numResults = Math.Min(suggestionCount, (int)rawData["resultCount"]);

                Track[] tracks = new Track[numResults];

                for (int i = 0; i < numResults; i++)
                {
                    try
                    {
                        if (api.name == "apple music" && !api.isDisabled()) // this unfortunatley works on the filename not the name inside the folder.. too much effort :/
                        {
                            tracks[i] = new Track();
                            tracks[i].album = (string)rawData["results"][i]["collectionName"];
                            tracks[i].artist = (string)rawData["results"][i]["artistName"];
                            tracks[i].track = (string)rawData["results"][i]["trackName"];
                            tracks[i].genre = (string)rawData["results"][i]["primaryGenreName"];
                            tracks[i].releaseDate = (DateTime)rawData["results"][i]["releaseDate"];
                            tracks[i].duration = (int)rawData["results"][i]["trackTimeMillis"];
                            tracks[i].dataFrom = "iTunes API";
                        } else
                        {
                            Console.WriteLine("Couldn't find a api to match");
                        }
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine("Missing a property, likely duration : " + e.ToString());
                    }
                }
                if (tracks.Length > 0 && tracks[0] != null) returnTracks.AddRange(tracks);
            }
            return returnTracks.ToArray();
        }

        public APIEndPoint[] getAPIs()
        {
            List<APIEndPoint> apiList = new List<APIEndPoint>();
            ApiEndpointExtractor apiExtractor = new ApiEndpointExtractor();
            string[] tokenExtractorFileArray_APIs = Directory.GetFiles("apis/", "*.json", SearchOption.AllDirectories);
            foreach (string s in tokenExtractorFileArray_APIs)
            {
                using (StreamReader r = new StreamReader(s))
                {
                    string json = r.ReadToEnd();
                    //Console.WriteLine($"Found json file {Path.GetFileName(s)}");
                    //Console.WriteLine(json);
                    apiList.Add(JsonConvert.DeserializeObject<APIEndPoint>(json, apiExtractor));
                    apiList.Last<APIEndPoint>().filename = Path.GetFileName(s);
                }
            }
            return apiList.ToArray();
        }

        public class ApiEndpointExtractor : JsonConverter
        {

            public override bool CanConvert(Type objectType)
            {
                if (objectType == typeof(APIEndPoint))
                {
                    return true;
                }
                return false;
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject obj = JObject.Load(reader);

                var api = new APIEndPoint();

                api.name = (string)obj["name"];
                api.url = (string)obj["url"];
                api.requestParam = (string)obj["requestParam"];

                if (obj["extraParams"] != null)
                {
                    api.extraParams = new Dictionary<string, string>();
                    foreach(JProperty item in obj["extraParams"])
                    {
                        api.extraParams.Add((string)item.Name, (string)item.Value);
                    }
                };
                return api;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                APIEndPoint api = (APIEndPoint)value;
                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb))
                using (var jsonWriter = new JsonTextWriter(sw))
                {

                    jsonWriter.Formatting = Formatting.Indented;
                    jsonWriter.WriteStartObject(); // Write the opening of the root object

                    jsonWriter.WritePropertyName("name");
                    jsonWriter.WriteValue(api.name);

                    jsonWriter.WritePropertyName("url");
                    jsonWriter.WriteValue(api.url);

                    jsonWriter.WritePropertyName("requestParam");
                    jsonWriter.WriteValue(api.requestParam);

                    if (api.extraParams != null)
                    {
                        jsonWriter.WritePropertyName("extraParams");
                        jsonWriter.WriteStartObject();
                        foreach (KeyValuePair<string, string> item in api.extraParams)
                        {
                            jsonWriter.WriteStartObject();
                            jsonWriter.WritePropertyName(item.Key);
                            jsonWriter.WriteValue(item.Value);
                            jsonWriter.WriteEndObject();
                        }
                        jsonWriter.WriteEndObject();
                    }

                    jsonWriter.WriteEndObject(); // Write the closing of the root object
                                                 // No need to close explicitly when inside a using statement
                }

                Console.WriteLine("Output: " + sb);
            }
        }
    }
}
