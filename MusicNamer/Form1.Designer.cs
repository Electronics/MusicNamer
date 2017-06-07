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
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.button_openFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_run = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reRun = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.generateOutputFilenames = new System.Windows.Forms.Button();
            this.button_settings = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_folder
            // 
            this.textBox_folder.AllowDrop = true;
            this.textBox_folder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_folder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.textBox_folder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_folder.Location = new System.Drawing.Point(106, 3);
            this.textBox_folder.MinimumSize = new System.Drawing.Size(200, 40);
            this.textBox_folder.Multiline = true;
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(815, 40);
            this.textBox_folder.TabIndex = 1;
            // 
            // button_openFolder
            // 
            this.button_openFolder.AutoSize = true;
            this.button_openFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_openFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_openFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_openFolder.Location = new System.Drawing.Point(3, 3);
            this.button_openFolder.Name = "button_openFolder";
            this.button_openFolder.Size = new System.Drawing.Size(97, 38);
            this.button_openFolder.TabIndex = 0;
            this.button_openFolder.Text = "Open Folder";
            this.button_openFolder.UseVisualStyleBackColor = true;
            this.button_openFolder.Click += new System.EventHandler(this.button_openFolder_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1051, 44);
            this.label1.TabIndex = 3;
            this.label1.Text = "Waiting for folder to be chosen...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_run
            // 
            this.button_run.AutoSize = true;
            this.button_run.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_run.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_run.Location = new System.Drawing.Point(1259, 3);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(77, 38);
            this.button_run.TabIndex = 5;
            this.button_run.Text = "Export All";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1339, 884);
            this.dataGridView1.TabIndex = 6;
            // 
            // reRun
            // 
            this.reRun.AutoSize = true;
            this.reRun.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reRun.Location = new System.Drawing.Point(927, 3);
            this.reRun.Name = "reRun";
            this.reRun.Size = new System.Drawing.Size(127, 38);
            this.reRun.TabIndex = 7;
            this.reRun.Text = "Re-Run Extractor";
            this.reRun.UseVisualStyleBackColor = true;
            this.reRun.Click += new System.EventHandler(this.reRun_click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(1339, 976);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_openFolder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_folder, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.generateOutputFilenames, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_run, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.reRun, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_settings, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1339, 88);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // generateOutputFilenames
            // 
            this.generateOutputFilenames.AutoSize = true;
            this.generateOutputFilenames.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.generateOutputFilenames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateOutputFilenames.Location = new System.Drawing.Point(1060, 3);
            this.generateOutputFilenames.Name = "generateOutputFilenames";
            this.generateOutputFilenames.Size = new System.Drawing.Size(193, 38);
            this.generateOutputFilenames.TabIndex = 2;
            this.generateOutputFilenames.Text = "Generate Output Filenames";
            this.generateOutputFilenames.UseVisualStyleBackColor = true;
            // 
            // button_settings
            // 
            this.button_settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_settings.BackgroundImage")));
            this.button_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_settings.Location = new System.Drawing.Point(1259, 47);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(77, 38);
            this.button_settings.TabIndex = 8;
            this.button_settings.UseVisualStyleBackColor = true;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 862);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1339, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 976);
            this.Controls.Add(this.splitContainer1);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.Button button_openFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button reRun;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button generateOutputFilenames;
        private System.Windows.Forms.Button button_settings;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

