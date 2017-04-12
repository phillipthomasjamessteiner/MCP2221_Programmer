namespace MCP2221_Form {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ProgConsole = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PresetsListBox = new System.Windows.Forms.ListBox();
            this.WordSizeTextBox = new System.Windows.Forms.TextBox();
            this.NumPagesTextBox = new System.Windows.Forms.TextBox();
            this.PageSizeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FlashFilePathTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BrowseFlashFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SavePresetButton = new System.Windows.Forms.Button();
            this.ProgCodeButton = new System.Windows.Forms.Button();
            this.WipeChipButton = new System.Windows.Forms.Button();
            this.LoadPresetButton = new System.Windows.Forms.Button();
            this.DevConnListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SelDevButton = new System.Windows.Forms.Button();
            this.TstConnButton = new System.Windows.Forms.Button();
            this.RefreshDevButton = new System.Windows.Forms.Button();
            this.CurrentDevTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ProgConsole
            // 
            this.ProgConsole.FormattingEnabled = true;
            this.ProgConsole.Location = new System.Drawing.Point(12, 268);
            this.ProgConsole.Name = "ProgConsole";
            this.ProgConsole.Size = new System.Drawing.Size(360, 147);
            this.ProgConsole.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Presets";
            // 
            // PresetsListBox
            // 
            this.PresetsListBox.FormattingEnabled = true;
            this.PresetsListBox.Location = new System.Drawing.Point(12, 25);
            this.PresetsListBox.Name = "PresetsListBox";
            this.PresetsListBox.Size = new System.Drawing.Size(120, 95);
            this.PresetsListBox.TabIndex = 1;
            // 
            // WordSizeTextBox
            // 
            this.WordSizeTextBox.Location = new System.Drawing.Point(12, 151);
            this.WordSizeTextBox.Name = "WordSizeTextBox";
            this.WordSizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.WordSizeTextBox.TabIndex = 8;
            this.WordSizeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WordSizeTextBox_KeyPress);
            // 
            // NumPagesTextBox
            // 
            this.NumPagesTextBox.Location = new System.Drawing.Point(272, 151);
            this.NumPagesTextBox.Name = "NumPagesTextBox";
            this.NumPagesTextBox.Size = new System.Drawing.Size(100, 20);
            this.NumPagesTextBox.TabIndex = 10;
            this.NumPagesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumPagesTextBox_KeyPress);
            // 
            // PageSizeTextBox
            // 
            this.PageSizeTextBox.Location = new System.Drawing.Point(142, 151);
            this.PageSizeTextBox.Name = "PageSizeTextBox";
            this.PageSizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.PageSizeTextBox.TabIndex = 9;
            this.PageSizeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PageSizeTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Word Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Page Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of Pages";
            // 
            // FlashFilePathTextBox
            // 
            this.FlashFilePathTextBox.Location = new System.Drawing.Point(142, 100);
            this.FlashFilePathTextBox.Name = "FlashFilePathTextBox";
            this.FlashFilePathTextBox.Size = new System.Drawing.Size(200, 20);
            this.FlashFilePathTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Flash File Path";
            // 
            // BrowseFlashFileButton
            // 
            this.BrowseFlashFileButton.Location = new System.Drawing.Point(348, 99);
            this.BrowseFlashFileButton.Name = "BrowseFlashFileButton";
            this.BrowseFlashFileButton.Size = new System.Drawing.Size(24, 20);
            this.BrowseFlashFileButton.TabIndex = 7;
            this.BrowseFlashFileButton.Text = "...";
            this.BrowseFlashFileButton.UseVisualStyleBackColor = true;
            this.BrowseFlashFileButton.Click += new System.EventHandler(this.BrowseFlashFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SavePresetButton
            // 
            this.SavePresetButton.Location = new System.Drawing.Point(142, 25);
            this.SavePresetButton.Name = "SavePresetButton";
            this.SavePresetButton.Size = new System.Drawing.Size(100, 23);
            this.SavePresetButton.TabIndex = 2;
            this.SavePresetButton.Text = "Save Preset";
            this.SavePresetButton.UseVisualStyleBackColor = true;
            this.SavePresetButton.Click += new System.EventHandler(this.SavePresetButton_Click);
            // 
            // ProgCodeButton
            // 
            this.ProgCodeButton.Location = new System.Drawing.Point(272, 25);
            this.ProgCodeButton.Name = "ProgCodeButton";
            this.ProgCodeButton.Size = new System.Drawing.Size(100, 23);
            this.ProgCodeButton.TabIndex = 4;
            this.ProgCodeButton.Text = "Program Code";
            this.ProgCodeButton.UseVisualStyleBackColor = true;
            // 
            // WipeChipButton
            // 
            this.WipeChipButton.Location = new System.Drawing.Point(272, 55);
            this.WipeChipButton.Name = "WipeChipButton";
            this.WipeChipButton.Size = new System.Drawing.Size(100, 23);
            this.WipeChipButton.TabIndex = 5;
            this.WipeChipButton.Text = "Wipe Chip";
            this.WipeChipButton.UseVisualStyleBackColor = true;
            // 
            // LoadPresetButton
            // 
            this.LoadPresetButton.Location = new System.Drawing.Point(142, 55);
            this.LoadPresetButton.Name = "LoadPresetButton";
            this.LoadPresetButton.Size = new System.Drawing.Size(100, 23);
            this.LoadPresetButton.TabIndex = 3;
            this.LoadPresetButton.Text = "Load Preset";
            this.LoadPresetButton.UseVisualStyleBackColor = true;
            this.LoadPresetButton.Click += new System.EventHandler(this.LoadPresetButton_Click);
            // 
            // DevConnListBox
            // 
            this.DevConnListBox.FormattingEnabled = true;
            this.DevConnListBox.Location = new System.Drawing.Point(9, 199);
            this.DevConnListBox.Name = "DevConnListBox";
            this.DevConnListBox.Size = new System.Drawing.Size(120, 56);
            this.DevConnListBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Devices Connected";
            // 
            // SelDevButton
            // 
            this.SelDevButton.Location = new System.Drawing.Point(139, 199);
            this.SelDevButton.Name = "SelDevButton";
            this.SelDevButton.Size = new System.Drawing.Size(100, 23);
            this.SelDevButton.TabIndex = 12;
            this.SelDevButton.Text = "Select Device";
            this.SelDevButton.UseVisualStyleBackColor = true;
            this.SelDevButton.Click += new System.EventHandler(this.SelDevButton_Click);
            // 
            // TstConnButton
            // 
            this.TstConnButton.Location = new System.Drawing.Point(269, 228);
            this.TstConnButton.Name = "TstConnButton";
            this.TstConnButton.Size = new System.Drawing.Size(100, 23);
            this.TstConnButton.TabIndex = 15;
            this.TstConnButton.Text = "Test Connection";
            this.TstConnButton.UseVisualStyleBackColor = true;
            this.TstConnButton.Click += new System.EventHandler(this.TstConnButton_Click);
            // 
            // RefreshDevButton
            // 
            this.RefreshDevButton.Location = new System.Drawing.Point(269, 199);
            this.RefreshDevButton.Name = "RefreshDevButton";
            this.RefreshDevButton.Size = new System.Drawing.Size(100, 23);
            this.RefreshDevButton.TabIndex = 13;
            this.RefreshDevButton.Text = "Refresh Devices";
            this.RefreshDevButton.UseVisualStyleBackColor = true;
            this.RefreshDevButton.Click += new System.EventHandler(this.RefreshDevButton_Click);
            // 
            // CurrentDevTextbox
            // 
            this.CurrentDevTextbox.Location = new System.Drawing.Point(139, 234);
            this.CurrentDevTextbox.Name = "CurrentDevTextbox";
            this.CurrentDevTextbox.Size = new System.Drawing.Size(100, 20);
            this.CurrentDevTextbox.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 427);
            this.Controls.Add(this.CurrentDevTextbox);
            this.Controls.Add(this.RefreshDevButton);
            this.Controls.Add(this.TstConnButton);
            this.Controls.Add(this.SelDevButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DevConnListBox);
            this.Controls.Add(this.LoadPresetButton);
            this.Controls.Add(this.WipeChipButton);
            this.Controls.Add(this.ProgCodeButton);
            this.Controls.Add(this.SavePresetButton);
            this.Controls.Add(this.BrowseFlashFileButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FlashFilePathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PageSizeTextBox);
            this.Controls.Add(this.NumPagesTextBox);
            this.Controls.Add(this.WordSizeTextBox);
            this.Controls.Add(this.PresetsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgConsole);
            this.Name = "Form1";
            this.Text = "MCP2221 ATtiny Programmer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox ProgConsole;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox PresetsListBox;
        public System.Windows.Forms.TextBox WordSizeTextBox;
        public System.Windows.Forms.TextBox NumPagesTextBox;
        public System.Windows.Forms.TextBox PageSizeTextBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox FlashFilePathTextBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button BrowseFlashFileButton;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button SavePresetButton;
        public System.Windows.Forms.Button ProgCodeButton;
        public System.Windows.Forms.Button WipeChipButton;
        public System.Windows.Forms.Button LoadPresetButton;
        public System.Windows.Forms.ListBox DevConnListBox;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button SelDevButton;
        public System.Windows.Forms.Button TstConnButton;
        public System.Windows.Forms.Button RefreshDevButton;
        public System.Windows.Forms.TextBox CurrentDevTextbox;
    }
}

