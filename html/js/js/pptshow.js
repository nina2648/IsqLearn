src = "./cnapi.js";
window.onload = function w() {
    var sock = new WebSocket('ws://localhost:9000');
    sock.onopen = function (event) {
        console.log('Connected successfully!');

        setTimeout(function () {
            sock.send('Hello');
        }, 1000);
    };
}