function ckch(){
    var sel = document.getElementById('page');
    var index = document.getElementById('page').selectedIndex;
    var page = document.getElementById('page').options[index].text;
    console.log(page);
    var fbf = localStorage.getItem("ckfast");
    var fbn = localStorage.getItem("cknoise");
    var fbc = localStorage.getItem("ckcon");

    var data = {};
    data["sdid"] = 'S001';
    data["classid"] = 'C001';
    data["page"] = page;
    data["Fbfast"] = fbf;
    data["Fbnoise"] = fbn;
    data["Fbdu"] = fbc;
    if(fbf=="0"&&fbn=="0"&&fbc=="0"){
        data["Fbok"] = "1";
    }
    else{
        data["Fbok"] = "0";
    }


    $.ajax({
        dataType: "json",
        url: "http://192.192.155.110/API/Api/Updfb",
        async:false,
        data:data,
        type: "POST"
     }).success(function (r) {
        //成功
        var re = JSON.parse(r);
        console.log(re);
    })
    document.getElementById('ckppt').src="http://192.192.155.110/img/"+page+".png";
    sel.remove(index);
    localStorage.setItem("ckfast",0);
    localStorage.setItem("cknoise",0);
    localStorage.setItem("ckcon",0);
}