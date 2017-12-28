# PDF Link Updater

Author: John Livingston

## Start

- Install using PDFLinkUpdater/Setup/Release/PDFLinkUpdaterSetup.msi (Alternatively: Download repo, unzip, then run PDFLinkUpdater.exe PDFLinkUpdater/bin/Release)
- Change the Source Directory and Copy Directory. You can keep these the same, but a different directory would be recommended since this tool doesn't back anything up.
- Update grid with values you will be searching and replacing with.
- Select an API. iText5 (AGPL License) is recommended as Aspose cannot efficiently save large files.
- Click the Start button.

## Errors

1. If one of the PDF files is open, so you are unable to save. If this happens, you will get a message at the end and a logs.txt file will be generated at the source directory specified.


## Troubleshooting

- Make sure no related PDFs are currently opened as this can block saving.
- Open solution in Visual Studio and try debugging.
- You can uncomment the test code in Form1_Load. This will allow you to test with PDF files in the Files directory

---

## Aspose Alternative (Not Recommended)

> Note: I have tried several versions of Aspose (including the latest 17.12.0) and it throws exceptions with no detail with large 20MB+ files. Unfortunately these exceptions are swallowed and there are no solutions on any of the forums.

### Requirements

- [Aspose.Pdf License](https://products.aspose.com/pdf/net)

### Installation

- Copy the Aspose.Pdf license to the same directory as PDFLinkUpdater.exe (bin/Release) and name it as "Aspose.Pdf.lic".
- Follow the Start instructions above, but select Aspose when prompted.

## Errors

There are two common errors:

1. A missing Aspose.Pdf licence. You can still run the project, but it will run in trial mode and only update 4 links in the PDF. This includes annotations, like comments, so it might not be obvious in a PDF file with tons of links.
2. Aspose simply hangs when trying to save the document per the note above.