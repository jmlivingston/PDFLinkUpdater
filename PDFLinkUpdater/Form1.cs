using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PDFLinkUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EnableStart()
        {
            var enabled = false;
            if (CopyDirectory.Text != "" && SourceDirectory.Text != "")
            {
                if (SearchReplaceGrid.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in SearchReplaceGrid.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            enabled = true;
                            break;
                        }
                    }
                }

            }
            Start.Enabled = enabled;
        }

        private void OpenSourceDirectory_Click(object sender, EventArgs e)
        {
            var dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                SourceDirectory.Text = folderBrowserDialog.SelectedPath;
            }
            EnableStart();
        }

        private void OpenCopyDirectory_Click(object sender, EventArgs e)
        {
            var dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                CopyDirectory.Text = folderBrowserDialog.SelectedPath;
            }
            EnableStart();
        }

        private void SearchReplaceGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            EnableStart();
        }

        private void SearchReplaceGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            EnableStart();
        }

        private void SourceDirectory_TextChanged(object sender, EventArgs e)
        {
            EnableStart();
        }

        private void CopyDirectory_TextChanged(object sender, EventArgs e)
        {
            EnableStart();
        }

        private void SearchReplaceGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            EnableStart();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StatusStripLabel.Text = "Started...";
            StatusStrip.Refresh();
            List<string> errors = new List<string>();
            foreach (string file in Directory.EnumerateFiles(SourceDirectory.Text, "*.pdf", SearchOption.AllDirectories))
            {
                try
                {
                    StatusStripLabel.Text = "Processing file: " + file;
                    StatusStrip.Refresh();
                    if (APISelectionAspose.Checked)
                    {
                        AsposeHelper.UpdatePdf(file, SourceDirectory.Text, CopyDirectory.Text, SearchReplaceGrid);
                    }
                    else
                    {
                        ITextSharpHelper.UpdatePdf(file, SourceDirectory.Text, CopyDirectory.Text, SearchReplaceGrid);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add("File " + file + " failed with error: " + ex.ToString());
                }
            }
            if (errors.Count > 0)
            {
                var logFilePath = Directory.GetCurrentDirectory() + "\\logs.txt";
                System.IO.File.WriteAllLines(logFilePath, errors.ToArray());
                MessageBox.Show("Error occurred! See log file " + logFilePath, "PDF Link Updater");
            }
            else
            {
                StatusStripLabel.Text = "Complete!";
                StatusStrip.Refresh();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var asposeLicensePath = Directory.GetCurrentDirectory() + "\\Aspose.Pdf.lic";
            var asposeLicense = new Aspose.Pdf.License();
            try
            {
                asposeLicense.SetLicense(asposeLicensePath);
                if (!Aspose.Pdf.Document.IsLicensed)
                {
                    throw new Exception(null);
                }
                asposeLicense.Embedded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Unable to load Aspose license, so you will have limited functionality. \r\nMake sure it is copied in the following directory: \r\n" + asposeLicensePath, "PDF Link Updater");
            }
            // UNCOMMENT TO TEST
            var testMode = false;
            if (testMode)
            {
                SourceDirectory.Text = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Files\\input";
                CopyDirectory.Text = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Files\\output";
                if (Directory.Exists(CopyDirectory.Text))
                {
                    Directory.Delete(CopyDirectory.Text, true);
                }
                SearchReplaceGrid.Rows.Add("red", "purple");
                SearchReplaceGrid.Rows.Add("yellow", "orange");
                SearchReplaceGrid.Rows.Add("blue", "green");
                Start.Enabled = true;
            }
        }
    }
}
