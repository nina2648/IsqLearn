<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onclasstr.aspx.cs" Inherits="onclasstr" %>

<html lang="BIG-5">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>進行課程</title>
    <link rel="stylesheet" href="css/onclasstr.css" >
    <!--下拉式選單-->
    
    <script type="text/javascript" src="./jquery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="./jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/wsppt.js"></script>
    <script type="text/javascript" src="js/cnapi.js"></script>
    <script type="text/javascript" src="js/pptshow.js"></script>
    <script type="text/javascript" src="js/pre.js"></script>
    <script type="text/javascript" src="js/next.js"></script>
    <script type="text/javascript" src="js/fbfun.js"></script>
    <script type="text/javascript" src="js/onclasstr.js"></script>
    <script type="text/javascript" src="js/aftc.js"></script>
    <script type="text/javascript" src="js/pptupload.js"></script>
    <script type="text/javascript">
        var isClick = false;
        function leave1() {
            window.document.getElementById('Button1').click();
            var isClick = true;

            if (isClick) {
                setTimeout(l1, 10)
            };
        }    
        function l1() {
            window.location.href = 'CourselistTeacher.aspx';
        }
        function leave2() {
            window.document.getElementById('Button1').click();
            var isClick = true;

            if (isClick) {
                setTimeout(l2, 10)
            };
        }
        function l2() {
            window.location.href = 'Chart.aspx';
        }
        function leave3() {
            window.document.getElementById('Button1').click();
            var isClick = true;

            if (isClick) {
                setTimeout(l3, 10)
            };
        }
        function l3() {
            window.location.href = 'Accountteacher.aspx';
        }
        function leave4() {
            window.document.getElementById('Button1').click();
            var isClick = true;

            if (isClick) {
                setTimeout(l4, 10)
            };
        }
        function l4() {
            window.location.href = 'Login.aspx';
        }
        var isXClose = false;
        window.onunload = leave;


        function leave() {
            setTimeout(ll, 10)
        }
        function ll() {
            window.document.getElementById('Button1').click();
        }
        window.onunload = leave;

    </script>
    
    
</head>
<body style="font-family: Microsoft JhengHei,Arial;" onload=" sh(); loadvalue(); "   onunload=" leave(); "   >

<!--頂端-->
<header id="header">
    <div class="banner">
        <div class="userbtn">
            <div class="usermsg">
                <div class="userlogo"></div>
                <div class="username"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <!--切換頁面按鈕-->
            <div class="btns">
                <nav id="btnpage">
                    <ul>
                        <li id="btnclasslist" onclick="leave1();" ><a>課堂列表</a></li>
                        <li id="btnpie" onclick="leave2();"><a  class="scroll">教學追蹤</a></li>
                        <li id="btnaccount" onclick="leave3();"><a  class="scroll">我的帳號</a></li>
                        <li id="btnexit" onclick="leave4();" style="border-right:0px;"><a  class="scroll">登出</a></li>
                    </ul>
                </nav>
            </div>
        </div>
    </div>
</header>
    <main>
        <div id="main">
            <div id="left">
                <div id="pptshare">
                    <img id="pptshow" style="max-width: 70.75vw;" ><br/>
                </div>
                <div id="btn">
                    <div id="control">
                        <button>上傳</button>
                        <button id="aftc" onclick="ckafc(); ">下課</button>
                        <button onclick="shOK(); ckre();">重講</button>
                            <form id="form1" runat="server">
                                <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click1" />  
                            </form>


                    </div>
                    <div id="page">
                        <button onclick="ckpre()">上</button>
                        <button onclick="cknext()">下</button>
                    </div>
                    <div id="OKicon" class="OK" title="聽懂了" style="visibility: hidden;"></div>
                    <div id="OKnum" style="visibility: hidden;"></div>
                </div>
            </div>
            <div id="fbmsg">
                <!--回饋訊息顯示區-->
                <div id="count">
                    <div class="fast" title="太快"></div>
                    <div id="fastnum"></div>
                    <div class="noise" title="太吵"></div>
                    <div id="noisenum"></div>
                    <div class="confuse" title="聽不懂"></div>
                    <div id="confusenum"></div>
                    <!--
                    <div class="OK"></div>
                    <div id="OKnum">10</div>
                    -->
                </div>
                <div id="elseshow" onclick="elseshow()">其它</div>
                <div id="show">
                    <div id="msgshow" style="overflow-y : scroll;">
                    </div>
                </div>
            </div>
        </div>
    </main>
</body>
</html>