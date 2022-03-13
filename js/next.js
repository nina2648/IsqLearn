src = "./pptshow.js";

function nextpage(){
    console.log("nextpage");
    var page = localStorage.getItem("page");
    var s = localStorage.getItem("url");
    var n = parseInt(page)+1;
    var imgurl = s+n.toString()+".png";
    pptshow.src = imgurl;
    localStorage.setItem("page",n);
}