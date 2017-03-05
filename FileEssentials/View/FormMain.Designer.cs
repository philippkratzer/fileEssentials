namespace FileEssentials.View
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBrowsePictures = new System.Windows.Forms.Button();
            this.textBoxPathPictures = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowseDestination = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPathDestination = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.buttonRemoveBlacklist = new System.Windows.Forms.Button();
            this.buttonAddBlacklist = new System.Windows.Forms.Button();
            this.buttonBrowseBlacklist = new System.Windows.Forms.Button();
            this.textBoxBlacklist = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxBlacklist = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.labelAddedFiles = new System.Windows.Forms.Label();
            this.labelSkippedFiles = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowsePictures
            // 
            this.buttonBrowsePictures.Location = new System.Drawing.Point(505, 32);
            this.buttonBrowsePictures.Name = "buttonBrowsePictures";
            this.buttonBrowsePictures.Size = new System.Drawing.Size(75, 25);
            this.buttonBrowsePictures.TabIndex = 0;
            this.buttonBrowsePictures.Text = "Browse";
            this.buttonBrowsePictures.UseVisualStyleBackColor = true;
            this.buttonBrowsePictures.Click += new System.EventHandler(this.buttonBrowsePictures_Click);
            // 
            // textBoxPathPictures
            // 
            this.textBoxPathPictures.Location = new System.Drawing.Point(154, 34);
            this.textBoxPathPictures.Name = "textBoxPathPictures";
            this.textBoxPathPictures.Size = new System.Drawing.Size(345, 22);
            this.textBoxPathPictures.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path Pictures";
            // 
            // buttonBrowseDestination
            // 
            this.buttonBrowseDestination.Location = new System.Drawing.Point(505, 63);
            this.buttonBrowseDestination.Name = "buttonBrowseDestination";
            this.buttonBrowseDestination.Size = new System.Drawing.Size(75, 25);
            this.buttonBrowseDestination.TabIndex = 3;
            this.buttonBrowseDestination.Text = "Browse";
            this.buttonBrowseDestination.UseVisualStyleBackColor = true;
            this.buttonBrowseDestination.Click += new System.EventHandler(this.buttonBrowseDestination_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path Destination";
            // 
            // textBoxPathDestination
            // 
            this.textBoxPathDestination.Location = new System.Drawing.Point(154, 65);
            this.textBoxPathDestination.Name = "textBoxPathDestination";
            this.textBoxPathDestination.Size = new System.Drawing.Size(345, 22);
            this.textBoxPathDestination.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Resize: Long side (px):";
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new System.Drawing.Point(154, 109);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownSize.TabIndex = 7;
            this.numericUpDownSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonRemoveBlacklist
            // 
            this.buttonRemoveBlacklist.Location = new System.Drawing.Point(667, 154);
            this.buttonRemoveBlacklist.Name = "buttonRemoveBlacklist";
            this.buttonRemoveBlacklist.Size = new System.Drawing.Size(75, 25);
            this.buttonRemoveBlacklist.TabIndex = 1018;
            this.buttonRemoveBlacklist.Text = "Remove";
            this.buttonRemoveBlacklist.UseVisualStyleBackColor = true;
            this.buttonRemoveBlacklist.Click += new System.EventHandler(this.buttonRemoveBlacklist_Click);
            // 
            // buttonAddBlacklist
            // 
            this.buttonAddBlacklist.Location = new System.Drawing.Point(586, 154);
            this.buttonAddBlacklist.Name = "buttonAddBlacklist";
            this.buttonAddBlacklist.Size = new System.Drawing.Size(75, 25);
            this.buttonAddBlacklist.TabIndex = 1017;
            this.buttonAddBlacklist.Text = "Add";
            this.buttonAddBlacklist.UseVisualStyleBackColor = true;
            this.buttonAddBlacklist.Click += new System.EventHandler(this.buttonAddBlacklist_Click);
            // 
            // buttonBrowseBlacklist
            // 
            this.buttonBrowseBlacklist.Location = new System.Drawing.Point(505, 154);
            this.buttonBrowseBlacklist.Name = "buttonBrowseBlacklist";
            this.buttonBrowseBlacklist.Size = new System.Drawing.Size(75, 25);
            this.buttonBrowseBlacklist.TabIndex = 1016;
            this.buttonBrowseBlacklist.Text = "Browse";
            this.buttonBrowseBlacklist.UseVisualStyleBackColor = true;
            this.buttonBrowseBlacklist.Click += new System.EventHandler(this.buttonBrowseBlacklist_Click);
            // 
            // textBoxBlacklist
            // 
            this.textBoxBlacklist.Location = new System.Drawing.Point(154, 156);
            this.textBoxBlacklist.Name = "textBoxBlacklist";
            this.textBoxBlacklist.Size = new System.Drawing.Size(345, 22);
            this.textBoxBlacklist.TabIndex = 1015;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 1014;
            this.label4.Text = "Blacklist";
            // 
            // listBoxBlacklist
            // 
            this.listBoxBlacklist.FormattingEnabled = true;
            this.listBoxBlacklist.ItemHeight = 14;
            this.listBoxBlacklist.Location = new System.Drawing.Point(154, 184);
            this.listBoxBlacklist.Name = "listBoxBlacklist";
            this.listBoxBlacklist.Size = new System.Drawing.Size(588, 88);
            this.listBoxBlacklist.TabIndex = 1013;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(15, 314);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1019;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(799, 24);
            this.menuStrip1.TabIndex = 1020;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 1021;
            this.label5.Text = "Added files:";
            // 
            // labelAddedFiles
            // 
            this.labelAddedFiles.AutoSize = true;
            this.labelAddedFiles.Location = new System.Drawing.Point(232, 318);
            this.labelAddedFiles.Name = "labelAddedFiles";
            this.labelAddedFiles.Size = new System.Drawing.Size(43, 14);
            this.labelAddedFiles.TabIndex = 1022;
            this.labelAddedFiles.Text = "000000";
            // 
            // labelSkippedFiles
            // 
            this.labelSkippedFiles.AutoSize = true;
            this.labelSkippedFiles.Location = new System.Drawing.Point(396, 318);
            this.labelSkippedFiles.Name = "labelSkippedFiles";
            this.labelSkippedFiles.Size = new System.Drawing.Size(43, 14);
            this.labelSkippedFiles.TabIndex = 1024;
            this.labelSkippedFiles.Text = "000000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 14);
            this.label8.TabIndex = 1023;
            this.label8.Text = "Skipped files:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 367);
            this.Controls.Add(this.labelSkippedFiles);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelAddedFiles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonRemoveBlacklist);
            this.Controls.Add(this.buttonAddBlacklist);
            this.Controls.Add(this.buttonBrowseBlacklist);
            this.Controls.Add(this.textBoxBlacklist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxBlacklist);
            this.Controls.Add(this.numericUpDownSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPathDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowseDestination);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPathPictures);
            this.Controls.Add(this.buttonBrowsePictures);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FileEssentials";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowsePictures;
        private System.Windows.Forms.TextBox textBoxPathPictures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowseDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPathDestination;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.Button buttonRemoveBlacklist;
        private System.Windows.Forms.Button buttonAddBlacklist;
        private System.Windows.Forms.Button buttonBrowseBlacklist;
        private System.Windows.Forms.TextBox textBoxBlacklist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxBlacklist;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelAddedFiles;
        private System.Windows.Forms.Label labelSkippedFiles;
        private System.Windows.Forms.Label label8;
    }
}

