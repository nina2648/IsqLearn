<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourselistStudent.aspx.cs" Inherits="Courselist" %>

<!DOCTYPE html>

<html lang="BIG-5">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>課程列表</title>
    <link rel="stylesheet" href="css/classlist.css">
</head>
<body style="font-family: Microsoft JhengHei,Arial;">
    <form id="form1" runat="server">
     
        
    <!--頂端-->
    <header id="header">
          <div class="banner">
            <div class="userbtn">
                <div class="usermsg">
                    <div class="userlogo"></div>
                    <div class="username"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></div>
                </div>
                <!--切換頁面按鈕-->
                <div class="btns">
                    <nav id="btnpage">
                        <ul>
                            <li id="btnclasslist"><a href="CourselistStudent.aspx">課堂列表</a></li>
                            <li id="btnpie"><a href="stuChart.aspx">弱點分析</a></li>
                            <li id="btnaccount"><a href="Account.aspx">我的帳號</a></li>
                            <li id="btnexit" style="border-right:0px;"><a href="Login.aspx">登出</a></li>
                            <asp:Label ID="Label1" runat="server" Text="" Visible="False"></asp:Label>
                        </ul>
                    </nav>
                </div>
            </div>
        </div>
            
    </header>

    <main id="main">
        <!--課堂列表顯示區域-->
        <div class="classmain">
            <div class="classlist">
               <asp:Label ID="title" CssClass="title" runat="server" Text="當日課程"></asp:Label>
                <div>
                    <div>    
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                 
                    <div class="list" style=" background-color:#DDDBD5; border-radius:7px;  ">
                        <div  style=" background-color:#DDDBD5; border-left-style:hidden ;border-radius:0px;border-bottom: solid white 5px; height:auto; ">
                            <div id="con1" runat="server"><img src="../images/onclass.png" style="float:left; padding:6px; padding-bottom:9px;border-style:hidden;  width:10%;  height:auto;"    /></div>
                            <asp:Button ID="Button1" runat="server" style="padding-left:22px; border:none; text-align:left; font-size:40px; font-weight:bold; background-color:#DDDBD5; width:88%; "   OnClick="Button1_Click"  /><br>
                            <asp:Button ID="Button8" runat="server" style="padding-left:24px; border:none; text-align:left; font-size:25px; background-color:#DDDBD5; width:88%; "   OnClick="Button1_Click" />
                        </div>
                        <div style=" background-color:#DDDBD5; border-left-style:hidden; border-radius:0px; border-bottom: solid white 5px; height:auto; ">
                            <div id="con2" runat="server"><img src="../images/onclass.png" style=" float:left; padding:6px; padding-bottom:9px;border-style:hidden;  width:10%;  height:auto;"    /></div>
                            <asp:Button ID="Button2" runat="server" style="padding-left:22px; border:none; text-align:left; font-size:40px; font-weight:bold; background-color:#DDDBD5;  width:88%;"   OnClick="Button3_Click"  /><br>
                            <asp:Button ID="Button9" runat="server" style="padding-left:24px; border:none; text-align:left; font-size:25px; background-color:#DDDBD5; width:88%; "   OnClick="Button3_Click" />
                        </div>
                        <div style=" background-color:#DDDBD5; border-left-style:hidden; border-radius:0px; border-bottom: solid white 5px; height:auto; ">
                            <div id="con3" runat="server"><img src="../images/onclass.png" style="float:left; padding:6px; padding-bottom:9px;border-style:hidden;  width:10%;  height:auto;"    /></div>
                            <asp:Button ID="Button3" runat="server" style="padding-left:22px; border:none; text-align:left; font-size:40px; font-weight:bold; background-color:#DDDBD5;  width:88%;"   OnClick="Button3_Click"  /><br>
                            <asp:Button ID="Button10" runat="server" style="padding-left:24px; border:none; text-align:left; font-size:25px; background-color:#DDDBD5; width:88%; "   OnClick="Button3_Click" />
                        </div>
                        <div style=" background-color:#DDDBD5; border-left-style:hidden; border-radius:0px; border-bottom: solid white 5px;  height:auto; ">
                            <div id="con4" runat="server"><img src="../images/onclass.png" style="float:left; padding:6px; padding-bottom:9px;border-style:hidden;  width:10%;  height:auto;"    /></div>
                            <asp:Button ID="Button4" runat="server" style="padding-left:22px; border:none; text-align:left; font-size:40px; font-weight:bold; background-color:#DDDBD5;  width:88%;"   OnClick="Button4_Click"  /><br>
                            <asp:Button ID="Button11" runat="server" style="padding-left:24px; border:none; text-align:left; font-size:25px; background-color:#DDDBD5; width:88%; "   OnClick="Button4_Click" />
                        </div>
                        <div style=" background-color:#DDDBD5; border-left-style:hidden; border-radius:0px; border-bottom: solid white 5px; height:auto; ">
                            <div id="con5" runat="server"><img src="../images/onclass.png" style="float:left; padding:6px; padding-bottom:9px;border-style:hidden;  width:10%; height:auto; "    /></div>
                            <asp:Button ID="Button5" runat="server" style="padding-left:22px; border:none; text-align:left; font-size:40px; font-weight:bold; background-color:#DDDBD5; width:88%; "  OnClick="Button5_Click"  /><br>
                            <asp:Button ID="Button12" runat="server" style="padding-left:24px; border:none; text-align:left; font-size:25px; background-color:#DDDBD5;  width:88%;"  OnClick="Button5_Click" />
                        </div>
                        <div style=" background-color:#DDDBD5; border-left-style:hidden; border-radius:0px; border-bottom: solid white 5px; height:auto; ">
                            <div id="con6" runat="server"><img src="../images/onclass.png" style="float:left; padding:6px; padding-bottom:9px;border-style:hidden;  width:10%; height:auto; "    /></div>
                            <asp:Button ID="Button6" runat="server" style="padding-left:22px; border:none; text-align:left; font-size:40px; font-weight:bold; background-color:#DDDBD5; width:88%; "  OnClick="Button5_Click"  /><br>
                            <asp:Button ID="Button13" runat="server" style="padding-left:24px; border:none; text-align:left; font-size:25px; background-color:#DDDBD5;  width:88%;"  OnClick="Button5_Click" />
                        </div>
                        <div style=" background-color:#DDDBD5; border:hidden; height:auto; ">
                            <div id="con7" runat="server"><img src="../images/onclass.png" style="float:left; padding:6px; padding-bottom:9px;border-style:hidden;  width:10%; height:auto;"   /></div>
                            <asp:Button ID="Button7" runat="server" style="padding-left:22px; border:none; text-align:left; font-size:40px; font-weight:bold; background-color:#DDDBD5; width:88%; "   OnClick="Button7_Click"  /><br>
                            <asp:Button ID="Button14" runat="server" style="padding-left:24px; border:none; text-align:left; font-size:25px; background-color:#DDDBD5;  width:88%;"   OnClick="Button7_Click" />
                        </div> 
                    </div> 

                    <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick" ></asp:Timer>
                            </ContentTemplate>
                        </asp:UpdatePanel> 
                    </div>
                                </div>
                                <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True"  Visible="false" ></asp:ListBox>
                                <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True"  Visible="false" ></asp:ListBox>
                                <asp:ListBox ID="ListBox3" runat="server" AutoPostBack="True"  Visible="false" ></asp:ListBox>
                                <asp:ListBox ID="ListBox4" runat="server" AutoPostBack="True"  Visible="false" ></asp:ListBox>
                                <asp:ListBox ID="ListBox5" runat="server" AutoPostBack="True"  Visible="false" ></asp:ListBox>
                                               
                                <asp:ListBox ID="ListBox8" runat="server" AutoPostBack="True"  Visible="False" ></asp:ListBox>
                                <input id="StudentLessonID" type="text" runat="server" visible="false" />
                                </div>
                               
                                <div class="weekbtn">
                                    <asp:Button ID="Mon" runat="server" Text="Mon" CssClass="btnDay" margin-top=7.5px OnClick="Mon_Click"/><br>
                                    <asp:Button ID="Tue" runat="server" Text="Tue" CssClass="btnDay" OnClick="Tue_Click"/><br>
                                    <asp:Button ID="Wed" runat="server" Text="Wed" CssClass="btnDay" OnClick="Wed_Click" /><br>
                                    <asp:Button ID="Thu" runat="server" Text="Thu" CssClass="btnDay" OnClick="Thu_Click"/><br>
                                    <asp:Button ID="Fri" runat="server" Text="Fri" CssClass="btnDay" OnClick="Fri_Click"/><br> 
                                    </div>
                                <div style=" margin-left:55vw; ">
                                    <asp:Button ID="Sat"  style="background-color:#f69980;" runat="server" Text="Sat" CssClass="btnDay" OnClick="Sat_Click"/><br>
                                    <asp:Button ID="Sun"  style="background-color:#f69980;" runat="server" Text="Sun" CssClass="btnDay" OnClick="Sun_Click"/><br> 
                                </div>
                                </div>
                                </main>   
                                
                    </form>
</body>
</html>
