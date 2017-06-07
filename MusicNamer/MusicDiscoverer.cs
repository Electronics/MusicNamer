using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusicNamer
{
    class MusicDiscoverer
    {
        public enum termType { artist, track, album, dunno }

        public JObject getRawInformation(string term)
        {
            string html = string.Empty;
            string url = @"https://itunes.apple.com/search?term=" + term;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
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
            String last = terms.Last();
            String first = terms.First();

            string requestParams = first;

            foreach (string k in terms)
            {
                if (k.Equals(first)) continue;
                requestParams += "&term=" + k;
            }

            return getRawInformation(requestParams);
        }

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
            return getNumberOfType(term, type, getRawInformation(term));
        }

        public PropertyPair[] getSuggestedTypes(string term)
        {
            JObject rawData = getRawInformation(term);

            PropertyPair[] numProperties = new PropertyPair[3];

            numProperties[0] = getNumberOfType(term, "artistName", rawData);
            numProperties[1] = getNumberOfType(term, "trackName", rawData);
            numProperties[2] = getNumberOfType(term, "collectionName", rawData);

            numProperties.OrderBy(propPair => propPair.count);

            return numProperties;
        }

        public Track[] getSuggestedSongs(string[] keywords, int suggestionCount)
        {
            JObject rawData = getRawInformation(keywords);
            int numResults = Math.Min(suggestionCount, (int)rawData["resultCount"]);

            Track[] tracks = new Track[numResults];

            for (int i = 0; i < numResults; i++)
            {

                tracks[i] = new Track();
                try
                {
                    tracks[i].album = (string)rawData["results"][i]["collectionName"];
                    tracks[i].artist = (string)rawData["results"][i]["artistName"];
                    tracks[i].track = (string)rawData["results"][i]["trackName"];
                    tracks[i].genre = (string)rawData["results"][i]["primaryGenreName"];
                    tracks[i].releaseDate = (DateTime)rawData["results"][i]["releaseDate"];
                    tracks[i].duration = (int)rawData["results"][i]["trackTimeMillis"];
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Missing a property, likely duration : " + e.ToString());
                }

            }

            return tracks;
        }


    }
}
