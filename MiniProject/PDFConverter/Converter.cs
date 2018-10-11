using System;
using System.Collections;
using System.Text;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


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

        public string ReadFromPosition()
        {
            Rectangle rect = new Rectangle(100, 200, 200, 300);
            RenderFilter[] filter = { new RegionTextRenderFilter(rect) };
            ITextExtractionStrategy strategy;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= Document.NumberOfPages; i++)
            {
                strategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), filter);
                sb.AppendLine(PdfTextExtractor.GetTextFromPage(Document, i, strategy));
            }

            return sb.ToString();
        }


    }
}
