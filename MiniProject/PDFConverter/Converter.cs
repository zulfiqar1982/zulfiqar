using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Drawing;
using System.util;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
//using Spire.Pdf;
using Bytescout.PDFExtractor;


namespace PDFConverter
{
    public class Converter
    {

        private PdfReader Document;

        public string Text { get; set; }


        public Converter()
        {
            Text = string.Empty;
        }

        public Converter(string path)
        {
            path = @"C:\Users\zulfiqar\Downloads\ExpenseClaimForm1_b2abe30fabca4b1ca322fafd74306ceb (1).pdf";
            StringBuilder text = new StringBuilder();
            Document = new PdfReader(path);
            //Document = new PdfDocument();
            //Document.LoadFromFile(path);
        }

        public string ReadPdfFile()
        {
            StringBuilder text = new StringBuilder();

            for (int page = 1; page <= Document.NumberOfPages; page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string currentText = PdfTextExtractor.GetTextFromPage(Document, page, strategy);

                currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                text.Append(currentText);
            }
            Document.Close();

            return text.ToString();
        }

        public string ReadFromPosistionIText()
        {
            RectangleJ rect = new RectangleJ(0, 0, 2000, 1800);
            RenderFilter[] filter = { new RegionTextRenderFilter(rect) };
            ITextExtractionStrategy strategy;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= Document.NumberOfPages; i++)
            {
                strategy = new FilteredTextRenderListener(
                  new LocationTextExtractionStrategy(), filter
                );
                sb.AppendLine(
                  PdfTextExtractor.GetTextFromPage(Document, i, strategy)
                );
            }

            return sb.ToString();
        }

        //public string ReadFromPositionSpire()
        //{
        //    PdfPageBase page = Document.Pages[0];
        //    string text = page.ExtractText(new RectangleF(50, 50, 500, 100));
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(text);
        //    return sb.ToString();
        //    return string.Empty;
        //}

        public string BytescoutPDFExtractor(string path)
        {
            TextExtractor extractor = new TextExtractor("demo", "demo");

            path = @"C:\Users\zulfiqar\Downloads\ExpenseClaimForm1_b2abe30fabca4b1ca322fafd74306ceb (1).pdf";

            // load the document
            extractor.LoadDocumentFromFile(path);

            // get page count
            //int pageCount = extractor.GetPageCount();
            //int count = 0;

            // iterate through pages
           

                // define rectangle location to extract from
                RectangleF location = new RectangleF(0, 0, 200, 200);

                // set extraction area
                extractor.SetExtractionArea(location);

                // extract text bounded by the extraction area
                string extractedString = extractor.GetTextFromPage(0);

            return extractedString;

        }


    }
}
