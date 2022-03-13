src = "./pptshow.js";

function prepage(){
    var page = localStorage.getItem("page");
    var s = localStorage.getItem("url");
    var n = parseInt(page)-1;
    var imgurl = s+n.toString()+".png";
    pptshow.src = imgurl;
    localStorage.setItem("page",n);
    var sock = new WebSocket('ws://localhost:9000');
    sock.onopen = function (event) {
        sock.send('pre');
    }
}