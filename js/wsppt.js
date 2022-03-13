src = "./next.js";
src = "./pre.js";
src = "./feedbackstu.js";
src = "./fbfun.js";
src = "./onclasstr.js";
src = "./nclear.js";
src = "./chpdtl.js";

const ws = new WebSocket('ws://192.192.152.226:9898/');
ws.onopen = function() {
    console.log('WebSocket Client Connected');
    //ws.send('Hi this is web client.');
};
ws.onmessage = function(e) {
  console.log("Received: '" + e.data + "'");
  if(e.data=='ss'){
    console.log("over");
  }
  else if(e.data=='n'){
      nextpage();
      if (window.location == "http://192.192.155.110/Feedback.aspx") {
          pgdtl();
      }
      clear();
      
  }
  else if(e.data=='p'){
     prepage();
     clear();
  }
  else if(e.data=='fast'){
      if (window.location == "http://192.192.155.110/onclasstr.aspx") {
          addfast();
      }
  }
  else if(e.data=='noise'){
      if (window.location == "http://192.192.155.110/onclasstr.aspx") {
          addnoise();
      }
  }
  else if(e.data=='confuse'){
      if (window.location == "http://192.192.155.110/onclasstr.aspx") {
          addconfuse();
      }
  }
  else if(e.data=='OK'){
      if (window.location == "http://192.192.155.110/onclasstr.aspx") {
          addOK();
      }
  }
  else if(e.data=='nofast'){
      if(window.location == "http://192.192.155.110/onclasstr.aspx"){
          nofast();
      }
 }
  else if(e.data=='nonoise'){
      if (window.location == "http://192.192.155.110/onclasstr.aspx") {
          nonoise();
      }
 }
  else if(e.data=='noconfuse'){
      if (window.location == "http://192.192.155.110/onclasstr.aspx") {
          noconfuse();
      }
 }
  else if(e.data=='noOK'){
      if (window.location == "http://192.192.155.110/onclasstr.aspx") {
          noOK();
      }
 }
  else if(e.data=='re'){
      if (window.location == "http://192.192.155.110/Feedback.aspx") {
          retr();
      }
 } 
 //下課
 else if(e.data=='afc'){
   aft();
 }
  else{
    if(e.data!='next'&&e.data!='pre')
    {
        if (e.data.search("recon") != -1) {
            if (e.data.search("norecon") != -1) {
                var arr = new Array();
                arr = e.data.split(" ");
                if (window.location == "http://192.192.155.110/onclasstr.aspx") {
                    norecon(arr[1]);
                }
            }
            else {
                var arr = new Array();
                arr = e.data.split(" ");
                if (window.location == "http://192.192.155.110/onclasstr.aspx") {
                    addrecon(arr[1]);
                }
            }
        }
        else {
            if (window.location == "http://192.192.155.110/Feedback.aspx") {
                stuelse(e.data);
            } else {
                addelse(e.data);
            }
        }
    }
 }
};

function cknext(){
  if(ws.readyState==1){
     ws.send('next');
     clear();
  }else{console.log("no")}
}
function ckpre(){
  if(ws.readyState==1){
     ws.send('pre');
     clear();
  }else{console.log("no")}
}

//下課
function ckafc(){
  if(ws.readyState==1){
    ws.send('afc');
 }else{console.log("no")}
}

//重講
function ckre(){
    if (ws.readyState == 1) {
        ws.send('re');
 }else{console.log("no")}
}



//若薇的
function ckfast(){
  if(ws.readyState==1){
      ws.send('fast');
  }else {console.log("no")}
}
function cknoise(){
  if(ws.readyState==1){
      ws.send('noise');
  }else{console.log("no")}
}
function ckconfuse(){
  if(ws.readyState==1){
      ws.send('confuse');
  }else{console.log("no")}
}
function ckOK(){
  if(ws.readyState==1){
     ws.send('OK');
  }else{console.log("no")}
}

function nockfast(){
  if(ws.readyState==1){
      ws.send('nofast');
  }else {console.log("no")}
}
function nocknoise(){
  if(ws.readyState==1){
      ws.send('nonoise');
  }else{console.log("no")}
}
function nockconfuse(){
  if(ws.readyState==1){
      ws.send('noconfuse');
  }else{console.log("no")}
}
function nockOK(){
  if(ws.readyState==1){
     ws.send('noOK');
  }else{console.log("no")}
}


//其他回饋
function ckelse(msg){
  if(ws.readyState==1){
     ws.send(msg);
  }else{console.log("no")}
}

//覆議
function ckrecon(num) {
    if (ws.readyState == 1) {
        ws.send("recon " + num);
    } else { console.log("no") }
}
function nockrecon(num) {
    if (ws.readyState == 1) {
        ws.send("norecon " + num);
    } else { console.log("no") }
}
