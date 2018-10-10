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
            path = @"C:\Users\zulfiqar\Downloads\Expense Claim Form (1).pdf";
            StringBuilder text = new StringBuilder();
            Document = new PdfReader(path);
        }

        //public string ExtractText(int PageNo)
        //{
        //    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
        //    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

        //    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));


        //    PdfPages page = Document.GetPageContent(PageNo);
        //    StringBuilder content = new StringBuilder();
        //    Text = content.Append(page.ExtractText()).ToString();            
        //    return Text;
        //}

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


    }
}
