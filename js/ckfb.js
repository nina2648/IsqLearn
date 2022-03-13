function ckfb(){
    var data = {};
    data["sdid"] = 'A106221029';
    data["classid"] = 'C00120201119';

    $.ajax({
        dataType: "json",
        url: "http://192.192.155.110/API/Api/Afc",
        async:false,
        data:data,
        type: "POST"
     }).success(function (r) {
        //成功
        var re = JSON.parse(r);
        console.log(re);
        for(i=0;i<re.data.length;i++){
            console.log(re.data[i].ImgPage);
            var p =re.data[i].ImgPage;
            document.getElementById('page').options[i]=new Option(p,i);
        }
        document.getElementById('ckppt').src="http://192.192.155.110/img/"+re.data[0].ImgPage+".png";
        
    })
    
    
}