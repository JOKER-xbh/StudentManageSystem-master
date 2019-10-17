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
    public partial class course_manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Personal(object sender, EventArgs e)
        {

        }
        protected void Persona2(object sender, EventArgs e)
        {

        }
        protected void Change_password(object sender, EventArgs e)
        {

        }
        protected void Course_manage(object sender, EventArgs e)
        {

        }
        protected void Student_manage(object sender, EventArgs e)
        {

        }
        protected void Teachers_Manage(object sender, EventArgs e)
        {
        }
        protected void Upload(object sender, EventArgs e)
        {
            
        }
        protected void Refer(object sender, EventArgs e)
        {
            Table_Class new_class = new Table_Class
            {
                class_id = class_id.Text,
                class_grade = class_grade.Text,
                class_name = class_name.Text,
                class_number = class_number.Text,
                class_place = class_place.Text,
                class_record = class_record.Text,
                class_time = class_time.Text,
                class_type = class_type.Text,
                final_grade = final_grade.Text,
                semester = semester.Text,
                student_id = student_id.Text,
                teachername = teachername.Text,
                test_time = test_time.Text,
                usual_performance = usual_performance.Text
            };
            bool final=new_class.Add();
            if(final)
            {
                Response.Write("上传成功");
            }
            else
            {
                Response.Write("上传失败，请重试");
            }
            Upload upload = new Upload(FileUpload7, Server);
            String file_name = upload.UploadFile();
            Response.Write("//");
        }
    }
}