using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Give_lessions : DBoperation
    {
        /*
create table work_give_lessions(
teacher_id varchar(20) primary key,
class_id varchar(20),
foreign key(class_id) references work_class(class_id)
)--授课
         */
         public struct Name
        {
            public const string name = "work_give_lessions";
            public const string teacher_id = "teacher_id";
            public const string class_id = "class_id";
        };
        public string teacher_id { get; set; }
        public string class_id { get; set; }
        public override bool Add()
        {
            if (teacher_id == null || teacher_id.Trim() == "")
            {
                error_string = "teacher_id不能为空";
                return false;
            }
            string sql = "insert into work_give_lessions(teacher_id,class_id)" +
                " values('@teacher_id','@class_id')";
            sql = sql.Replace("@teacher_id", teacher_id ?? "");
            sql = sql.Replace("@class_id", class_id ?? "");
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
            string sql = "update work_give_lessions @change_str where teacher_id = '@teacher_id'";
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
            string sql = "delete from work_give_lessions where teacher_id='@teacher_id'";
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
                string sql = "select * from ";
                sql += Name.name;
                return MySql.ExecSql(sql);
            }
            else return "数据库链接失败";
        }
    }
}