<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Client.aspx.cs" Inherits="Client" %>

<html>
<head>
  <title>WebSocket Playground</title>
</head>
<body>
  <button onclick="ck()">c</button>
</body>
<script>
const ws = new WebSocket('ws://localhost:9898/');
ws.onopen = function() {
    console.log('WebSocket Client Connected');
    //ws.send('Hi this is web client.');
};
ws.onmessage = function(e) {
  console.log("Received: '" + e.data + "'");
  if(e.data=='ss'){
    console.log("over");
  }
};

function ck(){
  if(ws.readyState==1){
    console.log('online');
         ws.send('foreh');
  }else{console.log("no")}
}
</script>
</html>
