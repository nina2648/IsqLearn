<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的帳號</title>
    <link rel="stylesheet" href="css/profile.css" type="text/css"/>
<meta http-equiv="Content-Type" content="width=device-width, initial-scale=1.0"; charset="UTF-8"/>
</head>


<body style="font-family:'Microsoft JhengHei',Arial;">
    <form id="form1" runat="server">
  <!--頂端-->
        <header id="header">
            <div class="banner">
                 <nav id="btnpage">
                <ul>
                    <li id="btnclasslist"><a href="CourselistStudent.aspx">課堂列表</a></li>
                    <li id="btnpie"><a href="stuChart.aspx">弱點分析</a></li>
                    <li id="btnaccount"><a href="Account.aspx">我的帳號</a></li>
                    <li id="btnexit" style="border-right:0px;"><a href="Login.aspx">登出</a></li>
                </ul>
            </nav>
            </div>
        </header>

        <main>
            <!--登入顯示區域-->
            <div id="profile">
            <div id="title">我的帳號</div>
            <div id="pic"></div>
            <div id="account" aria-atomic="True">
                <ul class="nav">
                    <li>
                        <div>姓名 <b style="font-size:20px;"></b> : </div>
                        <div id="name" style="margin-left:5px;">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                    <li>
                        <div>學校 <b style="font-size:20px;"></b> : </div>
                        <div id="School" style="margin-left:5px;">
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </div>
                    </li>
                    <li>
                        <div>學號 <b style="font-size:20px;"></b> : </div>
                        <div id="stunum" style="margin-left:5px;">
                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label></div>
                    </li>

                </ul>
                <asp:Button class="button" id="button" runat="server" Text="修改密碼" OnClick="Button1_Click" Height="35px" Width="120px" CssClass="button" />
            </div>
            </div>
      </main>
    
    </form>
    
</body>
</html>