<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="StudentManageSystem.Pages.course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style>
         body {

            }
    .header {
     width: 1520px;
     height: 60px;
     padding-top: 45px;
      background: url("img/header.jpg") no-repeat;
     position：relative； //相对位置
    }   
              #title {
    font-size: 25px;
           }
          .welcome {
    width: 1520px;
    height: 30px;
    background-color: darkolivegreen;
    position: relative;
    text-align: center;
           }
              table, th, tr, td {
    border: 1px solid #000;
    text-align: center;
           }

        thead {
         color: brown;
              }

            tbody {
                color: blue;
           }

               tfoot {
             color: green;
             }
        .新建样式1 {
            table-layout: auto;
            border-collapse: collapse;
            empty-cells: inherit;
            caption-side: inherit;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <div class="header">
        <img src="img/new_logo2.png" 0px 100px />
               </div>
        <div class="welcome"><span id="title" style="text-align:center;display:block;">欢迎进入学生成绩管理系统</span></div>
        <div style="width:1520px">
            <div style="float:left;width:300px;height: 800px;background-color:blanchedalmond;text-align: center;">
                <button style="background-color:deepskyblue;width:120px;color:white;border:none;box-shadow:-1px -2px -2px 0 #615959;border-radius:3px;font-size:23px;">个人中心</button>
                <br />
                <button style="background-color:deepskyblue;width:120px;color:white;border:none;box-shadow:-1px -2px -2px 0 #615959;border-radius:3px;font-size:23px;">我的信息</button>
                <br />
                <button style="background-color:deepskyblue;width:120px;color:white;border:none;box-shadow:-1px -2px -2px 0 #615959;border-radius:3px;font-size:23px;">修改密码</button>
                <br />
                <button style="background-color:deepskyblue;width:120px;color:white;border:none;box-shadow:-1px -2px -2px 0 #615959;border-radius:3px;font-size:23px;">课程管理</button>
                <br />
                <button style="background-color:deepskyblue;width:120px;color:white;border:none;box-shadow:-1px -2px -2px 0 #615959;border-radius:3px;font-size:23px;">学生管理</button>
                <br />
                <button style="background-color:deepskyblue;width:120px;color:white;border:none;box-shadow:-1px -2px -2px 0 #615959;border-radius:3px;font-size:23px;">教师管理</button>
                <br />
            </div>
            <div style="float:left;width:1220px;height: 800px;background-color:aquamarine;">
                
                <asp:Button ID="Button1" runat="server" Onclick="Jump_head" Text="首页"/>
                <asp:Button ID="Button2" runat="server" Onclick="Jump_course_manage" Text="添加新课程"/>
                <br/>
                <asp:Button ID="Button3" runat="server" Onclick="Search" Text="更新"/>  
                <div id="show" runat="server">


                </div>
                
                          
            </div>
    </div>
    </form>
</body>
</html>
