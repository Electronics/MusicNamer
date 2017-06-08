namespace MusicNamer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_outputFormat = new System.Windows.Forms.TextBox();
            this.button_openFolder = new System.Windows.Forms.Button();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.generateOutputFilenames = new System.Windows.Forms.Button();
            this.button_export = new System.Windows.Forms.Button();
            this.reRun = new System.Windows.Forms.Button();
            this.button_settings = new System.Windows.Forms.Button();
            this.textBox_outputFolder = new System.Windows.Forms.TextBox();
            this.button_outputFolder = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1004, 727);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 793);
            this.splitContainer1.SplitterDistance = 63;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.textBox_outputFormat, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_openFolder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_folder, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.generateOutputFilenames, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_export, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.reRun, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_settings, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_outputFolder, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_outputFolder, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 63);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_outputFormat
            // 
            this.textBox_outputFormat.AllowDrop = true;
            this.textBox_outputFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_outputFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_outputFormat, 4);
            this.textBox_outputFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_outputFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_outputFormat.Location = new System.Drawing.Point(578, 33);
            this.textBox_outputFormat.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_outputFormat.Multiline = true;
            this.textBox_outputFormat.Name = "textBox_outputFormat";
            this.textBox_outputFormat.Size = new System.Drawing.Size(424, 28);
            this.textBox_outputFormat.TabIndex = 11;
            this.textBox_outputFormat.Text = "{Track} - {Artist}";
            // 
            // button_openFolder
            // 
            this.button_openFolder.AutoSize = true;
            this.button_openFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_openFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_openFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_openFolder.Location = new System.Drawing.Point(2, 2);
            this.button_openFolder.Margin = new System.Windows.Forms.Padding(2);
            this.button_openFolder.Name = "button_openFolder";
            this.button_openFolder.Size = new System.Drawing.Size(81, 27);
            this.button_openFolder.TabIndex = 0;
            this.button_openFolder.Text = "Input Folder";
            this.button_openFolder.UseVisualStyleBackColor = true;
            this.button_openFolder.Click += new System.EventHandler(this.button_openFolder_Click);
            // 
            // textBox_folder
            // 
            this.textBox_folder.AllowDrop = true;
            this.textBox_folder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_folder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.textBox_folder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_folder.Location = new System.Drawing.Point(87, 2);
            this.textBox_folder.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_folder.Multiline = true;
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(487, 27);
            this.textBox_folder.TabIndex = 1;
            this.textBox_folder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_folder_DragDrop);
            this.textBox_folder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_folder_DragEnter);
            // 
            // generateOutputFilenames
            // 
            this.generateOutputFilenames.AutoSize = true;
            this.generateOutputFilenames.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.generateOutputFilenames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateOutputFilenames.Location = new System.Drawing.Point(681, 2);
            this.generateOutputFilenames.Margin = new System.Windows.Forms.Padding(2);
            this.generateOutputFilenames.Name = "generateOutputFilenames";
            this.generateOutputFilenames.Size = new System.Drawing.Size(146, 27);
            this.generateOutputFilenames.TabIndex = 2;
            this.generateOutputFilenames.Text = "Generate Output Filenames";
            this.generateOutputFilenames.UseVisualStyleBackColor = true;
            this.generateOutputFilenames.Click += new System.EventHandler(this.generateOutputFilenames_Click);
            // 
            // button_export
            // 
            this.button_export.AutoSize = true;
            this.button_export.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.Location = new System.Drawing.Point(831, 2);
            this.button_export.Margin = new System.Windows.Forms.Padding(2);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(61, 27);
            this.button_export.TabIndex = 5;
            this.button_export.Text = "Export All";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // reRun
            // 
            this.reRun.AutoSize = true;
            this.reRun.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reRun.Location = new System.Drawing.Point(578, 2);
            this.reRun.Margin = new System.Windows.Forms.Padding(2);
            this.reRun.Name = "reRun";
            this.reRun.Size = new System.Drawing.Size(99, 27);
            this.reRun.TabIndex = 7;
            this.reRun.Text = "Re-Run Extractor";
            this.reRun.UseVisualStyleBackColor = true;
            this.reRun.Click += new System.EventHandler(this.reRun_click);
            // 
            // button_settings
            // 
            this.button_settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_settings.BackgroundImage")));
            this.button_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_settings.Location = new System.Drawing.Point(896, 2);
            this.button_settings.Margin = new System.Windows.Forms.Padding(2);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(106, 27);
            this.button_settings.TabIndex = 8;
            this.button_settings.UseVisualStyleBackColor = true;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // textBox_outputFolder
            // 
            this.textBox_outputFolder.AllowDrop = true;
            this.textBox_outputFolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_outputFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.textBox_outputFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_outputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_outputFolder.Location = new System.Drawing.Point(87, 33);
            this.textBox_outputFolder.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_outputFolder.Multiline = true;
            this.textBox_outputFolder.Name = "textBox_outputFolder";
            this.textBox_outputFolder.Size = new System.Drawing.Size(487, 28);
            this.textBox_outputFolder.TabIndex = 9;
            // 
            // button_outputFolder
            // 
            this.button_outputFolder.AutoSize = true;
            this.button_outputFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_outputFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_outputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_outputFolder.Location = new System.Drawing.Point(2, 33);
            this.button_outputFolder.Margin = new System.Windows.Forms.Padding(2);
            this.button_outputFolder.Name = "button_outputFolder";
            this.button_outputFolder.Size = new System.Drawing.Size(81, 28);
            this.button_outputFolder.TabIndex = 10;
            this.button_outputFolder.Text = "Output Folder";
            this.button_outputFolder.UseVisualStyleBackColor = true;
            this.button_outputFolder.Click += new System.EventHandler(this.button_outputFolder_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 705);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1004, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 793);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_openFolder;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.Button generateOutputFilenames;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Button reRun;
        private System.Windows.Forms.Button button_settings;
        private System.Windows.Forms.TextBox textBox_outputFormat;
        private System.Windows.Forms.TextBox textBox_outputFolder;
        private System.Windows.Forms.Button button_outputFolder;
    }
}

