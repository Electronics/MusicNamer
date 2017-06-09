using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// TOMMOROW: Need to add tags
// split artists properly in tags
// amke tags actually work

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
            textBox_folder.Text = @"C:\Users\Laurie\Documents\outtemp";
            SetupDataGridView();
            toolStripStatusLabel1.Text = $"Waiting for folder selection...";

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
                    toolStripStatusLabel1.Text = "Running Extractor...";
                    runExtractor();
                }
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox_outputFolder.Text))
            {
                MessageBox.Show("Output folder does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No files to operate on", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int outputFilenamesStatus = checkOutputFilenames();
            if(outputFilenamesStatus == 1)
            {
                MessageBox.Show("One or more bad filenames!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (outputFilenamesStatus == 2)
            {
                MessageBox.Show("One or more duplicate filenames!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                TrackProperties tp = new TrackProperties((string)r.Cells["Longfilename"].Value, new Track());

                tp.track.artist = (string)r.Cells["Artist"].Value;
                tp.track.track = (string)r.Cells["Track"].Value;
                tp.track.genre = (string)r.Cells["Genre"].Value;
                tp.track.album = (string)r.Cells["Album"].Value;
                tp.shortFilename = (string)r.Cells["Output Filename"].Value;

                string pathTofile;
                try
                {
                    if (Properties.Settings.Default.exportToFolders)
                    {
                        Directory.CreateDirectory(textBox_outputFolder.Text + "/" + tp.track.artist);
                        pathTofile = textBox_outputFolder.Text + "/" + tp.track.artist + "/" + tp.shortFilename + ".mp3";
                        File.Copy(tp.longFilename, pathTofile);
                    }
                    else
                    {
                        pathTofile = textBox_outputFolder.Text + "/" + tp.shortFilename + ".mp3";
                        File.Copy(tp.longFilename, pathTofile);
                    }
                } catch (IOException err)
                {
                    MessageBox.Show("Attempted to overwrite a file! Make sure the output directory is clear.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Attempted to overwrite a file! Make sure the output directory is clear.");
                    Console.WriteLine(err.ToString());
                    return;
                }

                // now tag stuff
                TagLib.File file = TagLib.File.Create(pathTofile);
                if (!tp.isNullOrEmpty(tp.track.track)) file.Tag.Title = tp.track.track;
                if (!tp.isNullOrEmpty(tp.track.album)) file.Tag.Album = tp.track.album;
                if(!tp.isNullOrEmpty(tp.track.genre)) file.Tag.Genres = new[] { tp.track.genre };
                if (!tp.isNullOrEmpty(tp.track.artist))
                {
                    file.Tag.AlbumArtists = new[] { tp.track.artist };
                    file.Tag.Artists = new[] { tp.track.artist };
                }
                file.Save();
                file.Dispose();

            }
            MessageBox.Show("Sucessfully outputted all files", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetupDataGridView()
        {
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.ColumnCount = 9;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.Columns[0].Name = "Input Filename";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].Name = "Output Filename";
            dataGridView1.Columns[2].Name = "Track";
            dataGridView1.Columns[3].Name = "Artist";
            dataGridView1.Columns[4].Name = "Album";
            dataGridView1.Columns[5].Name = "Genre";
            dataGridView1.Columns[6].Name = "DataFrom";
            dataGridView1.Columns[7].Name = "TagStatus";
            dataGridView1.Columns[8].Name = "LongFilename";
            dataGridView1.Columns[8].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void runExtractor()
        {
            string[] fileArray;
            try
            {
                fileArray = Directory.GetFiles(textBox_folder.Text, "*.mp3", Properties.Settings.Default.importFromSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            } catch(System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show("Input directory does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Console.WriteLine($"Found {fileArray.Length} mp3 files");

            toolStripStatusLabel1.Text = $"Found {fileArray.Length} mp3 files";

            //------------------------------------------------------------------------------

            List<TokenExtractor> teList = new List<TokenExtractor>();
            
            string[] tokenExtractorFileArray = Directory.GetFiles("extractors/", "*.json", SearchOption.AllDirectories);
            TokenExtractorConverter teConverter = new TokenExtractorConverter();
            foreach (string s in tokenExtractorFileArray)
            {
                if (Properties.Settings.Default.disabledExtractors != null)
                {
                    if (Properties.Settings.Default.disabledExtractors.Contains(Path.GetFileName(s)))
                    {
                        Console.WriteLine($"Ommitting json file {Path.GetFileName(s)}");
                        continue;
                    }
                }
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
                inputFiles[s] = new TrackProperties(s, new Track());
                inputFiles[s].shortFilename = Path.GetFileNameWithoutExtension(s);
            }

            toolStripStatusLabel1.Text = $"Extracting/Finding tags...";

            foreach (KeyValuePair<string, TrackProperties> inputFile in inputFiles)
            {
                foreach (TokenExtractor te in teList)
                {
                    if (inputFile.Value.addTrackIfNotNull(te.extractProperties(inputFile.Value.shortFilename)))
                    {
                        inputFile.Value.track.track = inputFile.Value.track.track.Replace("ft.", "feat.");
                        inputFile.Value.track.dataFrom = "Extracted";
                        //TODO: insert if feat./ft. is in artist section? (also in section below btw)
                        break;
                    }
                }
                inputFile.Value.checkMapStatus();
                if (inputFile.Value.mappedStatus == TrackProperties.PARTIALLY_MAPPED || inputFile.Value.mappedStatus == TrackProperties.NOT_MAPPED)
                {
                    //Console.WriteLine($"Need to find missing information for {inputFile.Value.shortFilename}");

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

                    Track[] suggestedTracks = md.getSuggestedSongs(keywords.ToArray(), 5); // number is PER API

                    if (suggestedTracks.Length > 0) // make sure we have at least one suggested track
                    {
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

                        // if we have a GOOD match, copy the content
                        if (inputFile.Value.suggestedTracks[0].artistLevDistance + inputFile.Value.suggestedTracks[0].trackLevDistance < 10)
                        {
                            inputFile.Value.track = inputFile.Value.suggestedTracks[0];
                            //Console.WriteLine($"Found match for {inputFile.Value.shortFilename}, copying content");
                        }
                    } 

                    inputFile.Value.checkMapStatus(); // make sure to update the status - we'll be using this in the UI stuff!

                    // if we're STILL missing stuff, let's try and get it from other songs by the same artist
                    // If I think of other stuff to add here, use if (inputFile.Value.mappedStatus == TrackProperties.PARTIALLY_MAPPED || inputFile.Value.mappedStatus == TrackProperties.NOT_MAPPED) again to check for missing
                    if (inputFile.Value.track != null && inputFile.Value.isNullOrEmpty(inputFile.Value.track.genre))
                    {
                        //Console.WriteLine($"Genre missing for ({inputFile.Value.shortFilename})");
                        if (inputFile.Value.track.artist != "")
                        {
                            // if we have an artist, let's look at their other songs
                            // could try adding album here, but it is likely that the album is not there if have got to this stage
                            Track[] otherTracksByArtist = md.getSuggestedSongs(new[] { inputFile.Value.track.artist }, 10);

                            if (otherTracksByArtist.Length > 0)
                            {
                                Console.WriteLine($"Found a bunch of other songs({otherTracksByArtist.Length}) by the same artist");

                                // let's find the most popular genre
                                Dictionary<string, int> possibleGenres = new Dictionary<string, int>();
                                foreach (Track t in otherTracksByArtist)
                                {
                                    if (possibleGenres.ContainsKey(t.genre)) possibleGenres[t.genre]++;
                                    else possibleGenres[t.genre] = 1;
                                }
                                List<KeyValuePair<string, int>> possibleGenresList = possibleGenres.ToList();
                                possibleGenresList.Sort(delegate (KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2)
                                {
                                    return pair1.Value.CompareTo(pair2.Value);
                                });

                                Console.WriteLine($"Best genre match: {possibleGenresList[0].Key}");
                                inputFile.Value.track.genre = possibleGenresList[0].Key;
                                inputFile.Value.track.genreFrom = "API";
                            }
                        }
                    }
                }
            }
            // --------------------------------------------------------------------

            toolStripStatusLabel1.Text = $"Finished";


            dataGridView1.Rows.Clear();
            foreach (KeyValuePair<string, TrackProperties> inputFile in inputFiles)
            {
                dataGridView1.Rows.Add(new[] { inputFile.Value.shortFilename, "", inputFile.Value.track.track,
                        inputFile.Value.track.artist, inputFile.Value.track.album, inputFile.Value.track.genre, inputFile.Value.track.dataFrom,"", inputFile.Value.longFilename});
                if (inputFile.Value.track.genreFrom == "API")
                {
                    dataGridView1[5, dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].Style.BackColor = System.Drawing.Color.CadetBlue;
                }
                if (inputFile.Value.mappedStatus == TrackProperties.NOT_MAPPED)
                {
                    dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor = System.Drawing.Color.IndianRed;
                    dataGridView1[7, dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].Value = "Empty";
                }
                if (inputFile.Value.mappedStatus == TrackProperties.PARTIALLY_MAPPED)
                {
                    dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor = System.Drawing.Color.Gold;
                    dataGridView1[7, dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].Value = "Partial";
                }
                if (inputFile.Value.mappedStatus == TrackProperties.FULLY_MAPPED)
                {
                    dataGridView1.Rows[dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor = System.Drawing.Color.ForestGreen;
                    dataGridView1[7, dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None)].Value = "Full";
                }
            }
        }

        private void reRun_click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will remove any user added data", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                toolStripStatusLabel1.Text = "Running Extractor...";
                runExtractor();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Showing settings";
            SettingsPopup popup = new SettingsPopup();
            popup.ShowDialog();
            popup.Dispose();
            toolStripStatusLabel1.Text = "";
        }

        private void textBox_folder_DragDrop(object sender, DragEventArgs e)
        {
            textBox_folder.Text = (string)e.Data.GetData(DataFormats.Text,true);
        }

        private void textBox_folder_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.Text, true))
            {
                if (Directory.Exists(Path.GetDirectoryName((string)e.Data.GetData(DataFormats.Text, true))))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else e.Effect = DragDropEffects.None;
            } else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            /*if (e.Data.GetDataPresent(DataFormats.Text, true))
            {
               e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }*/
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            //if user clicked Shift+Ins or Ctrl+V (paste from clipboard)

            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))

            {

                char[] rowSplitter = { '\r', '\n' };

                char[] columnSplitter = { '\t' };

                //get the text from clipboard

                IDataObject dataInClipboard = Clipboard.GetDataObject();

                string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

                //split it into lines

                string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

                //get the row and column of selected cell in grid

                int r = dataGridView1.SelectedCells[0].RowIndex;

                int c = dataGridView1.SelectedCells[0].ColumnIndex;

                if (c == 0) return;

                //add rows into grid to fit clipboard lines

                if (dataGridView1.Rows.Count < (r + rowsInClipboard.Length))

                {

                    dataGridView1.Rows.Add(r + rowsInClipboard.Length - dataGridView1.Rows.Count);

                }

                // loop through the lines, split them into cells and place the values in the corresponding cell.

                for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)

                {

                    //split row into cell values

                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);

                    //cycle through cell values

                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)

                    {

                        //assign cell value, only if it within columns of the grid

                        if (dataGridView1.ColumnCount - 1 >= c + iCol)

                        {

                            dataGridView1.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];

                        }

                    }

                }

            }
        }

        private void generateOutputFilenames_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No files to operate on", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*dataGridView1.Columns[0].Name = "Input Filename";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].Name = "Output Filename";
            dataGridView1.Columns[2].Name = "Track";
            dataGridView1.Columns[3].Name = "Artist";
            dataGridView1.Columns[4].Name = "Album";
            dataGridView1.Columns[5].Name = "Genre";
            dataGridView1.Columns[6].Name = "DataFrom";
            dataGridView1.Columns[7].Name = "TagStatus";*/
            bool showMissingError = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                Track track = new Track();
                track.artist = (string)r.Cells["Artist"].Value;
                track.track = (string)r.Cells["Track"].Value;
                track.genre = (string)r.Cells["Genre"].Value;
                track.album = (string)r.Cells["Album"].Value;
                var itemList = new[] { new { Artist = track.artist, Track = track.track,
                    Genre = track.genre, Album =  track.album} };
                //Console.WriteLine(SmartFormat.Smart.Format(textBox_outputFormat.Text,itemList));
                r.Cells["Output Filename"].Value = SmartFormat.Smart.Format(textBox_outputFormat.Text, itemList);
                if (containsMissingTag(textBox_outputFormat.Text, track))
                {
                    //Console.WriteLine("It's missing");
                    //r.Cells["Output Filename"].Style.BackColor = System.Drawing.Color.Red; // THis is now handled by checkOutputFilenames
                    showMissingError = true;
                }
            }
            if (showMissingError) MessageBox.Show("Some files were missing tags", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else MessageBox.Show("All files named sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            checkOutputFilenames();
        }

        // uses itemList format from Smartformat
        private bool containsMissingTag(string placeholder, Track t)
        {
            if (placeholder.Contains("{Artist}") && isNullOrEmpty(t.artist)) return true;
            if (placeholder.Contains("{Track}") && isNullOrEmpty(t.track)) return true;
            if (placeholder.Contains("{Album}") && isNullOrEmpty(t.album)) return true;
            if (placeholder.Contains("{Genre}") && isNullOrEmpty(t.genre)) return true;
            return false;
        }
        private bool isNullOrEmpty(string s)
        {
            if (s != null)
            {
                if (!s.Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        private void button_outputFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Console.WriteLine($"Folder selected: {fbd.SelectedPath}");
                    textBox_outputFolder.Text = fbd.SelectedPath;
                }
            }
        }

        public int checkOutputFilenames() // returns true if badfilename
        {
            if (dataGridView1.RowCount == 0)
            {
                return 0;
            }
            /*dataGridView1.Columns[0].Name = "Input Filename";
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].Name = "Output Filename";
            dataGridView1.Columns[2].Name = "Track";
            dataGridView1.Columns[3].Name = "Artist";
            dataGridView1.Columns[4].Name = "Album";
            dataGridView1.Columns[5].Name = "Genre";
            dataGridView1.Columns[6].Name = "DataFrom";
            dataGridView1.Columns[7].Name = "TagStatus";*/
            bool badfilename = false;
            bool duplicateFilename = false;
            List<string> filenames = new List<string>();
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if(r.Cells["Output Filename"].Value != null)
                {
                    if(r.Cells["Output Filename"].Value.ToString().Replace("-","").Replace(".", "").Replace("[", "").Replace("]", "").Trim() == "")
                    {
                        r.Cells["Output Filename"].Style.BackColor = System.Drawing.Color.Red;
                        badfilename = true;
                    } else
                    {
                        // good filename
                        r.Cells["Output Filename"].Style.BackColor = System.Drawing.Color.ForestGreen;
                        if(!filenames.Contains(r.Cells["Output Filename"].Value))
                        {
                            filenames.Add((string)r.Cells["Output Filename"].Value);
                        } else
                        {
                            duplicateFilename = true;
                            r.Cells["Output Filename"].Style.BackColor = System.Drawing.Color.DeepPink;
                            // now we need to go back and set the previous row to this color as well...
                            foreach (DataGridViewRow r2 in dataGridView1.Rows)
                            {
                                if (r.Cells["Output Filename"].Value.ToString().Replace(r2.Cells["Output Filename"].Value.ToString(), "")=="")
                                { // because apperently the strings don't match on the first instance.. WTF^
                                    r2.Cells["Output Filename"].Style.BackColor = System.Drawing.Color.DeepPink;
                                }
                            }
                        }
                    }
                } else
                {
                    r.Cells["Output Filename"].Style.BackColor = System.Drawing.Color.Red;
                    badfilename = true;
                }
            }
            if (badfilename) return 1;
            if (duplicateFilename) return 2;
            return 0;
    }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkOutputFilenames();
        }
    }


    public static class DataGridHelper
    {
        public static object GetCellValueFromColumnHeader(this DataGridViewCellCollection CellCollection, string HeaderText)
        {
            return CellCollection.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == HeaderText).Value;
        }
    }
}
