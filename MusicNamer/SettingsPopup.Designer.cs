namespace MusicNamer
{
    partial class SettingsPopup
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
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_exportFolders = new System.Windows.Forms.CheckBox();
            this.checkedListBox_disabledExtractors = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox_disabledAPIs = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_importFromSubfolders = new System.Windows.Forms.CheckBox();
            this.checkBox_artistFolders = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(110, 290);
            this.button_ok.Margin = new System.Windows.Forms.Padding(2);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 28);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(201, 290);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 28);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_exportFolders
            // 
            this.checkBox_exportFolders.AutoSize = true;
            this.checkBox_exportFolders.Location = new System.Drawing.Point(11, 32);
            this.checkBox_exportFolders.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_exportFolders.Name = "checkBox_exportFolders";
            this.checkBox_exportFolders.Size = new System.Drawing.Size(155, 17);
            this.checkBox_exportFolders.TabIndex = 2;
            this.checkBox_exportFolders.Text = "Export Files to Artist Folders";
            this.checkBox_exportFolders.UseVisualStyleBackColor = true;
            this.checkBox_exportFolders.CheckedChanged += new System.EventHandler(this.checkBox_exportFolders_CheckedChanged);
            // 
            // checkedListBox_disabledExtractors
            // 
            this.checkedListBox_disabledExtractors.FormattingEnabled = true;
            this.checkedListBox_disabledExtractors.Location = new System.Drawing.Point(11, 93);
            this.checkedListBox_disabledExtractors.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBox_disabledExtractors.Name = "checkedListBox_disabledExtractors";
            this.checkedListBox_disabledExtractors.Size = new System.Drawing.Size(360, 79);
            this.checkedListBox_disabledExtractors.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Disabled Extractors";
            // 
            // checkedListBox_disabledAPIs
            // 
            this.checkedListBox_disabledAPIs.FormattingEnabled = true;
            this.checkedListBox_disabledAPIs.Location = new System.Drawing.Point(11, 207);
            this.checkedListBox_disabledAPIs.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBox_disabledAPIs.Name = "checkedListBox_disabledAPIs";
            this.checkedListBox_disabledAPIs.Size = new System.Drawing.Size(360, 79);
            this.checkedListBox_disabledAPIs.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Disabled APIs";
            // 
            // checkBox_importFromSubfolders
            // 
            this.checkBox_importFromSubfolders.AutoSize = true;
            this.checkBox_importFromSubfolders.Location = new System.Drawing.Point(11, 11);
            this.checkBox_importFromSubfolders.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_importFromSubfolders.Name = "checkBox_importFromSubfolders";
            this.checkBox_importFromSubfolders.Size = new System.Drawing.Size(158, 17);
            this.checkBox_importFromSubfolders.TabIndex = 7;
            this.checkBox_importFromSubfolders.Text = "Import Files from SubFolders";
            this.checkBox_importFromSubfolders.UseVisualStyleBackColor = true;
            // 
            // checkBox_artistFolders
            // 
            this.checkBox_artistFolders.AutoSize = true;
            this.checkBox_artistFolders.Location = new System.Drawing.Point(11, 53);
            this.checkBox_artistFolders.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_artistFolders.Name = "checkBox_artistFolders";
            this.checkBox_artistFolders.Size = new System.Drawing.Size(161, 17);
            this.checkBox_artistFolders.TabIndex = 8;
            this.checkBox_artistFolders.Text = "Export Files to Album Folders";
            this.checkBox_artistFolders.UseVisualStyleBackColor = true;
            // 
            // SettingsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 349);
            this.Controls.Add(this.checkBox_artistFolders);
            this.Controls.Add(this.checkBox_importFromSubfolders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBox_disabledAPIs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox_disabledExtractors);
            this.Controls.Add(this.checkBox_exportFolders);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsPopup";
            this.Text = "SettingsPopup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkBox_exportFolders;
        private System.Windows.Forms.CheckedListBox checkedListBox_disabledExtractors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox_disabledAPIs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_importFromSubfolders;
        private System.Windows.Forms.CheckBox checkBox_artistFolders;
    }
}