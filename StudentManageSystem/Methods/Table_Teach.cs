using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Teach : DBoperation
    {
        /*
create table work_teach(
teacher_id varchar(20),
course_id varchar(20),
teach_time varchar(20),
teach_address varchar(20),
primary key(teacher_id),
foreign key(course_id) references work_course(course_id),
foreign key(teacher_id) references work_teacher(teacher_id)
)--上课
         */
        public struct Name {
            public const string name = "work_teach";
            public const string teacher_id = "teacher_id";
            public const string course_id = "course_id";
            public const string teach_time = "teach_time";
            public const string teach_address = "teach_address";
            public const string teach_qq = "teach_qq";
        }
        public string teacher_id { get; set; }
        public string course_id { get; set; }
        public string teach_time { get; set; }
        public string teach_address { get; set; }
        public string teach_qq { get; set; }
        public override bool Add()
        {
            if (teacher_id == null || teacher_id.Trim() == "")
            {
                error_string = "teacher_id不能为空";
                return false;
            }
            string sql = "insert into work_teach(teacher_id,course_id,teach_time,teach_address,teach_qq)" +
                " values('@teacher_id','@course_id','@teach_time','@teach_address','@teach_qq')";
            sql = sql.Replace("@teacher_id", teacher_id ?? "");
            sql = sql.Replace("@course_id", course_id ?? "");
            sql = sql.Replace("@teach_time", teach_time ?? "");
            sql = sql.Replace("@teach_address", teach_address ?? "");
            sql = sql.Replace("@teach_qq", teach_qq ?? "");
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
            if (teacher_id == null || teacher_id.Trim() == "")
            {
                error_string = "teacher_id不能为空";
                return false;
            }
            string sql = "update work_teach @change_str where teacher_id = '@teacher_id'";
            sql = sql.Replace("@change_str", change_str);
            sql = sql.Replace("@teacher_id", teacher_id);
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
            if (teacher_id == null || teacher_id.Trim() == "")
            {
                error_string = "teacher_id不能为空";
                return false;
            }
            string sql = "delete from work_teach where teacher_id='@teacher_id'";
            sql = sql.Replace("@teacher_id", teacher_id);
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