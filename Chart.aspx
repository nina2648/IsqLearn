<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chart.aspx.cs" Inherits="Chart2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<html lang="BIG-5" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教學追蹤</title>
 <link rel="stylesheet" href="css/pietr.css" />
    </head>
<body  style="font-family: Microsoft JhengHei,Arial;">  
    <form id="form2" runat="server">  
          <!--頂端-->
    <header id="header">
        <div class="banner">
            <div class="userbtn">
                <div class="usermsg">
                    <div class="userlogo"></div>
                    <div class="username"> <asp:Label ID="Label2" runat="server" Text=""></asp:Label></div>
                </div>
                <!--切換頁面按鈕-->
                <div class="btns">
                    <nav id="btnpage">
                        <ul>
                    <li id="btnclasslist"><a href="CourselistTeacher.aspx">課堂列表</a></li>
                    <li id="btnpie"><a href="Chart.aspx">教學追蹤</a></li>
                    <li id="btnaccount"><a href="Accountteacher .aspx">我的帳號</a></li>
                    <li id="btnexit" style="border-right:0px;"><a href="Login.aspx">登出</a></li>
                            <asp:Label ID="Label1" runat="server" Text="" Visible="False"></asp:Label>
                        </ul>
                    </nav>
                </div>
            </div>
            </div>
    <div>
        <br />
        <br />
        </div>
         <asp:Label ID="Label7" runat="server" Visible="False" ></asp:Label>
         <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ilearnConnectionString %>" SelectCommand="SELECT lesson.LessonID FROM lesson INNER JOIN studentfeedback ON lesson.LessonID = studentfeedback.LessonID WHERE (lesson.LessonTime = (SELECT MAX(LessonTime) AS Expr1 FROM lesson AS lesson_1 WHERE (CourseID = @courseID))) AND (studentfeedback.CourseID = @courseID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="Label5" Name="CourseID" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
      


<div id="piechart" class="piechart">
</div>
 
     
<div id="piechart2" class="piechart2">  
</div>
        <div id="piepage" class="piepage" ></div>
        <div id="piepage2" class="piepage2"></div>
        <asp:Button ID="Button2" runat="server" Text="查看其他日期" Height="43px" OnClick="Button2_Click" l Width="110px" Visible="False" CssClass="time" Font-Size="Small"/>
        <asp:Label ID="Label8" runat="server" Text="選擇日期" Visible="False"></asp:Label>
        <asp:DropDownList ID="timeselect" runat="server" DataSourceID="selectdate" DataTextField="LessonTime" DataValueField="LessonTime" CssClass="timeselect" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="timeselect_SelectedIndexChanged" ></asp:DropDownList>

            <asp:SqlDataSource ID="selectdate" runat="server" ConnectionString="<%$ ConnectionStrings:ilearnConnectionString %>" SelectCommand="SELECT DISTINCT CONVERT (varchar, lesson.LessonTime, 111) AS LessonTime FROM lesson INNER JOIN studentfeedback ON lesson.LessonID = studentfeedback.LessonID WHERE (lesson.CourseID = @CourseID) ORDER BY LessonTime DESC">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label5" Name="CourseID" PropertyName="Text" Type="String" />
                </SelectParameters>
        </asp:SqlDataSource> </header>
        <div id="coursename" style=" position:absolute;
    left:40%;
    width:300px;
    height:100px;">
 <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Microsoft JhengHei UI" Font-Size="XX-Large" Label="" server="" Text="Label"></asp:Label>
            <hr/>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;
            <asp:Label ID="date" runat="server" Font-Size="X-Large"></asp:Label>
    </div><div> <div id="pagebtn" style="position:absolute;left:60%;top:27%;">
        </div
        ><script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <br />
        <br />
        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
         <asp:Literal ID="ltScripts2" runat="server"></asp:Literal>
    </div>
        <asp:Label ID="Labell" runat="server" server=""></asp:Label>
         <main>
        <div class="piemain">
            <div id="courseshow">
                  <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ilearnConnectionString %>" SelectCommand="SELECT [CourseID] FROM [course] WHERE ([TeacherID] = @TeacherID)">
                      <SelectParameters>
                          <asp:ControlParameter ControlID="Label1" Name="TeacherID" PropertyName="Text" Type="String" />
                      </SelectParameters>
                  </asp:SqlDataSource>
                </div>
            <div id="classbtn">
                <asp:Label ID="Label4" runat="server" Text="請選擇課程" Font-Bold="True" Font-Names="Microsoft JhengHei UI" Font-Size="Large" ></asp:Label> 
                <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label> 
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="沒有資料錄可顯示。"  AllowSorting="True" DataSourceID="SqlDataSource2"  BorderStyle="None" CellPadding="0" GridLines ="None" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                         <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandArgument='<%# Bind("Course", "{0}") %>' Text='<%# Eval("CourseID")+"-"+ Eval("Course") %>' />
                    </ItemTemplate>
                    <ControlStyle CssClass="button" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ilearnConnectionString %>" SelectCommand="SELECT Course, CourseID FROM course WHERE (TeacherID = @TeacherID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="TeacherID" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ilearnConnectionString %>" SelectCommand="Getcourselist" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
           
        </div> 
    </main>
    </form>
   </body>
</html>