using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using System;
using System.IO;
using System.Windows.Forms;

namespace PDFLinkUpdater
{
    class AsposeHelper
    {
        public static void UpdatePdf(string inputFile, string sourceDirectory, string copyDirectory, DataGridView SearchReplaceGrid)
        {
            DateTime startTime = DateTime.Now;
            try
            {
                // NOTE: The Aspose.Pdf library oddly doesn't use zero as a base.
                // That's while you'll see:
                // for (var x = 1; x < doc.Pages.Count + 1; x++)
                // instead of:
                //for (var x = 0; x < doc.Pages.Count; x++)                

                var asposeLicenseMax = 4;
                using (Document doc = new Document(inputFile))
                {
                    try
                    {
                        for (var x = 1; x < doc.Pages.Count + 1; x++)
                        {
                            var maxAnnotationCount = Aspose.Pdf.Document.IsLicensed
                                ? doc.Pages[x].Annotations.Count + 1
                                : asposeLicenseMax;
                            for (var y = 1; y < maxAnnotationCount; y++)
                            {

                                // Aspose.Pdf < v.17.12.0
                                //if (doc.Pages[x].Annotations[y] is LinkAnnotation)
                                //{
                                //    var link = (LinkAnnotation)doc.Pages[x].Annotations[y];
                                //    if (link.Action is LaunchAction)
                                //    {
                                //        foreach (DataGridViewRow row in SearchReplaceGrid.Rows)
                                //        {
                                //            var action = (LaunchAction)link.Action;
                                //            if (row.Cells[0].Value != null && row.Cells[1] != null)
                                //            {
                                //                action.File = action.File.Replace(row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString(), row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString());
                                //            }
                                //        }
                                //    }
                                // }

                                // Aspose.Pdf >= v.17.12.0
                                for (var z = 1; z < doc.Pages[x].Annotations[y].Actions.Count + 1; z++)
                                {
                                    if (doc.Pages[x].Annotations[y].Actions[z] is LaunchAction)
                                    {
                                        var action = (LaunchAction)doc.Pages[x].Annotations[y].Actions[z];
                                        foreach (DataGridViewRow row in SearchReplaceGrid.Rows)
                                        {
                                            if (row.Cells[0].Value != null && row.Cells[1] != null)
                                            {
                                                action.File = action.File.ToLower().Replace(
                                                    row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString().ToLower(),
                                                    row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString()
                                                );
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        var copyFilePath = copyDirectory + inputFile.Replace(sourceDirectory, "");
                        var copyDirectoryPath = Directory.GetParent(copyFilePath).ToString();
                        if (!Directory.Exists(copyDirectoryPath))
                        {
                            Directory.CreateDirectory(copyDirectoryPath);
                        }
                        doc.Save(copyFilePath);
                    }
                    catch (Exception ex1)
                    {
                        System.Diagnostics.Debug.WriteLine(ex1.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            System.Diagnostics.Debug.WriteLine((startTime - DateTime.Now).TotalSeconds + " seconds for " + inputFile);
        }
    }
}
