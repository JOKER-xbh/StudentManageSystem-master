using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Textbook : DBoperation
    {
        /*
create table work_textbook(
book_id varchar(20) primary key,
book_name varchar(20),
book_type varchar(10),
publication_time varchar(10),
author varchar(10),
class_id varchar(20),
foreign key(class_id) references work_class(class_id)
)--课本
         */
        public struct Name {
            public const string name= "work_textbook";
            public const string book_id = "book_id";
            public const string book_name = "book_name";
            public const string book_type = "book_type";
            public const string publication_time = "publication_time";
            public const string author = "author";
            public const string class_id = "class_id";
        };
        public string book_id { get; set; }
        public string book_name { get; set; }
        public string book_type { get; set; }
        public string publication_time { get; set; }
        public string author { get; set; }
        public string class_id { get; set; }

        public override bool Add()
        {
            if (book_id == null || book_id.Trim() == "")
            {
                error_string = "book_id不能为空";
                return false;
            }
            string sql = "insert into work_textbook(book_id,book_name,book_type,publication_time,author,class_id )" +
                " values('@book_id','@book_name','@book_type','@publication_time','@author','@class_id')";
            sql = sql.Replace("@book_id", book_id ?? "");
            sql = sql.Replace("@book_name", book_name ?? "");
            sql = sql.Replace("@book_type", book_type ?? "");
            sql = sql.Replace("@publication_time", publication_time ?? "");
            sql = sql.Replace("@author", author ?? "");
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
            if (book_id == null || book_id.Trim() == "")
            {
                error_string = "book_id不能为空";
                return false;
            }
            string sql = "update work_textbook @change_str where book_id = '@book_id'";
            sql = sql.Replace("@change_str", change_str);
            sql = sql.Replace("@book_id", book_id);
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
            if (book_id == null || book_id.Trim() == "")
            {
                error_string = "book_id不能为空";
                return false;
            }
            string sql = "delete from work_textbook where book_id='@book_id'";
            sql = sql.Replace("@book_id", book_id);
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