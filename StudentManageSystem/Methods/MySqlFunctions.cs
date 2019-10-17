using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace StudentManageSystem.Methods
{
    public class MySqlFunctions
    {
        private MySqlConnection sqlConnection = null;
        private MySqlCommand sqlCmd=null;
        private MySqlDataReader dataReader = null;
        public bool isconnected = false;
        public MySqlFunctions()
        {
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            try
            {
                sqlConnection = new MySqlConnection(str);
                sqlConnection.Open();
                
            }
            catch (Exception e)
            {
                return;
            }
            isconnected = true;
        }
        public bool SqlClose() {
            if (isconnected) {
                sqlConnection.Close();
                isconnected = false;
                return true;
            }
            return false;
        }
        private MySqlDataReader sqlRead(string sql_str) {
            
            sqlCmd= new MySqlCommand(sql_str,sqlConnection);
            try
            {
                dataReader=sqlCmd.ExecuteReader();
                //dataReader.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return dataReader;
        }
        private string DataReaderToJson(MySqlDataReader dataReader)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            if (!dataReader.Read()) return "[{ }]";
            else {
                do
                {
                    jsonString.Append("{");
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        Type type = dataReader.GetFieldType(i);
                        string strKey = dataReader.GetName(i);
                        string strValue = dataReader[i].ToString();
                        jsonString.Append("\"" + strKey + "\":");
                        strValue = String.Format(strValue, type);
                        //datetime不能出现为空的情况,所以将其转换成字符串来进行处理。
                        //需要加""的
                        if (type == typeof(string) || type == typeof(DateTime))
                        {
                            if (i <= dataReader.FieldCount - 1)
                            {

                                jsonString.Append("\"" + strValue + "\",");
                            }
                            else
                            {
                                jsonString.Append(strValue);
                            }
                        }
                        //不需要加""的
                        else
                        {
                            if (i <= dataReader.FieldCount - 1)
                            {
                                jsonString.Append("" + strValue + ",");
                            }
                            else
                            {
                                jsonString.Append(strValue);
                            }
                        }
                    }

                    jsonString.Append("},");
                } while (dataReader.Read());
            }
 
            dataReader.Close();
            jsonString.Remove(jsonString.Length - 3, 3);
            jsonString.Append("}");
            jsonString.Append("]");
            return jsonString.ToString();
        }
        public string ExecSql(string sql_string) {
            dataReader = sqlRead(sql_string);
            if (dataReader != null) {
                string temp_str;
                temp_str=DataReaderToJson(dataReader);
                dataReader.Close();
                return temp_str;
            }
            else return "sql出错";
        }
        public bool SqlTransaction(string[] str) {
            MySqlCommand[] mySqlCommands=new MySqlCommand[str.Count()];
            for (int i = 0; i < str.Count(); i++) {
                mySqlCommands[i] = new MySqlCommand(str[i], sqlConnection);
            }
            
            MySqlTransaction transaction = sqlConnection.BeginTransaction();
            try
            {
                for (int i = 0; i < str.Count(); i++)
                {
                    mySqlCommands[i].ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
            return true;

        }
        public static JArray string_to_array(string str) {
            JArray jArray=null;
            try
            {
                jArray=JArray.Parse(str);
            }
            catch (Exception e) {
                return null;
            }
            return jArray;
        }
        public static JObject string_to_jobj(string str) {
            JObject jObject = null;
            try
            {
                jObject = (JObject)JsonConvert.DeserializeObject(str);
            }
            catch (Exception e) {
                return null;
            }
            return jObject;
        }

    }

}