namespace PDFLinkUpdater
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
            this.SourceDirectoryLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SourceDirectory = new System.Windows.Forms.TextBox();
            this.OpenSourceDirectory = new System.Windows.Forms.Button();
            this.OpenCopyDirectory = new System.Windows.Forms.Button();
            this.CopyDirectory = new System.Windows.Forms.TextBox();
            this.CopyDirectoryLabel = new System.Windows.Forms.Label();
            this.SearchReplaceGrid = new System.Windows.Forms.DataGridView();
            this.Search = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Replace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.ApiSelectionIText = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.APISelectionAspose = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.SearchReplaceGrid)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceDirectoryLabel
            // 
            this.SourceDirectoryLabel.AutoSize = true;
            this.SourceDirectoryLabel.Location = new System.Drawing.Point(9, 14);
            this.SourceDirectoryLabel.Name = "SourceDirectoryLabel";
            this.SourceDirectoryLabel.Size = new System.Drawing.Size(196, 13);
            this.SourceDirectoryLabel.TabIndex = 0;
            this.SourceDirectoryLabel.Text = "Source Directory: (Location of PDF files)";
            // 
            // SourceDirectory
            // 
            this.SourceDirectory.Location = new System.Drawing.Point(12, 35);
            this.SourceDirectory.Name = "SourceDirectory";
            this.SourceDirectory.Size = new System.Drawing.Size(347, 20);
            this.SourceDirectory.TabIndex = 1;
            this.SourceDirectory.TextChanged += new System.EventHandler(this.SourceDirectory_TextChanged);
            // 
            // OpenSourceDirectory
            // 
            this.OpenSourceDirectory.Location = new System.Drawing.Point(365, 35);
            this.OpenSourceDirectory.Name = "OpenSourceDirectory";
            this.OpenSourceDirectory.Size = new System.Drawing.Size(31, 23);
            this.OpenSourceDirectory.TabIndex = 2;
            this.OpenSourceDirectory.Text = "...";
            this.OpenSourceDirectory.UseVisualStyleBackColor = true;
            this.OpenSourceDirectory.Click += new System.EventHandler(this.OpenSourceDirectory_Click);
            // 
            // OpenCopyDirectory
            // 
            this.OpenCopyDirectory.Location = new System.Drawing.Point(365, 95);
            this.OpenCopyDirectory.Name = "OpenCopyDirectory";
            this.OpenCopyDirectory.Size = new System.Drawing.Size(31, 23);
            this.OpenCopyDirectory.TabIndex = 5;
            this.OpenCopyDirectory.Text = "...";
            this.OpenCopyDirectory.UseVisualStyleBackColor = true;
            this.OpenCopyDirectory.Click += new System.EventHandler(this.OpenCopyDirectory_Click);
            // 
            // CopyDirectory
            // 
            this.CopyDirectory.Location = new System.Drawing.Point(12, 95);
            this.CopyDirectory.Name = "CopyDirectory";
            this.CopyDirectory.Size = new System.Drawing.Size(347, 20);
            this.CopyDirectory.TabIndex = 4;
            this.CopyDirectory.TextChanged += new System.EventHandler(this.CopyDirectory_TextChanged);
            // 
            // CopyDirectoryLabel
            // 
            this.CopyDirectoryLabel.AutoSize = true;
            this.CopyDirectoryLabel.Location = new System.Drawing.Point(9, 74);
            this.CopyDirectoryLabel.Name = "CopyDirectoryLabel";
            this.CopyDirectoryLabel.Size = new System.Drawing.Size(252, 13);
            this.CopyDirectoryLabel.TabIndex = 3;
            this.CopyDirectoryLabel.Text = "Copy Directory: (Where Updated files will be copied)";
            // 
            // SearchReplaceGrid
            // 
            this.SearchReplaceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SearchReplaceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchReplaceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Search,
            this.Replace});
            this.SearchReplaceGrid.Location = new System.Drawing.Point(12, 154);
            this.SearchReplaceGrid.Name = "SearchReplaceGrid";
            this.SearchReplaceGrid.Size = new System.Drawing.Size(384, 168);
            this.SearchReplaceGrid.TabIndex = 6;
            this.SearchReplaceGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.SearchReplaceGrid_CellValueChanged);
            this.SearchReplaceGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.SearchReplaceGrid_RowsAdded);
            this.SearchReplaceGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.SearchReplaceGrid_RowsRemoved);
            // 
            // Search
            // 
            this.Search.HeaderText = "Search";
            this.Search.Name = "Search";
            // 
            // Replace
            // 
            this.Replace.HeaderText = "Replace";
            this.Replace.Name = "Replace";
            // 
            // Start
            // 
            this.Start.Enabled = false;
            this.Start.Location = new System.Drawing.Point(321, 467);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 7;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 510);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.StatusStrip.Size = new System.Drawing.Size(411, 22);
            this.StatusStrip.TabIndex = 8;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // StatusStripLabel
            // 
            this.StatusStripLabel.Name = "StatusStripLabel";
            this.StatusStripLabel.Size = new System.Drawing.Size(205, 17);
            this.StatusStripLabel.Text = "Fill in fields above and then click Start";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search and Replace Terms";
            // 
            // ApiSelectionIText
            // 
            this.ApiSelectionIText.AutoSize = true;
            this.ApiSelectionIText.Checked = true;
            this.ApiSelectionIText.Location = new System.Drawing.Point(6, 30);
            this.ApiSelectionIText.Name = "ApiSelectionIText";
            this.ApiSelectionIText.Size = new System.Drawing.Size(131, 17);
            this.ApiSelectionIText.TabIndex = 10;
            this.ApiSelectionIText.TabStop = true;
            this.ApiSelectionIText.Text = "iText7 (AGPL License)";
            this.ApiSelectionIText.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.APISelectionAspose);
            this.groupBox1.Controls.Add(this.ApiSelectionIText);
            this.groupBox1.Location = new System.Drawing.Point(15, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "API Selector";
            // 
            // APISelectionAspose
            // 
            this.APISelectionAspose.AutoSize = true;
            this.APISelectionAspose.Location = new System.Drawing.Point(6, 62);
            this.APISelectionAspose.Name = "APISelectionAspose";
            this.APISelectionAspose.Size = new System.Drawing.Size(247, 17);
            this.APISelectionAspose.TabIndex = 11;
            this.APISelectionAspose.Text = "Aspose 17.12 (Unstable and Requires License)";
            this.APISelectionAspose.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 532);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.SearchReplaceGrid);
            this.Controls.Add(this.OpenCopyDirectory);
            this.Controls.Add(this.CopyDirectory);
            this.Controls.Add(this.CopyDirectoryLabel);
            this.Controls.Add(this.OpenSourceDirectory);
            this.Controls.Add(this.SourceDirectory);
            this.Controls.Add(this.SourceDirectoryLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "PDF Link Updater";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SearchReplaceGrid)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SourceDirectoryLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox SourceDirectory;
        private System.Windows.Forms.Button OpenSourceDirectory;
        private System.Windows.Forms.Button OpenCopyDirectory;
        private System.Windows.Forms.TextBox CopyDirectory;
        private System.Windows.Forms.Label CopyDirectoryLabel;
        private System.Windows.Forms.DataGridView SearchReplaceGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn Replace;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton ApiSelectionIText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton APISelectionAspose;
    }
}

