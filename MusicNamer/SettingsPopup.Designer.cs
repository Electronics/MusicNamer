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
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(147, 321);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(100, 35);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(268, 321);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 35);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_exportFolders
            // 
            this.checkBox_exportFolders.AutoSize = true;
            this.checkBox_exportFolders.Location = new System.Drawing.Point(12, 12);
            this.checkBox_exportFolders.Name = "checkBox_exportFolders";
            this.checkBox_exportFolders.Size = new System.Drawing.Size(206, 21);
            this.checkBox_exportFolders.TabIndex = 2;
            this.checkBox_exportFolders.Text = "Export Files to Artist Folders";
            this.checkBox_exportFolders.UseVisualStyleBackColor = true;
            // 
            // checkedListBox_disabledExtractors
            // 
            this.checkedListBox_disabledExtractors.FormattingEnabled = true;
            this.checkedListBox_disabledExtractors.Location = new System.Drawing.Point(12, 56);
            this.checkedListBox_disabledExtractors.Name = "checkedListBox_disabledExtractors";
            this.checkedListBox_disabledExtractors.Size = new System.Drawing.Size(478, 106);
            this.checkedListBox_disabledExtractors.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Disabled Extractors";
            // 
            // checkedListBox_disabledAPIs
            // 
            this.checkedListBox_disabledAPIs.FormattingEnabled = true;
            this.checkedListBox_disabledAPIs.Location = new System.Drawing.Point(12, 197);
            this.checkedListBox_disabledAPIs.Name = "checkedListBox_disabledAPIs";
            this.checkedListBox_disabledAPIs.Size = new System.Drawing.Size(478, 106);
            this.checkedListBox_disabledAPIs.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Disabled APIs";
            // 
            // SettingsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBox_disabledAPIs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox_disabledExtractors);
            this.Controls.Add(this.checkBox_exportFolders);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
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
    }
}