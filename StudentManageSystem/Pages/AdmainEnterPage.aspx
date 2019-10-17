<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmainEnterPage.aspx.cs" Inherits="StudentManageSystem.Pages.log_in" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>湖北大学学籍管理系统</title>
    <style type="text/css">
        html, body {
            margin: 0 0 0 0;
            padding: 0;
        }

        .header{ //头部
            width:1520px;
            height: 60px;
            padding-top: 45px;
            background: url("img/header.jpg") no-repeat;
            position：relative； //相对位置
        }

        h1 {
            font-size: 30px;
            color: burlywood;
        }

        .background {//下方背景
            width: 1520px;
            height: 580px;
            background-color: darkolivegreen;
            position: relative;
            text-align: center;
        }

        .background2 {//登陆背景
            width: 1520px;
            height: 500px;
            background: url("img/backgorund2.jpg") no-repeat 500px 0px;
            position：relative； //相对位置
        }

        #class {
            font-size: 25px;
        }
        #class2{
            font-size: 25px;
        }

        #Button1 {
            background-color: deepskyblue;
            width: 120px;
            color: white;
            border: none;
            box-shadow: -1px -2px -2px 0 #615959;
            border-radius: 3px;
            font-size: 23px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
        <h1>湖北大学学生成绩管理系统</h1>
    </div>
    <div class="background">
        <div class="background2">
            <span id="class">管理员登陆</span>
            <pre>
            <br />
           <span id="class2">用户名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        密码：<asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox></span>
            <br />
            <asp:Button ID="Button1" runat="server" Onclick="Button1_Click" Text="登录"/>
            </pre>
        </div>

    </div>
    <pre>    
                                                      版权所有：湖北大学吴彦祖</pre>  
    </form>
</body>
</html>