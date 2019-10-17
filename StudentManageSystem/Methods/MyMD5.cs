using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace StudentManageSystem.Methods
{
    public class MyMD5
    {
        MyMD5() { }
        public static string md5(string str) {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] buffer = Encoding.Default.GetBytes(str);
            byte[] bufferStr = md5.ComputeHash(buffer);
            string md5Str = "";
            foreach (byte item in bufferStr)
            {
                md5Str += item.ToString("x2");
            }
            return md5Str;
        }
        public static string md5(byte[] buf)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bufferStr = md5.ComputeHash(buf);
            string md5Str = "";
            foreach (byte item in bufferStr)
            {
                md5Str += item.ToString("x2");
            }
            return md5Str;
        }
    }
}