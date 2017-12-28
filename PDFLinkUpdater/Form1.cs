using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PDFLinkUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
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
            if (backgroundWorker.IsBusy != true)
            {
                StatusStripLabel.Text = "Started...";
                StatusStrip.Refresh();
                progressBar.Visible = true;
                Cancel.Enabled = true;
                progressBar.Minimum = 1;
                progressBar.Maximum = Directory.EnumerateFiles(SourceDirectory.Text, "*.pdf", SearchOption.AllDirectories).ToArray().Length;
                progressBar.Step = 1;
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // UNCOMMENT TO TEST
            var testMode = false;
            if (testMode)
            {
                SourceDirectory.Text = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Files\\input");
                CopyDirectory.Text = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Files\\output");
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.WorkerSupportsCancellation == true)
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<string> errors = new List<string>();
            var pdfFiles = Directory.EnumerateFiles(SourceDirectory.Text, "*.pdf", SearchOption.AllDirectories).ToArray();
            for (var i = 0; i < pdfFiles.Length; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    var file = pdfFiles[i];
                    try
                    {
                        System.Threading.Thread.Sleep(1000);
                        worker.ReportProgress(i + 1, file);
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

            }
            if (errors.Count > 0)
            {
                var logFilePath = Path.Combine(SourceDirectory.Text, "logs.txt");
                System.IO.File.WriteAllLines(logFilePath, errors.ToArray());
                MessageBox.Show("Error occurred! See log file " + logFilePath, "PDF Link Updater");
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                this.BeginInvoke((Action)(() =>
                {
                    StatusStripLabel.Text = "Processing " + e.UserState.ToString() + "...";
                    progressBar.Value = e.ProgressPercentage;
                }));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                StatusStripLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                StatusStripLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                StatusStripLabel.Text = "Done!";
            }
            Cancel.Enabled = false;
            progressBar.Visible = false;
        }

        private void APISelectionAspose_CheckedChanged(object sender, EventArgs e)
        {
            if (APISelectionAspose.Checked)
            {
                var asposeLicensePath = Path.Combine(Directory.GetCurrentDirectory(), "Aspose.Pdf.lic");
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
                    MessageBox.Show("Error: Unable to load Aspose license, so you will have limited functionality. \r\nMake sure it is copied in the following directory: \r\n" + asposeLicensePath +
                        "\r\n\r\nNote: You can also try the iText7 option", "PDF Link Updater");
                }
            }
        }
    }
}
