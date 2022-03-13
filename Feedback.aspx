<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<html lang="BIG-5">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>即時回饋</title>
    <link rel="stylesheet" href="css/feedback.css">
    <script type="text/javascript" src="./jquery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="./jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/cnapi.js"></script>
    <script type="text/javascript" src="js/pptshow.js"></script>
    <script type="text/javascript" src="js/wsppt.js"></script>
    <script type="text/javascript" src="js/next.js"></script>
    <script type="text/javascript" src="js/pre.js"></script>
    <script type="text/javascript" src="js/feedbackstu.js"></script>
    <script type="text/javascript" src="js/fbfun.js"></script>
    <script type="text/javascript" src="js/ckfb.js"></script>
    <script type="text/javascript" src="js/chpdtl.js"></script>
    <script type="text/javascript" src="js/aftc.js"></script>
</head>
<body style="font-family: Microsoft JhengHei,Arial;" onload="sh(); savevalue();">
    <!--頂端-->
    <header id="header">
        <div class="banner">
            <div class="userbtn">
                <div class="usermsg">
                    <div class="userlogo"></div>
                    <div class="username"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></div>
                </div>
                <!--切換頁面按鈕-->
                <div class="btns">
                    <nav id="btnpage">
                        <ul>
                            <li id="btnclasslist"><a href="CourselistStudent.aspx" >課堂列表</a></li>
                            <li id="btnpie"><a href="stuChart.aspx" class="scroll" >弱點分析</a></li>
                            <li id="btnaccount"><a href="Account.aspx" class="scroll" >我的帳號</a></li>
                            <li id="btnexit" style="border-right:0px;"><a href="Login.aspx" class="scroll" >登出</a></li>
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
                <div id="fbbtn">
                    <button id="fast" type="button" title="太快" onclick="changeColor_f();" ></button>
                    <button id="noise" type="button" title="太吵" onclick="changeColor_n();"></button>
                    <button id="confuse" type="button" title="聽不懂" onclick="changeColor_c();"></button>
                    <button id="OK"  type="button" title="聽懂了" style="visibility: hidden;" onclick="changeColor_o();"></button>

                    <input id="fbvaluef"  type="hidden" runat='server' />
                    <input id="fbvaluen"  type="hidden" runat='server' />
                    <input id="fbvaluec"  type="hidden" runat='server' />
                    <input id="fbvalueo"  type="hidden" runat='server' />
                    <input id="fbvaluee"  type="hidden" runat='server' />
                    <input id="fbtotalmsg"  type="hidden" runat='server' />
                </div>
            </div>
            <div id="fbmsg">
                <!--回饋訊息顯示區-->
                <div id="msgshow" style="overflow-y : scroll;">
                    <!--js新增的div跟覆議按鈕會放這裡-->
                </div>` 

                <!--問題輸入區-->
                <div id="msgenter">
                    <div class="default">
                        <label for="default">其它:</label>
                        <select id="default" onchange="areashow();">
                            <option value="Homework">老師上次有出作業</option>
                            <option value="Already">上次教過了</option>
                            <option value="Clock">老師打鐘了</option>
                            <option value="Hot">教室好熱喔</option>
                            </select>
                        <button id="elsesend" class="elsesend" type="button" onclick="addElementDiv();"> 回饋</button>
                        <br>
                    </div>
                    <textarea id="enter" rows="4" cols="50"></textarea>
                </div>
            </div>
        </div>
    </main>

</body>
</html>