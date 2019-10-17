using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManageSystem.Methods
{
    public abstract class DBoperation
    {
        public MySqlFunctions MySql;
        public DBoperation() {
            MySql = new MySqlFunctions();
        }
        public string change_str;
        public string error_string;
        public abstract bool Add();
        public abstract bool Delete();
        public abstract string Inquire();
        public abstract string Inquire(string parm1, string parm2);
        public abstract bool Change();
        ~DBoperation() {
            MySql.SqlClose();
        }
    }
}