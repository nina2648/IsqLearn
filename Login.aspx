<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>登入</title>
    <link rel="stylesheet" href="css/login.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    </head>


<body style="font-family: Microsoft JhengHei,Arial;">
    <form id="form1" runat="server">
  <!--頂端-->
        <header id="header">
            <div class="banner">
            </div>
        </header>

        <main id="main">
            <!--登入顯示區域-->
            <div class="loginmain">
                <!--Logo-->
                <div class="loginlogo">
                        <!-- <img src="images/logo.jpg">-->
                </div>
                <!--帳號密碼輸入區-->
                <div class="loginmsg">
                    <div class="logintitle">使用者登入</div>
                    <div class="login">
                        <label for="fname">帳號:</label>
                         <asp:TextBox id="user" runat="server"></asp:TextBox><br/><br/>
                        <label for="lname">密碼:</label>
                       <asp:TextBox id="pass"  runat="server" TextMode="Password"></asp:TextBox><br/><br/>
                        <div class="btn">
                            <asp:Button  ID="Button1" runat="server" OnClick="Button1_Click" Text="學生登入" name="TextBox1" Height="34px" Width="75px" />&nbsp;
                            <asp:Button  ID="Button2" runat="server" OnClick="Button2_Click" Text="教師登入" name="TextBox2" Height="34px" Width="75px" />&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Labe1"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </main>    
    </form>    
</body>
</html>