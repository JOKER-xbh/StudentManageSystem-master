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
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;
using System.Text;

namespace StudentManageSystem.Pages
{
    public partial class course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Search(object sender, EventArgs e)
        {
            Table_Class search_one = new Table_Class();
            StringBuilder sbTable = new StringBuilder();
            String a=search_one.Inquire();
            var jArray= MySqlFunctions.string_to_array(a);
            sbTable.Append("<table><thead>");
            sbTable.Append("<tr><th>");
            sbTable.Append("课程名");
            sbTable.Append("</th><th>");
            sbTable.Append("课程号");
            sbTable.Append("</th><th>");
            sbTable.Append("教师名");
            sbTable.Append("</th><th>");
            sbTable.Append("学分");
            sbTable.Append("</th><th>");
            sbTable.Append("考试时间");
            sbTable.Append("</th></tr>");
            sbTable.Append("</thead><tbody>");

            for (int i = 0; i < jArray.Count; i++) {
                var jObject= MySqlFunctions.string_to_jobj(jArray[i].ToString());
                List<String> list = new List<string>();
                String class_name=jObject[Table_Class.Name.class_name].ToString();
                list.Add(class_name);
                String class_id=jObject[Table_Class.Name.class_id].ToString();
                list.Add(class_id);
                String teachername=jObject[Table_Class.Name.teachername].ToString();
                list.Add(teachername);
                String test_time=jObject[Table_Class.Name.test_time].ToString();
                list.Add(test_time);
                String class_grade=jObject[Table_Class.Name.class_grade].ToString() ;
                list.Add(class_grade);
                sbTable.Append("<tr><th>");
                sbTable.Append(class_name);
                sbTable.Append("</th><th>");
                sbTable.Append(class_id);
                sbTable.Append("</th><th>");
                sbTable.Append(teachername);
                sbTable.Append("</th><th>");
                sbTable.Append(class_grade);
                sbTable.Append("</th><th>");
                sbTable.Append(test_time);
                sbTable.Append("</th></tr>");               
                show.InnerHtml = sbTable.ToString();
            }
            sbTable.Append("</tbody>");

        }
        protected void Jump_course_manage(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56740/Pages/AdminPage.aspx");
        }
        protected void Jump_head(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56740/Pages/course_manage.aspx");
        }
    }
}