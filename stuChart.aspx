<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stuChart.aspx.cs" Inherits="stuChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>弱點分析</title>
    <link href="css/piestu.css" rel="stylesheet" />
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
    <div>
        <br />
        <br />
        </div>
         <div id="allchart" runat="server" 
            style=" width: 800px;
    height: 600px;
    font-weight: bold;
    float: left;
    position: absolute;
    top: 55%;
    margin-top: -225px;
    margin-left: -550px;">
</div>
        <div id="piechart" runat="server" 
            style=" width: 800px;
    height: 600px;
    font-weight: bold;
    float: left;
    position: absolute;
    top: 55%;
    left:50%;
    margin-top: -225px;
    margin-left: -550px;
    z-index:3;">
</div>
         <div id="Columnchart" runat="server"
             style=" width: 800px;display:none;
    height: 600px;
    font-weight: bold;
    float: left;
    position: absolute;
    top: 55%;
    left:50%;
    margin-top: -225px;
    margin-left: -550px;
    z-index:2;">
</div>
         <div id="piepage"  class="piepage"></div>
        <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
          <asp:Button ID="Button2" runat="server" Text="查看其他日期" Height="43px" OnClick="Button2_Click" l Width="110px" Visible="False" CssClass="time" Font-Size="Small"/>
        <asp:Label ID="Label8" runat="server" Text="選擇日期" Visible="False"></asp:Label>
        <asp:DropDownList ID="timeselect" runat="server" DataSourceID="selectdate" DataTextField="LessonTime" DataValueField="LessonTime" CssClass="timeselect" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="timeselect_SelectedIndexChanged" ></asp:DropDownList>

            <asp:SqlDataSource ID="selectdate" runat="server" ConnectionString="<%$ ConnectionStrings:ilearnConnectionString %>" SelectCommand="SELECT DISTINCT CONVERT (varchar, lesson.LessonTime, 111) AS LessonTime FROM lesson INNER JOIN studentfeedback ON lesson.LessonID = studentfeedback.LessonID WHERE (lesson.CourseID = @CourseID) ORDER BY LessonTime DESC">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label4" Name="CourseID" PropertyName="Text" Type="String" />
                </SelectParameters>
        </asp:SqlDataSource>



            </header>
       
        <div id="chartselect" style="width:200px; left:55%; position:absolute; top:25%;">

            <asp:Button ID="PIE" CssClass="charttype" runat="server" style="font-size:medium" Text="圓餅圖" Visible="False"  Enabled="False" OnClick="PIE_Click" />
            &nbsp;
             <asp:Button ID="COLUMN" CssClass="charttype" runat="server" style="font-size:medium; top: 4px; left: 2px;" Text="長條圖" Visible="False"  OnClick="COLUMN_Click" />
            </div>
         <div id="coursename" style=" position:absolute;
    left:40%;
    width:300px;
    height:100px;">
 <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="True" Font-Names="Microsoft JhengHei UI" Font-Size="XX-Large" Visible="False"  ></asp:Label>
            <hr/>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;
            <asp:Label ID="date" runat="server" Font-Size="X-Large" Visible="False"></asp:Label>
    </div>
    <div>
        <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <br />
        <br />
         <asp:Literal ID="ltScripts2" runat="server"></asp:Literal>
        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    </div>
        <div>
       
           
           </div>
         <main>
        <div class="piemain">

            <div id="classbtn">
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="沒有資料錄可顯示。"  AllowSorting="True" DataSourceID="SqlDataSource3"  BorderStyle="None" CellPadding="0" GridLines ="None" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Course", "{0}") %>' Text='<%# Eval("Course") %>' CssClass="button" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ilearnConnectionString %>" SelectCommand="SELECT course.Course FROM course INNER JOIN courseselection ON course.CourseID = courseselection.CourseID WHERE (courseselection.StudentID = @StudentID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="StudentID" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ilearnConnectionString %>" SelectCommand="SELECT [Course] FROM [course] WHERE ([TeacherID] = @TeacherID)">
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