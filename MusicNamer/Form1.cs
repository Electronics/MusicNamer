using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace MusicNamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Form1_Load(object sender, System.EventArgs e)
        {

            // at this point we should have a bunch of suggested tracks (hopefully) the top one being the actual track
            // let's go through all the tracks updating them with new information and flag up the ones we don't know about
            /*foreach (KeyValuePair<string, TrackProperties> inputFile in inputFiles)
            {
                if (inputFile.Value.suggestedTracks[0].trackLevDistance < 5 && inputFile.Value.suggestedTracks[0].artistLevDistance < 4)
                {
                    // we have a good match
                    inputFile.Value.track = inputFile.Value.suggestedTracks[0];
                    Console.WriteLine($"[FOUND] {inputFile.Value.shortFilename} ->\n{inputFile.Value.track.ToString()}");
                }
                else
                {
                    Console.WriteLine($"[NOT FOUND] {inputFile.Value.shortFilename}. Choose from the list below or enter manually:");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("[s]kip [m]anually");
                    int i = 0;
                    foreach (Track suggestion in inputFile.Value.suggestedTracks)
                    {
                        i++;
                        Console.WriteLine($"{i} {suggestion.ToString()}");
                    }
                    Console.WriteLine("------------------------------------------");
                    ConsoleKeyInfo key = Console.ReadKey();
                    //if (key.Key == ConsoleKey.D0);
                    Console.WriteLine();
                }
            }*/
            textBox_folder.Text = @"Y:\junk\outtemp";
            SetupDataGridView();

            //System.Environment.Exit(1);
        }
        private static string RemoveBetween(string s, char begin, char end)
        {
            Regex regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
            return regex.Replace(s, string.Empty);
        }
        private static int CalcLevenshteinDistance(string a, string b)
        {
            if (String.IsNullOrEmpty(a) || String.IsNullOrEmpty(b)) return 0;

            int lengthA = a.Length;
            int lengthB = b.Length;
            var distances = new int[lengthA + 1, lengthB + 1];
            for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
            for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

            for (int i = 1; i <= lengthA; i++)
                for (int j = 1; j <= lengthB; j++)
                {
                    int cost = b[j - 1] == a[i - 1] ? 0 : 1;
                    distances[i, j] = Math.Min
                        (
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + cost
                        );
                }
            return distances[lengthA, lengthB];
        }

        private void button_openFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Console.WriteLine($"Folder selected: {fbd.SelectedPath}");
                    textBox_folder.Text = fbd.SelectedPath;
                    runExtractor();
                }
            }
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            
        }

        private void SetupDataGridView()
        {
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.ColumnCount = 6;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.Columns[0].Name = "Input Filename";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].Name = "Output Filename";
            dataGridView1.Columns[2].Name = "Track";
            dataGridView1.Columns[3].Name = "Artist";
            dataGridView1.Columns[4].Name = "Album";
            dataGridView1.Columns[5].Name = "Genre";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void runExtractor()
        {
            string[] fileArray = Directory.GetFiles(textBox_folder.Text, "*.mp3", SearchOption.AllDirectories);

            Console.WriteLine($"Found {fileArray.Length} mp3 files");

            label1.Text = $"Found {fileArray.Length} mp3 files";
            label1.ForeColor = System.Drawing.Color.ForestGreen;

            //------------------------------------------------------------------------------
            label1.Text = $"Finding Token Extractors...";
            label1.ForeColor = System.Drawing.Color.LightSeaGreen;

            List<TokenExtractor> teList = new List<TokenExtractor>();
            string[] tokenExtractorFileArray = Directory.GetFiles("filenameFormats/", "*.json", SearchOption.AllDirectories);
            TokenExtractorConverter teConverter = new TokenExtractorConverter();
            foreach (string s in tokenExtractorFileArray)
            {
                using (StreamReader r = new StreamReader(s))
                {
                    string json = r.ReadToEnd();
                    teList.Add(JsonConvert.DeserializeObject<TokenExtractor>(json, teConverter));
                    Console.WriteLine($"Found json file {Path.GetFileName(s)}");
                }
            }

            // time to order the TokenExtractors
            teList.Sort(delegate (TokenExtractor x, TokenExtractor y)
            {
                if (x.delimiters.Length == y.delimiters.Length)
                {
                    if (x.indexMap.Count == y.indexMap.Count) return 0;
                    else if (x.indexMap.Count > y.indexMap.Count) return 1;
                    else if (x.indexMap.Count < y.indexMap.Count) return -1;
                    return 0;
                }
                else if (x.delimiters.Length > y.delimiters.Length) return 1;
                else if (x.delimiters.Length < y.delimiters.Length) return -1;
                else return 0;
            });
            teList.Reverse();
            Console.WriteLine("Sorted List:");
            foreach (TokenExtractor t in teList)
            {
                Console.WriteLine($"   {t.name}");
            }

            MusicDiscoverer md = new MusicDiscoverer();

            //string[] fileArray = Directory.GetFiles(textBox_folder.Text, "*.mp3", SearchOption.AllDirectories);

            Console.WriteLine($"Found {fileArray.Length} mp3 files");

            Dictionary<string, TrackProperties> inputFiles = new Dictionary<string, TrackProperties>();
            foreach (string s in fileArray)
            {
                inputFiles[s] = new TrackProperties(Path.GetFileNameWithoutExtension(s), new Track());
            }

            label1.Text = $"Extracting/Finding tags...";
            label1.ForeColor = System.Drawing.Color.LightSeaGreen;

            foreach (KeyValuePair<string, TrackProperties> inputFile in inputFiles)
            {
                foreach (TokenExtractor te in teList)
                {
                    if (inputFile.Value.addTrackIfNotNull(te.extractProperties(inputFile.Value.shortFilename)))
                    {
                        inputFile.Value.track.track = inputFile.Value.track.track.Replace("ft.", "feat.");
                        //TODO: insert if feat./ft. is in artist section? (also in section below btw)
                        break;
                    }
                }
                inputFile.Value.checkMapStatus();
                if (inputFile.Value.mappedStatus == TrackProperties.PARTIALLY_MAPPED || inputFile.Value.mappedStatus == TrackProperties.NOT_MAPPED)
                {
                    List<string> keywords = new List<string>();
                    string title;
                    if (!inputFile.Value.isNullOrEmpty(inputFile.Value.track.track))
                    {
                        title = inputFile.Value.track.track;

                    }
                    else
                    {
                        title = inputFile.Value.shortFilename.Replace("ft.", "feat.");
                    }
                    title = RemoveBetween(title, '[', ']');
                    title = RemoveBetween(title, '(', ')');
                    // it should always be feat. now
                    int index = title.IndexOf("feat.");
                    if (index > 0) title = title.Substring(0, index);
                    title = title.Trim();
                    keywords.AddRange(title.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries));
                    if (!inputFile.Value.isNullOrEmpty(inputFile.Value.track.artist)) keywords.Add(inputFile.Value.track.artist);
                    if (!inputFile.Value.isNullOrEmpty(inputFile.Value.track.album)) keywords.Add(inputFile.Value.track.album);

                    Console.WriteLine("Couldn't find a matching extractor, getting suggested tracks from APIs...");

                    Track[] suggestedTracks = md.getSuggestedSongs(keywords.ToArray(), 5); // number is PER API

                   /* Console.WriteLine($"--------{inputFile.Value.shortFilename}---------");
                    Console.Write("Keywords: ");
                    foreach (string k in keywords)
                    {
                        Console.Write($"{k}, ");
                    }
                    Console.WriteLine();*/
                    foreach (Track t in suggestedTracks)
                    {
                        t.trackLevDistance = CalcLevenshteinDistance(t.track, inputFile.Value.track.track);
                        t.artistLevDistance = CalcLevenshteinDistance(t.artist, inputFile.Value.track.artist);
                    }
                    // now we sort the suggested tracks in order of artistLevDistance, then trackLevDistance
                    Array.Sort(suggestedTracks, delegate (Track x, Track y)
                    {
                        if (x.artistLevDistance == y.artistLevDistance)
                        {
                            if (x.trackLevDistance == y.trackLevDistance) return 0;
                            else if (x.trackLevDistance > y.trackLevDistance) return 1;
                            else if (x.trackLevDistance < y.trackLevDistance) return -1;
                        }
                        else if (x.artistLevDistance > y.artistLevDistance) return 1;
                        else if (x.artistLevDistance < y.artistLevDistance) return -1;
                        return 0;
                    });

                    // grab the top 5? and store them
                    inputFile.Value.suggestedTracks = new List<Track>();
                    for (int i = 0; i < Math.Min(suggestedTracks.Length, 5); i++)
                    {
                        inputFile.Value.suggestedTracks.Add(suggestedTracks[i]);
                    }

                    if (inputFile.Value.suggestedTracks[0].artistLevDistance + inputFile.Value.suggestedTracks[0].trackLevDistance < 10)
                    {
                        inputFile.Value.track = inputFile.Value.suggestedTracks[0];
                        Console.WriteLine($"Found match for {inputFile.Value.shortFilename}, copying content");
                    }

                    inputFile.Value.checkMapStatus(); // make sure to update the status - we'll be using this in the UI stuff!
                }
            }
            // --------------------------------------------------------------------

            label1.Text = $"Done";
            label1.ForeColor = System.Drawing.Color.ForestGreen;


            dataGridView1.Rows.Clear();
            foreach (KeyValuePair<string, TrackProperties> inputFile in inputFiles)
            {
                dataGridView1.Rows.Add(new[] { inputFile.Value.shortFilename, "Formatted", inputFile.Value.track.track,
                        inputFile.Value.track.artist, inputFile.Value.track.album, inputFile.Value.track.genre});

                if (inputFile.Value.mappedStatus == TrackProperties.NOT_MAPPED)
                    dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                if (inputFile.Value.mappedStatus == TrackProperties.PARTIALLY_MAPPED)
                    dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                if (inputFile.Value.mappedStatus == TrackProperties.FULLY_MAPPED)
                    dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor = System.Drawing.Color.ForestGreen;
            }
        }

        private void reRun_click(object sender, EventArgs e)
        {
            runExtractor();
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            SettingsPopup popup = new SettingsPopup();
            popup.ShowDialog();
            popup.Dispose();
        }
    }
}
