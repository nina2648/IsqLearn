<%@ Page Language="C#" AutoEventWireup="true" CodeFile="websocket.aspx.cs" Inherits="websocket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
        </div>
    </form>
</body>
    <script>
        var sock = new WebSocket('ws://localhost:9000');
        sock.onopen = function(event) {
            console.log('Connected successfully!');

            setTimeout(function() {
                sock.send('Hello');
            }, 1000);
        };
    </script>
</html>
