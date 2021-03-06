﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicNamer
{
    public partial class SettingsPopup : Form
    {
        public SettingsPopup()
        {
            InitializeComponent();
            Console.WriteLine("Settings Opened");
            checkBox_exportFolders.Checked = Properties.Settings.Default.exportToFolders;
            checkBox_importFromSubfolders.Checked = Properties.Settings.Default.importFromSubfolders;
            checkBox_artistFolders.Checked = Properties.Settings.Default.exportToAlbumFolders;
            updateCheckBoxArtistFolders();

            // find out what extractors we have and compare against settings list
            System.Collections.Specialized.StringCollection sc_extractors = Properties.Settings.Default.disabledExtractors;
            if (sc_extractors == null) sc_extractors = new System.Collections.Specialized.StringCollection();
            string[] disabledExtractors = new String[sc_extractors.Count];
            sc_extractors.CopyTo(disabledExtractors,0);

            string[] tokenExtractorFileArray_Extractors = Directory.GetFiles("extractors/", "*.json", SearchOption.AllDirectories);
            foreach (string s in tokenExtractorFileArray_Extractors)
            {
                checkedListBox_disabledExtractors.Items.Add(Path.GetFileName(s));
                foreach (string disabledExtractor in disabledExtractors)
                {
                    if(disabledExtractor==Path.GetFileName(s))
                    {
                        checkedListBox_disabledExtractors.SetItemChecked(checkedListBox_disabledExtractors.Items.Count-1,true);
                    }
                }
            }
            // ---------------end of this bit

            // find out what apis we have and compare against settings list
            System.Collections.Specialized.StringCollection sc_APIs = Properties.Settings.Default.disabledAPIs;
            if (sc_APIs == null) sc_APIs = new System.Collections.Specialized.StringCollection();
            string[] disabledAPIs = new String[sc_APIs.Count];
            sc_APIs.CopyTo(disabledAPIs, 0);

            string[] tokenExtractorFileArray_APIs = Directory.GetFiles("apis/", "*.json", SearchOption.AllDirectories);
            foreach (string s in tokenExtractorFileArray_APIs)
            {
                checkedListBox_disabledAPIs.Items.Add(Path.GetFileName(s));
                foreach (string disabledAPI in disabledAPIs)
                {
                    if (disabledAPI == Path.GetFileName(s))
                    {
                        checkedListBox_disabledAPIs.SetItemChecked(checkedListBox_disabledAPIs.Items.Count - 1, true);
                    }
                }
            }
            // ---------------end of this bit


        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked ok");

            Properties.Settings.Default.exportToFolders = checkBox_exportFolders.Checked;
            if (checkBox_exportFolders.Checked) Properties.Settings.Default.exportToAlbumFolders = checkBox_artistFolders.Checked;
            Properties.Settings.Default.importFromSubfolders = checkBox_importFromSubfolders.Checked;
            Properties.Settings.Default.disabledExtractors = new System.Collections.Specialized.StringCollection();
            if (checkedListBox_disabledExtractors.CheckedItems.Count != 0)
            {
                string[] disabledExtractors = checkedListBox_disabledExtractors.CheckedItems.OfType<string>().ToArray();
                Properties.Settings.Default.disabledExtractors.AddRange(disabledExtractors);
            }

            Properties.Settings.Default.disabledAPIs = new System.Collections.Specialized.StringCollection();
            if(checkedListBox_disabledAPIs.CheckedItems.Count != 0)
            {
                string[] disabledAPIs = checkedListBox_disabledAPIs.CheckedItems.OfType<string>().ToArray();
                Properties.Settings.Default.disabledAPIs.AddRange(disabledAPIs);
            }
            
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Cancel clicked");
            this.Close();
        }

        private void checkBox_exportFolders_CheckedChanged(object sender, EventArgs e)
        {
            updateCheckBoxArtistFolders();
        }

        private void updateCheckBoxArtistFolders()
        {
            if (checkBox_exportFolders.Checked) checkBox_artistFolders.Enabled = true;
            else
            {
                checkBox_artistFolders.Enabled = false;
                checkBox_artistFolders.Checked = false;
            }
        }
    }
}
