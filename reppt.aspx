<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reppt.aspx.cs" Inherits="reppt" %>

<html lang="BIG-5">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="css/reppt.css" >
    <script type="text/javascript" src="./jquery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="./jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="./js/ckfb.js"></script>
    <script type="text/javascript" src="./js/ckonchange.js"></script>

</head>
<body style="font-family: Microsoft JhengHei,Arial;" onload="ckfb()">
    <header>
        <div class="banner">
            <div class="icon">✍</div>
            <div class="title">教材</div>
        </div><asp:Label ID="ppage" runat="server" Text="頁數:"></asp:Label>
        <asp:Label ID="selectpage" runat="server" Text="Label"></asp:Label>
        

    </header>
    <img  id="ckppt" runat="server" />
    </main>
</body>
</html>
