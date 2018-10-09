using System;
using System.Collections;
using System.Text;
using Spire.Pdf;


namespace PDFConverter
{
    public class Converter
    {

        private PdfDocument Document;

        public string Text { get; set; }


        public Converter()
        {
            Text = string.Empty;
        }

        public Converter(string path)
        {
            Document = new PdfDocument();
            Document.LoadFromFile(path);
        }

        public string ExtractText(int PageNo)
        {
            PdfPageBase page = GetPage(PageNo);
            StringBuilder content = new StringBuilder();
            Text = content.Append(page.ExtractText()).ToString();            
            return Text;
        }

        private PdfPageBase GetPage(int PageNo)
        {
            PdfPageBase page = null;

            try
            {
                page = Document.Pages[PageNo];
            }
            catch(Exception ex)
            {
                throw new Exception("No page for the given page no");
            }

            return page;
        }


    }
}
