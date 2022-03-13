<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Check.aspx.cs" Inherits="Check" %>

<html lang="BIG-5">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="css/check.css" >
    <script type="text/javascript" src="./jquery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="./jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="./js/ckfb.js"></script>
    <script type="text/javascript" src="./js/ckonchange.js"></script>
    <script type="text/javascript" src="./js/ckbtn.js"></script>
    <script type="text/javascript" src="./js/ckck.js"></script>

</head>
<body style="font-family: Microsoft JhengHei,Arial;" onload="ckfb()">
    <header>
        <div class="banner">
            <div class="icon">!</div>
            <div class="title">課堂中未回饋確認</div>
        </div>
    </header>
    <main id="main">
        <div id="cksr">
            <label for="cksr">請選擇未回饋頁碼：</label>
            <select id="page" onchange="ckch()">
            </select>
            <button id="check" onclick="ck()" style=" width: 60px; height: 20px;">確認</button>
        </div>
        <img id="ckppt">
        <button id="cfast" onclick="ckf()"></button>
        <button id="cnoise" onclick="ckn()"></button>
        <button id="cconfuse" onclick="ckc()"></button>
    </main>
</body>
</html>
