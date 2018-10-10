using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLibrary;
using PDFConverter;


namespace MiniProject
{
    public partial class ImportFiles : System.Web.UI.Page
    {
        private string FilePath;

         protected void Page_Load(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
            txtExtract.Text = string.Empty;
            FilePath = (string)ViewState["path"];
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(fileUpload.HasFile)
            {
                try
                {
                    ViewState["path"] = Path.GetFullPath(this.fileUpload.FileName);
                    FilePath = Path.GetFullPath(this.fileUpload.FileName);
                    fileUpload.SaveAs(Server.MapPath("~/") + FilePath);
                    StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch(Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtExtract.Text = string.Empty;
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {

            Converter pdf = new Converter(FilePath);
            txtExtract.Text = pdf.ReadPdfFile();
        }
    }
}