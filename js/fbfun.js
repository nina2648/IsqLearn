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
