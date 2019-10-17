using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Course : DBoperation
    {
        /*
create table work_course(
course_id varchar(20) primary key,
course_name varchar(10),
speciality_id varchar(20),
course_teacher_name varchar(10),
course_number varchar(4),
teacher_id varchar(20),
foreign key(speciality_id) references work_speciality(speciality_id),
foreign key(teacher_id) references work_teacher(teacher_id)
)--班级
         */
        public struct Name {
            public const string name = "work_course";
            public const string course_id = "course_id";
            public const string course_name = "course_name";
            public const string speciality_id = "speciality_id";
            public const string course_teacher_name = "course_teacher_name";
            public const string course_number = "course_number";
            public const string teacher_id = "teacher_id";
        };

        public string course_id { get; set; }
        public string course_name { get; set; }
        public string speciality_id { get; set; }
        public string course_teacher_name { get; set; }
        public string course_number { get; set; }
        public string teacher_id { get; set; }
        public override bool Add()
        {
            if (course_id == null || course_id.Trim() == "")
            {
                error_string = "course_id不能为空";
                return false;
            }
            string sql = "insert into work_course(course_id ,course_name,speciality_id,course_teacher_name,course_number,teacher_id)" +
                " values('@course_id','@course_name','@speciality_id','@course_teacher_name','@course_number','@teacher_id')";
            sql = sql.Replace("@course_id", course_id ?? "");
            sql = sql.Replace("@course_name", course_name ?? "");
            sql = sql.Replace("@speciality_id", speciality_id ?? "");
            sql = sql.Replace("@course_teacher_name", course_teacher_name ?? "");
            sql = sql.Replace("@course_number", course_number ?? "");
            sql = sql.Replace("@teacher_id", teacher_id ?? "");
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
            if (course_id == null || course_id.Trim() == "")
            {
                error_string = "speciality_id不能为空";
                return false;
            }
            string sql = "update work_course @change_str where course_id = '@course_id'";
            sql = sql.Replace("@change_str", change_str);
            sql = sql.Replace("@course_id", course_id);
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
            if (course_id == null || course_id.Trim() == "")
            {
                error_string = "speciality_id不能为空";
                return false;
            }
            string sql = "delete from work_course where speciality_id='@course_id'";
            sql = sql.Replace("@course_id", course_id);
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