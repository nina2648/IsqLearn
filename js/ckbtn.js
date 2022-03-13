var fast = 0;
var noise = 0;
var con = 0;

function ckf(){
    if (fast == 0) {
        cfast.style.backgroundColor = "#FDE3A6";
        fast = 1;
    } else {
        cfast.style.backgroundColor = "#F6B980";
        fast = 0;
    }
    localStorage.setItem("ckfast",fast);
}
function ckn(){
    if (noise == 0) {
        cnoise.style.backgroundColor = "#FDE3A6";
        noise = 1;
    } else {
        cnoise.style.backgroundColor = "#F6B980";
        noise = 0;
    }
    localStorage.setItem("cknoise",noise);
}
function ckc(){
    if (con == 0) {
        cconfuse.style.backgroundColor = "#FDE3A6";
        con = 1;
    } else {
        cconfuse.style.backgroundColor = "#F6B980";
        con = 0;
    }
    localStorage.setItem("ckcon",con);
}