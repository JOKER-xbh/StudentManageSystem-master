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
    public partial class log_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string pwd = TextBox2.Text;
            pwd = MyMD5.md5(pwd);
            Table_Manager new_one = new Table_Manager();
            string a=new_one.Inquire(name, pwd);
            if (a != null)
            {
                Response.Redirect("http://localhost:56740/Pages/course.aspx");                
            }

        }
    }
}
