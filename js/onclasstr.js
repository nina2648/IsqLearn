var ft = 0;
var nt = 0;
var ct = 0;
var ot = 0;
var et = 0;
var msgdivt = 0;
var totalmsg = 0;

//覆議用陣列
var Recon = [];
var Renum = [];

//控制其他回饋顯示
function elseshow() {
    var elseshow = document.getElementById('elseshow');
    var show = document.getElementById('show');
    if (show.style.display === 'none') {
        show.style.display = 'block';
        elseshow.style.borderRadius = '10px 10px 0 0';
        //elseshow.innerText = "隱藏";
    } else {
        show.style.display = 'none';
        elseshow.style.borderRadius = '10px';
        //elseshow.innerText = "秀出來";
    }
}

function loadvalue() {
    // var fastnum = document.getElementById('fastnum');
    // var noisenum = docutment.getElementById('noisenum');
    // var confusenum = document.getElementById('confusenum');
    // var OKnum = document.getElementById('OKnum');
    ft = 0;
    nt = 0;
    ct = 0;
    ot = 0;
    et = 0;
    fastnum.innerText = ft;
    noisenum.innerText = nt;
    confusenum.innerText = ct;
    OKnum.innerText = ot;
}

//收到回饋後增加數量並顯示
function addfast() {
    ft++;
    fastnum.innerText = ft;
}
function addnoise() {
    nt++;
    noisenum.innerText = nt;
}
function addconfuse() {
    ct++;
    confusenum.innerText = ct;
}
function addOK() {
    ot++;
    OKnum.innerText = ot;
}
//收到收回回饋後減少數量並顯示
function nofast() {
    ft--;
    fastnum.innerText = ft;
}
function nonoise() {
    nt--;
    noisenum.innerText = nt;
}
function noconfuse() {
    ct--;
    confusenum.innerText = ct;
}
function noOK() {
    ot--;
    OKnum.innerText = ot;
}



function addelse(msg) {

    var parent = document.getElementById("msgshow");
    //新增 div
    var div = document.createElement("div");
    //設定 div 屬性，如 id
    div.setAttribute("id", msgdivt);
    div.innerHTML = msg;
    parent.appendChild(div);

    /*
    //新增要傳到cs的input
    var input = document.createElement("input");
    //設定 input 屬性，如 id
    input.id = "msg" + msgdiv;
    input.name = "msg" + msgdiv;
    input.setAttribute("type", "hidden");
    input.setAttribute("runat", 'server');
    //input.runat = "server";
    input.value = elsetext;
    parent.appendChild(input);
    */



    //在新增的div中增加覆議按鈕
    addbutton();
    //在新增的div中增加顯示覆議數量的span
    addspan();

    // e = 1;
    // e++;
    //document.getElementById("fbvaluee").value = e;
    // }
    // else {
    //alert('請輸入訊息');
    // }
}

function addbutton() {
    var parentdiv = document.getElementById(msgdivt);
    //新增覆議button
    var btn = document.createElement("button");
    var btnn = "btn" + msgdivt;
    Recon.push(0);

    btn.setAttribute("id", btnn);
    btn.setAttribute("type", "button");
    parentdiv.appendChild(btn);

    //清空textarea
    //document.getElementById("msgshow").value = "";
    //document.getElementById("msgshow").innerHTML = "";

    //將計算msg變數加一供下次回饋使用
    //msgdivt++;
}

function addspan() {
    var parentdiv = document.getElementById(msgdivt);
    //新增覆議button
    var rd = document.createElement("div");
    var rdn = "rd" + msgdivt;
    Renum.push(0);

    var rdin = Renum[msgdivt];
    rd.setAttribute("id", rdn);
    rd.innerText = rdin;
    //btn.setAttribute("type", "span");
    parentdiv.appendChild(rd);

    msgdivt++;
}

//覆議
function addrecon(num) {
    var span = document.getElementById("rd" + num);
    //var spname = "rd"+num;
    Renum[num]++;
    var inner = Renum[num];
    span.innerText = inner;
}
//取消覆議
function norecon(num) {
    var span = document.getElementById("rd" + num);
    //var spname = "rd"+num;
    Renum[num]--;
    var inner = Renum[num];
    span.innerText = inner;
}

//換頁後 清空教師端回饋顯示
function clear() {
    ft = 0;
    nt = 0;
    ct = 0;
    ot = 0;
    et = 0;
    msgdivt = 0;

    fastnum.innerText = ft;
    noisenum.innerText = nt;
    confusenum.innerText = ct;
    OKnum.innerText = ot;

    //隱藏聽懂了
    OKicon.style.visibility = "hidden";
    OKnum.style.visibility = "hidden";
    document.getElementById("msgshow").innerHTML = "";
}

//按重講後顯示聽懂了
function shOK() {
    OKicon.style.visibility = "visible";
    OKnum.style.visibility = "visible";
}