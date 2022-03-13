var f = 0;
var n = 0;
var c = 0;
var o = 0;
var e = 0;
var msgdiv = 0;
var totalmsg = 0;
var elsetext = "";

//控制按鈕變色
function changeColor_f() {
    if (f == 0) {
        fast.style.backgroundColor = "#FDE3A6";
        f = 1;
    } else {
        fast.style.backgroundColor = "#F6B980";
        f = 0;
    }
    document.getElementById("fbvaluef").value = f;
    //Label1.innerText = f;
}

function changeColor_n() {
    if (n == 0) {
        noise.style.backgroundColor = "#FDE3A6";
        n = 1;
    } else {
        noise.style.backgroundColor = "#F6B980";
        n = 0;
    }
    document.getElementById("fbvaluen").value = n;
}
function changeColor_c() {
    if (c == 0) {
        confuse.style.backgroundColor = "#FDE3A6";
        c = 1;
    } else {
        confuse.style.backgroundColor = "#F6B980";
        c = 0;
    }
    document.getElementById("fbvaluec").value = c;
}
function changeColor_o() {
    if (o == 0) {
        OK.style.backgroundColor = "#FDE3A6";
        o = 1;
    } else {
        OK.style.backgroundColor = "#F6B980";
        o = 0;
    }
    document.getElementById("fbvalueo").value = o;
}


//JS傳值到CS --回饋按鈕
function savevalue() {

    document.getElementById("fbvaluef").value = f;
    document.getElementById("fbvaluen").value = n;
    document.getElementById("fbvaluec").value = c;
    document.getElementById("fbvalueo").value = o;
    document.getElementById("fbvaluee").value = e;
    //document.getElementById("fbpagenum").value = pagenum;
}

//JS傳值到CS --其他回饋
function elsemsg() {
    elsetext = document.getElementById("enter").value;

    Label1.innerText = elsetext;
}

//新增顯示其他回饋訊息的div
function addElementDiv() {
    //獲取textarea的內容
    elsetext = document.getElementById("enter").value;

    if (elsetext != "") {
        var parent = document.getElementById("msgshow");
        //新增 div
        var div = document.createElement("div");
        //設定 div 屬性，如 id
        div.setAttribute("id", msgdiv);
        div.innerHTML = elsetext;
        parent.appendChild(div);

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


        //在新增的div中增加覆議按鈕
        addbutton();


        e = 1;
        document.getElementById("fbvaluee").value = e;
    }
    else {
        alert('請輸入訊息');
    }
}

function addbutton() {
    var parentdiv = document.getElementById(msgdiv);
    //新增覆議button
    var btn = document.createElement("button");
    btn.setAttribute("id", "newButton");
    btn.setAttribute("type", "button");
    parentdiv.appendChild(btn);

    //清空textarea
    //document.getElementById("msgshow").value = "";
    //document.getElementById("msgshow").innerHTML = "";

    //將計算msg變數加一供下次回饋使用
    msgdiv++;
}

//換頁時頁碼加一
function pageadd() {
    pagenum++;
    document.getElementById("fbpagenum").value = pagenum;
    return true;
}


//回饋存入觸發
function savefeedback() {
    document.getElementById('btnsave').click();
}