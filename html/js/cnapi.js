var server = "http://192.192.155.110/API/Api/";
//var server = "http://localhost:44339/Api/";
var api_ppt = server + "cutppt";
var api_pptshow = server + "Pptimg";

function apifnc(url,dataJSON){
   $.ajax({
      dataType: "json",
      url: url,
      async:false,
      data:dataJSON,
      type: "POST"
   }).success(function (data) {
      //成功
      console.log("ss"+data);
      return data;
   });
} 
 