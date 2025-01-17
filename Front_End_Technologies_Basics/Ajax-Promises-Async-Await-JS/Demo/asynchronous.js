setTimeout(myFunction, 3000);
setInterval(time, 1000);

function myFunction() {
    document.getElementById("setTimeout").innerHTML = "Asynchronous function";
}

function time() {
    let date = new Date();
    document.getElementById("setInterval")
        .innerHTML = date.getHours()
        + ":" + date.getMinutes()
        + ":" + date.getSeconds();
}

