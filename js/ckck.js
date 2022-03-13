function ck(){
    var opt = document.getElementById('page');
    var index = document.getElementById('page').selectedIndex;
    var thispage = document.getElementById('page').options[index].text;
    
    var fbf = localStorage.getItem("ckfast");
    var fbn = localStorage.getItem("cknoise");
    var fbc = localStorage.getItem("ckcon");

    for(var i = 0; i<opt.options.length;i++){
        if(i!=thispage){
            var page = document.getElementById('page').options[i].text;
            var data = {};
            data["sdid"] = 'S001';
            data["classid"] = 'C001';
            data["page"] = page;
            data["Fbfast"] = 0;
            data["Fbnoise"] = 0;
            data["Fbdu"] = 0;
            data["Fbok"] = "1";


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
        }
        else if(i==thispage){
            var page = document.getElementById('page').options[i].text;
            var data = {};
            data["sdid"] = 'S001';
            data["classid"] = 'C001';
            data["page"] = page;
            data["Fbfast"] = fbf;
            data["Fbnoise"] = fbn;
            data["Fbdu"] = Fbdu;
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
        }

    }
    
}