using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiniProject;


namespace MiniProject
{
    public partial class ImportFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(fileUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(this.fileUpload.FileName);
                    fileUpload.SaveAs(Server.MapPath("~/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch(Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            
        }
    }
}