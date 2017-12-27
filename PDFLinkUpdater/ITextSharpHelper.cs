// iText7 Community

using iText.Kernel.Pdf;
using System;
using System.IO;
using System.Windows.Forms;

namespace PDFLinkUpdater
{
    class ITextSharpHelper
    {
        public static void UpdatePdf(string inputFile, string sourceDirectory, string copyDirectory, DataGridView SearchReplaceGrid)
        {
            DateTime startTime = DateTime.Now;
            try
            {
                var copyFilePath = copyDirectory + inputFile.Replace(sourceDirectory, "");
                var copyDirectoryPath = Directory.GetParent(copyFilePath).ToString();
                if (!Directory.Exists(copyDirectoryPath))
                {
                    Directory.CreateDirectory(copyDirectoryPath);
                }
                PdfDocument pdfDocument = new PdfDocument(new PdfReader(inputFile), new PdfWriter(copyFilePath));
                for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
                {
                    var pageDictionary = pdfDocument.GetPage(i);
                    var pageAnnotations = pageDictionary.GetAnnotations();
                    if ((pageAnnotations == null) || (pageAnnotations.Count == 0))
                        continue;
                    foreach (var pageAnnotation in pageAnnotations)
                    {
                        var AnnotationDictionary = pageAnnotation.GetPdfObject() as PdfDictionary;
                        if (AnnotationDictionary == null)
                            continue;
                        if (!AnnotationDictionary.Get(PdfName.Subtype).Equals(PdfName.Link))
                            continue;
                        if (AnnotationDictionary.Get(PdfName.A) == null)
                            continue;
                        var annotActionObject = AnnotationDictionary.Get(PdfName.A);
                        var AnnotationAction = (PdfDictionary)(annotActionObject.IsIndirect() ? annotActionObject : annotActionObject);
                        var type = AnnotationAction.Get(PdfName.S);
                        if (type.Equals(PdfName.URI))
                        {
                            string relativeRef = AnnotationAction.GetAsString(PdfName.URI).ToString();
                        }
                        else if (type.Equals(PdfName.Launch))
                        {
                            var filespec = AnnotationAction.GetAsDictionary(PdfName.F);
                            string url = filespec.GetAsString(PdfName.F).ToString();
                            foreach (DataGridViewRow row in SearchReplaceGrid.Rows)
                            {
                                if (row.Cells[0].Value != null && row.Cells[1] != null)
                                {
                                    url = url.ToLower().Replace(
                                        row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString().ToLower(),
                                        row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString()
                                    );
                                }
                            }
                            AnnotationAction.Put(PdfName.F, new PdfString(url));
                        }
                    }
                }
                pdfDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            System.Diagnostics.Debug.WriteLine((startTime - DateTime.Now).TotalSeconds + " seconds for " + inputFile);
        }
    }
}

// If using iTextSharp 5.0
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using System;
//using System.IO;
//using System.Windows.Forms;

//namespace PDFLinkUpdater
//{
//    class ITextSharpHelper
//    {
//        public static void UpdatePdf(string inputFile, string sourceDirectory, string copyDirectory, DataGridView SearchReplaceGrid)
//        {
//            DateTime startTime = DateTime.Now;
//            try
//            {
//                PdfReader r = new PdfReader(inputFile);
//                for (int i = 1; i <= r.NumberOfPages; i++)
//                {
//                    var pageDictionary = r.GetPageN(i);
//                    var pdfArray = pageDictionary.GetAsArray(PdfName.ANNOTS);
//                    if ((pdfArray == null) || (pdfArray.Length == 0))
//                        continue;
//                    foreach (var pdfObject in pdfArray.ArrayList)
//                    {
//                        var AnnotationDictionary = PdfReader.GetPdfObject(pdfObject) as PdfDictionary;
//                        if (AnnotationDictionary == null)
//                            continue;
//                        if (!AnnotationDictionary.Get(PdfName.SUBTYPE).Equals(PdfName.LINK))
//                            continue;
//                        if (AnnotationDictionary.Get(PdfName.A) == null)
//                            continue;
//                        var annotActionObject = AnnotationDictionary.Get(PdfName.A);
//                        var AnnotationAction = (PdfDictionary)(annotActionObject.IsIndirect() ? PdfReader.GetPdfObject(annotActionObject) : annotActionObject);
//                        var type = AnnotationAction.Get(PdfName.S);
//                        if (type.Equals(PdfName.URI))
//                        {
//                            string relativeRef = AnnotationAction.GetAsString(PdfName.URI).ToString();
//                        }
//                        else if (type.Equals(PdfName.LAUNCH))
//                        {
//                            var filespec = AnnotationAction.GetAsDict(PdfName.F);
//                            string url = filespec.GetAsString(PdfName.F).ToString();
//                            foreach (DataGridViewRow row in SearchReplaceGrid.Rows)
//                            {
//                                if (row.Cells[0].Value != null && row.Cells[1] != null)
//                                {
//                                    url = url.ToLower().Replace(
//                                        row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString().ToLower(),
//                                        row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString()
//                                    );
//                                }
//                            }
//                            AnnotationAction.Put(PdfName.F, new PdfString(url));
//                        }
//                    }
//                }
//                var copyFilePath = copyDirectory + inputFile.Replace(sourceDirectory, "");
//                var copyDirectoryPath = Directory.GetParent(copyFilePath).ToString();
//                if (!Directory.Exists(copyDirectoryPath))
//                {
//                    Directory.CreateDirectory(copyDirectoryPath);
//                }
//                using (var output = File.OpenWrite(copyFilePath))
//                {
//                    using (Document Doc = new Document())
//                    {
//                        using (PdfCopy writer = new PdfCopy(Doc, output))
//                        {
//                            Doc.Open();
//                            for (int i = 1; i <= r.NumberOfPages; i++)
//                            {
//                                writer.AddPage(writer.GetImportedPage(r, i));
//                            }
//                            Doc.Close();
//                        }
//                    }
//                }
//                r.Close();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//            System.Diagnostics.Debug.WriteLine((startTime - DateTime.Now).TotalSeconds + " seconds for " + inputFile);
//        }
//    }
//}
