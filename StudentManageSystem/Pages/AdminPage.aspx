<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="StudentManageSystem.Pages.course_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style>
        body {
        }
.header {
    width: 1520px;
    height: 200px;
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
.file {
    position: relative;
    display: inline-block;
    background: #D0EEFF;
    border: 1px solid #99D3F5;
    border-radius: 4px;
    padding: 4px 12px;
    overflow: hidden;
    color: #1E88C7;
    text-decoration: none;
    text-indent: 0;
    line-height: 20px;
}

    .file input {
        position: absolute;
        font-size: 100px;
        right: 0;
        top: 0;
        opacity: 0;
    }

    .file:hover {
        background: #AADFFD;
        border-color: #78C3F3;
        color: #004974;
        text-decoration: none;
    }
    #Button1,#Button2,#Button3,#Button4,#Button5,#Button6,#Button7{
        background-color:deepskyblue;width:120px;color:white;border:none;box-shadow:-1px -2px -2px 0 #615959;border-radius:3px;font-size:23px;

    }
    #TextBox1,#TextBox2,#TextBox3,#TextBox4,#TextBox5,#TextBox6,#TextBox7,#TextBox8,#TextBox9,#TextBox10,
    #TextBox11,#TextBox12,#TextBox13,#TextBox14{
        border-color:black;
        background-color:antiquewhite;
        width: 106px; 
        height: 21px;

    }
    #FileUpload7{
        border-color:black;
        background-color:burlywood;
        width:160px;
        height:29px;
    }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <div class="header">
        <img src="img/new_logo2.png" 0px 100px />
        <div class="welcome"><span id="title" style="text-align:center;display:block;">欢迎进入学生成绩管理系统</span></div>
        <div style="widht:500px">
            <div style="float:left;width:300px;height: 1200px;background-color:blanchedalmond;text-align: center;">
                <div style="margin:10px 0 0 50px"></div>
                <asp:Button ID="Button1" runat="server" Onclick="Personal" Text="个人中心"/>
                <asp:Button ID="Button2" runat="server" Onclick="Persona2" Text="我的信息"/>
                <asp:Button ID="Button3" runat="server" Onclick="Change_password" Text="修改密码"/>
                <asp:Button ID="Button4" runat="server" Onclick="Course_manage" Text="课程管理"/>
                <asp:Button ID="Button5" runat="server" Onclick="Student_manage" Text="学生管理"/>
                <asp:Button ID="Button6" runat="server" Onclick="Teachers_Manage" Text="教师管理"/>
                </div>
            </div>
            <div style="float:left;width:1220px;height: 1200px;background-color:aquamarine;">
                <div style="width:800px;height:600px;border:3px solid black;margin:50px 0 0 200px;">
                    <div style="margin:10px 0 0 50px">
                课程记录： <asp:TextBox ID="class_record" runat="server"></asp:TextBox> </div>                
                    <div style="margin:10px 0 0 50px">
                学号：<asp:TextBox ID="student_id" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                课程号：<asp:TextBox ID="class_id" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                学期：<asp:TextBox ID="semester" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                课程名：<asp:TextBox ID="class_name" runat="server"></asp:TextBox></div>                  
                    <div style="margin:10px 0 0 50px">
                教师名：<asp:TextBox ID="teachername" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                平时成绩：<asp:TextBox ID="usual_performance" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                期末成绩：<asp:TextBox ID="final_grade" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                学时：<asp:TextBox ID="class_time" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                考试时间：<asp:TextBox ID="test_time" runat="server"></asp:TextBox></div>
                     <div style="margin:10px 0 0 50px">
                上课地点：<asp:TextBox ID="class_place" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                学分：<asp:TextBox ID="class_grade" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                课程人数：<asp:TextBox ID="class_number" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                课程类型：<asp:TextBox ID="class_type" runat="server"></asp:TextBox></div>
                    <div style="margin:10px 0 0 50px">
                    <asp:FileUpload ID="FileUpload7" runat="server"/></div>
                    <div style="margin:10px 0 0 50px"> 
                        <asp:Button ID="Button7" runat="server" Onclick="Refer" Text="提交"/>
                    </div>
               </div>
                </div>                   
                </div>      
    </form>
</body>
</html>
