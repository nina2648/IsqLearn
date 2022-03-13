<%@ Page Language="C#" AutoEventWireup="true" CodeFile="password.aspx.cs" Inherits="password" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的帳號</title>
    <link rel="stylesheet" href="css/profile.css"/>

<meta http-equiv="Content-Type" content="width=device-width, initial-scale=1.0"; charset="UTF-8"/>
</head>


<body style="font-family:'Microsoft JhengHei',Arial;">
    <form id="form1" runat="server">
  <!--頂端-->
        <header id="header">
            <div class="banner">
                 <nav id="btnpage">
                <ul>
                    <li id="btnexit" style="border-right:0px;"><a href="Login.aspx">登出</a></li>
                </ul>
            </nav>
            </div>
        </header>

        <main>
            <!--登入顯示區域-->
            <div id="profile">
            <div id="title">修改密碼</div>
            <div id="pic"></div>
            <div id="account" aria-atomic="True">
             <div class="login">
                        <label for="fname">目前密碼:</label>
                         <asp:TextBox id="pass" CssClass="pass" runat="server"></asp:TextBox><br/><br/>
                        <label for="lname">新密碼:</label>
                       <asp:TextBox id="pwd1" CssClass="pwd1"  runat="server" TextMode="Password"></asp:TextBox><br/><br/>
                        <label for="lname">確認新密碼:</label>
                       <asp:TextBox id="pwd2" CssClass="pwd2" runat="server" TextMode="Password"></asp:TextBox><br/><br/>

                    </div>
            <asp:Button class="button" id="button" runat="server" Text="變更密碼" OnClick="Button1_Click" Height="26px" Width="80px" CssClass="button" />

                


            </div>
                </div>
      </main>
    
    </form>
    
</body>
</html>