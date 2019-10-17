using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudentManageSystem.Methods;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManageSystem.Pages
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Upload upload = new Upload(FileUpload1, Server);
            Label1.Text = upload.UploadFile();
        }
    }
}