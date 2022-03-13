function pgdtl(){
    var fbf = localStorage.getItem("fbvaluef");
    var fbn = localStorage.getItem("fbvaluen");
    var fbc = localStorage.getItem("fbvaluec");
    var fbOK = localStorage.getItem("fbvalueo");
    var fbe = localStorage.getItem("fbvaluee");
    var fbmsg = localStorage.getItem("fbelsemsg");

    //新增頁碼
    var fbpage = localStorage.getItem("page");

    var data = {};
    data["Fbfast"] = fbf;
    data["Fbnoise"] = fbn;
    data["Fbdu"] = fbc;
    data["Fbok"] = fbOK;
    data["Fbelse"] = fbe;
    data["Fbelsemsg"] = fbmsg;
    data["Page"] = fbpage;


    $.ajax({
        dataType: "json",
        url: "http://192.192.155.110/API/Api/Dtl",
        async:false,
        data:data,
        type: "POST"
    }).success(function (r) {
        //成功
        /*var re = JSON.parse(r);
        console.log(re);*/
    })
}