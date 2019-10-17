using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Teacher:DBoperation
    {
        /*
create table work_teacher(
teacher_id varchar(20) primary key,
teacher_name varchar(20),
teacher_sex varchar(2),
teacher_age varchar(8),
technical_title varchar(10),
telephone varchar(12),
email varchar(20)，
teacher_password varchar(32)
)--老师
       */
        public struct Name
        {
            public const string name = "work_teacher";
            public const string teacher_id = "teacher_id";
            public const string teacher_name = "teacher_name";
            public const string teacher_sex = "teacher_sex";
            public const string teacher_age = "teacher_age";
            public const string technical_title = "technical_title";
            public const string telephone = "telephone";
            public const string email = "email";
            public const string teacher_password = "teacher_password";
        };
        public string teacher_id { get;set; }
        public string teacher_name { get; set; }
        public string teacher_sex { get; set; }
        public string teacher_age { get; set; }
        public string technical_title { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public string teacher_password { get; set; }
        public override string Inquire() {
            if (MySql.isconnected)
            {
                string sql = "select * from ";
                sql += Name.name;
                return MySql.ExecSql(sql);
            }
            else return "数据库链接失败";
        }

        public override bool Add()
        {
            if (teacher_id == null || teacher_id.Trim()=="") {
                error_string = "teacher_id不能为空";
                return false;
            }
            string sql = "insert into work_teacher(teacher_id,teacher_name,teacher_sex,teacher_age,technical_title,telephone,email)" +
                " values('@teacher_id','@teacher_name','@teacher_sex','@teacher_age','@technical_title',@telephone,'@email')";
            sql=sql.Replace("@teacher_id", teacher_id ?? "");
            sql=sql.Replace("@teacher_name", teacher_name??"");
            sql=sql.Replace("@teacher_sex", teacher_sex??"");
            sql = sql.Replace("@teacher_age", teacher_age??"");
            sql = sql.Replace("@technical_title", technical_title??"");
            sql = sql.Replace("@telephone", telephone??"");
            sql = sql.Replace("@email", email??"");
            string re_str = MySql.ExecSql(sql);
            if (re_str == "[{ }]") return true;
            else {
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
            string sql = "delete from work_teacher where teacher_id='@teacher_id'";
            sql = sql.Replace("@teacher_id", teacher_id);
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
            string sql = "update work_teacher @change_str where teacher_id = '@teacher_id'";
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

        public override string Inquire(string parm1, string parm2)
        {
            if (MySql.isconnected)
            {
                string sql = "select " + parm1+" from ";
            sql += Name.name+" "+parm2;
            return MySql.ExecSql(sql);
        }
            else return "数据库链接失败";
        }
    }
}