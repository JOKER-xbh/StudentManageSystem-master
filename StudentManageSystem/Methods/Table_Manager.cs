using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Manager : DBoperation
    {
        /*
create table work_manager(
manager_id varchar(10) primary key,
manager_password varchar(32)
)
         */
        public struct Name {
            public const string name = "work_manager";
            public const string manager_id = "manager_id";
            public const string manager_password = "manager_password";
        }
        public string manager_id { get; set; }
        public string manager_password { get; set; }
        public override bool Add()
        {
            if (manager_id == null || manager_id.Trim() == "")
            {
                error_string = "manager_id不能为空";
                return false;
            }
            string sql = "insert into work_manager(manager_id,manager_password)" +
                " values('@manager_id','@manager_password')";
            sql = sql.Replace("@manager_id", manager_id ?? "");
            sql = sql.Replace("@manager_password", manager_password ?? "");
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
            if (manager_id == null || manager_id.Trim() == "")
            {
                error_string = "manager_id不能为空";
                return false;
            }
            string sql = "update work_manager @change_str where manager_id = '@manager_id'";
            sql = sql.Replace("@change_str", change_str);
            sql = sql.Replace("@manager_id", manager_id);
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
            if (manager_id == null || manager_id.Trim() == "")
            {
                error_string = "manager_id不能为空";
                return false;
            }
            string sql = "delete from work_manager where manager_id='@manager_id'";
            sql = sql.Replace("@manager_id", manager_id);
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