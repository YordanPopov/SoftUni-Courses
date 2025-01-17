let myPromise = new Promise(function (myResolve, myReject, value = true) {
    setTimeout(function () {
        if (!value) {
            myReject("Goodbye World!!")
        }
        myResolve("Hello World!!!");
    }, 4000);
});

myPromise
    .then(function (value) {
        document.getElementById("promise").innerHTML = value;
    })
    .catch(function (err) {
        document.getElementById("promise").innerHTML = err;
    });