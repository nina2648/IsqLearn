var f = 0;
var n = 0;
var c = 0;
var o = 0;
var e = 0;
var msgdiv = 0;
var totalmsg = 0;
var elsetext = "";


//覆議用陣列
var Recon = [];

//控制按鈕變色
function changeColor_f() {
    if (f == 0) {
        fast.style.backgroundColor = "#FDE3A6";
        f = 1;
        ckfast();
    } else {
        fast.style.backgroundColor = "#F6B980";
        f = 0;
        nockfast();
    }
    //document.getElementById("fbvaluef").value = f;
    localStorage.setItem("fbvaluef", f);
}

function changeColor_n() {
    if (n == 0) {
        noise.style.backgroundColor = "#FDE3A6";
        n = 1;
        cknoise();
    } else {
        noise.style.backgroundColor = "#F6B980";
        n = 0;
        nocknoise();
    }
    //document.getElementById("fbvaluen").value = n;
    localStorage.setItem("fbvaluen", n);
}
function changeColor_c() {
    if (c == 0) {
        confuse.style.backgroundColor = "#FDE3A6";
        c = 1;
        ckconfuse();
    } else {
        confuse.style.backgroundColor = "#F6B980";
        c = 0;
        nockconfuse();
    }
    //document.getElementById("fbvaluec").value = c;
    localStorage.setItem("fbvaluec", c);
}
function changeColor_o() {
    if (o == 0) {
        OK.style.backgroundColor = "#FDE3A6";
        o = 1;
        ckOK();
    } else {
        OK.style.backgroundColor = "#F6B980";
        o = 0;
        nockOK();
    }
    //document.getElementById("fbvalueo").value = o;
    localStorage.setItem("fbvalueo", o);
}


//JS傳值到CS --回饋按鈕
function savevalue() {

    //document.getElementById("fbvaluef").value = f;
    //document.getElementById("fbvaluen").value = n;
    //document.getElementById("fbvaluec").value = c;
    //document.getElementById("fbvalueo").value = o;
    //document.getElementById("fbvaluee").value = e;


    localStorage.setItem("fbvaluef", f);
    localStorage.setItem("fbvaluen", n);
    localStorage.setItem("fbvaluec", c);
    localStorage.setItem("fbvalueo", o);
    localStorage.setItem("fbvaluee", e);
    //document.getElementById("fbpagenum").value = pagenum;
}

//JS傳值到CS --其他回饋
//function elsemsg() {
//    elsetext = document.getElementById("enter").value;

//    Label1.innerText = elsetext;
//}

//新增顯示其他回饋訊息的div
function addElementDiv() {
    //獲取textarea的內容
    elsetext = document.getElementById("enter").value;

    if (elsetext != "") {
        var parent = document.getElementById("msgshow");
        //新增 div
        var div = document.createElement("div");
        //設定 div 屬性，如 id
        var divn = msgdiv;
        div.setAttribute("id", divn);
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
        addbutton(divn);

        e = 1;
        //document.getElementById("fbvaluee").value = e;
        localStorage.setItem("fbvaluee", e);
        localStorage.setItem("fbelsemsg", elsetext);
        ckelse(elsetext);
    }
    else {
        alert('請輸入訊息');
    }


}

function addbutton(num) {
    var parentdiv = document.getElementById(msgdiv);
    //新增覆議button
    var btn = document.createElement("button");
    var btnn = "btn" + msgdiv;
    Recon.push(0);

    btn.setAttribute("id", btnn);
    btn.setAttribute("type", "button");
    parentdiv.appendChild(btn);

    var acb = document.getElementById(btnn);

    btn.onclick = function () {
        if (Recon[num] == "0") {
            acb.style.backgroundColor = "#FDE3A6";
            Recon[num] = 1;
            ckrecon(num);
        } else {
            acb.style.backgroundColor = "#F6B980";
            Recon[num] = 0;
            nockrecon(num);
        }
    }
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

//重講時啟用聽懂按鈕
function retr() {
    if (OK.style.visibility = "hidden") {
        OK.style.visibility = "visible";
    }
    else {
        OK.style.visibility = "hidden";
    }
}

function areashow() {
    var s = document.getElementById("default");
    var index = s.selectedIndex;
    var text = s.options[index].text;
    var en = document.getElementById("enter");
    en.value = text;
}

function clear() {
    f = 0;
    n = 0;
    c = 0;
    o = 0;
    e = 0;
    msgdiv = 0;

    savevalue();
    fast.style.backgroundColor = "#F6B980";
    noise.style.backgroundColor = "#F6B980";
    confuse.style.backgroundColor = "#F6B980";
    OK.style.backgroundColor = "#F6B980";

    //隱藏聽懂按鈕
    OK.style.visibility = "hidden";

    document.getElementById("msgshow").innerHTML = "";
}
function stuelse(elsemsg) {

    var parent = document.getElementById("msgshow");
    //新增 div
    var div = document.createElement("div");
    //設定 div 屬性，如 id
    var divn = msgdiv;
    div.setAttribute("id", divn);
    div.innerHTML = elsemsg;
    parent.appendChild(div);

    //新增要傳到cs的input
    var input = document.createElement("input");
    //設定 input 屬性，如 id
    input.id = "msg" + msgdiv;
    input.name = "msg" + msgdiv;
    input.setAttribute("type", "hidden");
    input.setAttribute("runat", 'server');
    //input.runat = "server";
    input.value = elsemsg;
    parent.appendChild(input);


    //在新增的div中增加覆議按鈕
    addbutton(divn);
}