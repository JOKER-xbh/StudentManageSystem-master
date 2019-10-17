using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace StudentManageSystem.Methods
{
    public class Upload
    {
        private FileUpload fileUpload;
        private HttpServerUtility server;
        public Upload(FileUpload fu,HttpServerUtility httpServerUtility) { fileUpload = fu; server = httpServerUtility; }
        public string UploadFile() {
            if (fileUpload.HasFile)
            {
                string filename = MyMD5.md5(fileUpload.FileBytes);
                string fileext = System.IO.Path.GetExtension(fileUpload.FileName);
                string filenamaes = filename + fileext;
                fileUpload.SaveAs(server.MapPath("/") + "//Images//" + filenamaes);
                return filenamaes;
            }
            else {
                return "请选择文件";
            }
        }
    }
}