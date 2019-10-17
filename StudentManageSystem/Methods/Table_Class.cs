using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public class Table_Class : DBoperation
    {
        /*
create table work_class(
student_id varchar(20),
class_record varchar(20) primary key,
class_id varchar(20),
semester  varchar(10),
class_name varchar(20),
teachername varchar(10),
usual_performance int(5),
final_grade int(5),
class_time varchar(10),
test_time varchar(10),  
class_place varchar(10), 
class_grade varchar(10),
class_number varchar(10),
class_type varchar(10)，
foreign key(student_id) references work_student(student_id)
)--课程
         */
        public struct Name {
            public const string name = "work_class";
            public const string class_record = "class_record";
            public const string student_id = "student_id ";
            public const string class_id = "class_id";
            public const string semester = "semester";
            public const string class_name = "class_name";
            public const string teachername = "teachername";
            public const string usual_performance = "usual_performance";
            public const string final_grade = "final_grade";
            public const string class_time = "class_time";
            public const string test_time = "test_time";
            public const string class_place = "class_place";
            public const string class_grade = "class_grade";
            public const string class_number = "class_number";
            public const string class_type = "class_type";
        };
        public string class_record { get; set; }
        public string student_id { get; set; }
        public string class_id { get; set; }
        public string semester { get; set; }
        public string class_name { get; set; }
        public string teachername { get; set; }
        public string usual_performance { get; set; }
        public string final_grade { get; set; }
        public string class_time { get; set; }
        public string test_time { get; set; }
        public string class_place { get; set; }
        public string class_grade { get; set; }
        public string class_number { get; set; }
        public string class_type { get; set; }
        public override bool Add()
        {
            if (class_record == null || class_record.Trim() == "")
            {
                error_string = "class_record不能为空";
                return false;
            }
            string sql = "insert into work_class(class_record,student_id,class_id,semester,class_name,teachername,usual_performance,final_grade,class_time,test_time,class_place,class_grade,class_number,class_type)" +
                " values('@class_record','@student_id','@class_id','@semester','@class_name','@teachername',@usual_performance,@final_grade,'@class_time','@test_time','@class_place','@class_grade','@class_number','@class_type')";
            sql = sql.Replace("@class_record", class_record ?? "");
            sql = sql.Replace("@student_id", student_id ?? "");
            sql = sql.Replace("@class_id", class_id ?? "");
            sql = sql.Replace("@semester", semester ?? "");
            sql = sql.Replace("@class_name", class_name ?? "");
            sql = sql.Replace("@teachername", teachername ?? "");
            sql = sql.Replace("@usual_performance", usual_performance ?? "0");
            sql = sql.Replace("@final_grade", final_grade ?? "0");
            sql = sql.Replace("@class_time", class_time ?? "");
            sql = sql.Replace("@test_time", test_time ?? "");
            sql = sql.Replace("@class_place", class_place ?? "");
            sql = sql.Replace("@class_grade", class_grade ?? "");
            sql = sql.Replace("@class_number", class_number ?? "");
            sql = sql.Replace("@class_type", class_type ?? "");
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
            if (class_record == null || class_record.Trim() == "")
            {
                error_string = "class_record不能为空";
                return false;
            }
            string sql = "update work_class @change_str where class_record = '@class_record'";
            sql = sql.Replace("@change_str", change_str);
            sql = sql.Replace("@class_record", class_record);
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
            if (class_record == null || class_record.Trim() == "")
            {
                error_string = "class_record不能为空";
                return false;
            }
            string sql = "delete from work_class where class_record='@class_record'";
            sql = sql.Replace("@class_record", class_record);
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