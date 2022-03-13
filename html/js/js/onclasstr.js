//控制其他回饋顯示
function elseshow() {
    var elseshow = document.getElementById('elseshow');
    var show = document.getElementById('show');
    if (show.style.display === 'none') {
        show.style.display = 'block';
        elseshow.style.borderRadius = '10px 10px 0 0';
        //elseshow.innerText = "隱藏";
    } else {
        show.style.display = 'none';
        elseshow.style.borderRadius = '10px';
        //elseshow.innerText = "秀出來";
    }
}