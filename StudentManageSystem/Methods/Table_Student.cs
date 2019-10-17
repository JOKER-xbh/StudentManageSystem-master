using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Student : DBoperation
    {
        /*
create table work_student(
student_id varchar(20) primary key,
student_name varchar(10),
student_gender varchar(2),
student_age int(3),
student_height int(5),
student_source varchar(20),
student_weight int(5),
student_contact varchar(12),
student_password varchar(32),密码
student_place varchar(20),
student_status varchar(5),
course_id varchar(10),
foreign key(course_id) references work_course(course_id)
);--学生
         */
        public struct Name {
            public const string name = "work_student";
            public const string student_id = "student_id";
            public const string student_name = "student_name";
            public const string student_gender = "student_gender";
            public const string student_age = "student_age";
            public const string student_height = "student_height";
            public const string student_source = "student_source";
            public const string student_weight = "student_weight";
            public const string student_contact = "student_contact";
            public const string student_password = "student_password";
            public const string student_place = "student_place";
            public const string student_status = "student_status";
            public const string course_id = "course_id";
        }
        public string student_id { get;set;}
        public string student_name { get; set; }
        public string student_gender { get; set; }
        public string student_age { get; set; }
        public string student_height { get; set; }
        public string student_source { get; set; }
        public string student_weight { get; set; }
        public string student_contact { get; set; }
        public string student_password { get; set; }
        public string student_place { get; set; }
        public string student_status { get; set; }
        public string course_id { get; set; }
        public override bool Add()
        {
            if (student_id == null || student_id.Trim() == "")
            {
                error_string = "student_id不能为空";
                return false;
            }
            string sql = "insert into work_student(student_id,student_name,student_gender,student_age,student_height,student_source,student_weight,student_contact,student_password,student_place,student_status,course_id)" +
                " values('@student_id','@student_name','@student_gender',@student_age,@student_height,'@student_source',@student_weight,'@student_contact','@student_password','@student_place','@student_status','@course_id')";
            sql = sql.Replace("@student_id", student_id ?? "");
            sql = sql.Replace("@student_name", student_name ?? "");
            sql = sql.Replace("@student_gender", student_gender ?? "");
            sql = sql.Replace("@student_age", student_age ?? "0");
            sql = sql.Replace("@student_height", student_height ?? "0");
            sql = sql.Replace("@student_source", student_source ?? "");
            sql = sql.Replace("@student_weight", student_weight ?? "0");
            sql = sql.Replace("@student_contact", student_contact ?? "");
            sql = sql.Replace("@student_password", student_password ?? "");
            sql = sql.Replace("@student_place", student_place ?? "");
            sql = sql.Replace("@student_status", student_status ?? "");
            sql = sql.Replace("@course_id", course_id ?? "");
            string re_str = MySql.ExecSql(sql);
            if (re_str == "[{ }]") return true;
            else
            {
                error_string = re_str;
                return false;
            }
        }

        public override bool Change()
        {
            if (student_id == null || student_id.Trim() == "")
            {
                error_string = "student_id不能为空";
                return false;
            }
            string sql = "update work_student @change_str where student_id = '@student_id'";
            sql = sql.Replace("@change_str", change_str);
            sql = sql.Replace("@student_id", student_id);
            string re_str = MySql.ExecSql(sql);
            if (re_str == "[{ }]") return true;
            else
            {
                error_string = re_str;
                return false;
            }
        }

        public override bool Delete()
        {
            if (student_id == null || student_id.Trim() == "")
            {
                error_string = "student_id不能为空";
                return false;
            }
            string sql = "delete from work_student where student_id='@student_id'";
            sql = sql.Replace("@student_id", student_id);
            string re_str = MySql.ExecSql(sql);
            if (re_str == "[{ }]") return true;
            else
            {
                error_string = re_str;
                return false;
            }
        }

        public override string Inquire()
        {
            if (MySql.isconnected)
            {
                string sql = "select * from ";
                sql += Name.name;
                return MySql.ExecSql(sql);
            }
            else return "数据库链接失败";
        }

        public override string Inquire(string parm1, string parm2)
        {
            if (MySql.isconnected)
            {
                string sql = "select " + parm1 + " from ";
                sql += Name.name + " " + parm2;
                return MySql.ExecSql(sql);
            }
            else return "数据库链接失败";
        }
    }
}