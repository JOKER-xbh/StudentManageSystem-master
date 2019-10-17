using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Study : DBoperation
    {
        /*
create table work_study(
student_record varchar(20) primary key,
class_id varchar(20),
semester  varchar(10),
class_name varchar(20),  
teachername varchar(10),
student_id varchar(20),
foreign key(class_id) references work_class(class_id)
)--学习

         */
        public struct Name {
            public const string name = "work_study";
            public const string student_record = "student_record";
            public const string class_id = "class_id";
            public const string semester = "semester";
            public const string class_name = "class_name";
            public const string teachername = "teachername";
            public const string student_id = "student_id";
        };
        public string student_record { get; set; }
        public string class_id { get; set; }
        public string semester { get; set; }
        public string class_name { get; set; }
        public string teachername { get; set; }
        public string student_id { get; set; }
        public override bool Add()
        {
            if (student_record == null || student_record.Trim() == "")
            {
                error_string = "student_record不能为空";
                return false;
            }
            string sql = "insert into work_study(student_record,class_id,semester,class_name,teachername,student_id)" +
                " values('@student_record','@class_id','@semester','@class_name','@teachername','@student_id')";
            sql = sql.Replace("@student_record", student_record ?? "");
            sql = sql.Replace("@class_id", class_id ?? "");
            sql = sql.Replace("@semester", semester ?? "");
            sql = sql.Replace("@class_name", class_name ?? "");
            sql = sql.Replace("@teachername", teachername ?? "");
            sql = sql.Replace("@student_id", student_id ?? "");
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
            if (student_record == null || student_record.Trim() == "")
            {
                error_string = "student_record不能为空";
                return false;
            }
            string sql = "update work_study @change_str where student_record = '@student_record'";
            sql = sql.Replace("@change_str", change_str);
            sql = sql.Replace("@student_record", student_record);
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
            if (student_record == null || student_record.Trim() == "")
            {
                error_string = "student_record不能为空";
                return false;
            }
            string sql = "delete from work_study where student_record='@student_record'";
            sql = sql.Replace("@student_record", student_record);
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
                string sql = "select * from ";
                sql += Name.name;
                return MySql.ExecSql(sql);
            }
            else return "数据库链接失败";
        }
    }
}