using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Speciality : DBoperation
    {
        /*
         create table work_speciality(
         speciality_id varchar(20) primary key,
         speciality_name varchar(20),
         speciality_collage varchar(10),
         speciality_type varchar(20),
         degree_type varchar(20)
         )--专业
         */
        public struct Name {
            public const string name = "work_speciality";
            public const string speciality_id = "speciality_id"; 
            public const string speciality_name = "speciality_name";
            public const string speciality_collage = "speciality_collage";
            public const string speciality_type = "speciality_type";
            public const string degree_type = "degree_type";
        };
        public string speciality_id { get; set; }
        public string speciality_name { get; set; }
        public string speciality_collage { get; set; }
        public string speciality_type { get; set; }
        public string degree_type { get; set; }
        public override bool Add()
        {
            if (speciality_id == null || speciality_id.Trim() == "")
            {
                error_string = "speciality_id不能为空";
                return false;
            }
            string sql = "insert into work_speciality(speciality_id,speciality_name,speciality_collage,speciality_type,degree_type)" +
                " values('@speciality_id','@speciality_name','@speciality_collage','@speciality_type','@degree_type')";
            sql = sql.Replace("@speciality_id", speciality_id ?? "");
            sql = sql.Replace("@speciality_name", speciality_name?? "");
            sql = sql.Replace("@speciality_collage", speciality_collage ?? "");
            sql = sql.Replace("@speciality_type", speciality_type ?? "");
            sql = sql.Replace("@degree_type", degree_type ?? "");
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
            if (speciality_id == null || speciality_id.Trim() == "")
            {
                error_string = "speciality_id不能为空";
                return false;
            }
            string sql = "update work_speciality @change_str where speciality_id = '@speciality_id'";
            sql = sql.Replace("@change_str", change_str);
            sql = sql.Replace("@speciality_id", speciality_id);
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
            if (speciality_id == null || speciality_id.Trim() == "")
            {
                error_string = "speciality_id不能为空";
                return false;
            }
            string sql = "delete from work_speciality where speciality_id='@speciality_id'";
            sql = sql.Replace("@speciality_id", speciality_id);
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