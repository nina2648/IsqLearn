src = "./cnapi.js";
console.log("fs");
var sock = new WebSocket('ws://localhost:9000');
sock.onopen = function (event) {
    var s = "http://192.192.155.110/img/";
    var n = 1 ;
    var pptsh = document.getElementById('pptshow');

    var data = {};
    data["pptid"] = 2;

    var url = api_pptshow;
    var image = [];
    $.ajax({
        dataType: "json",
        url: url,
        async:false,
        data:data,
        type: "POST"
     }).success(function (r) {
        //成功
        var re = JSON.parse(r);
        console.log(re);
        console.log(re.data);
        for(i=0;i<(re.data.length);i++){
            var str = JSON.stringify(re.data[i]).split("\\");
            console.log(str[8]);
            var imgsrc = str[8].split('"');
            console.log(imgsrc[0]);
            image[i] = imgsrc[0];
        }
        
        
     });
     pptsh.src = s+image[0];
    localStorage.setItem("page",n);
    localStorage.setItem("url",s);
}