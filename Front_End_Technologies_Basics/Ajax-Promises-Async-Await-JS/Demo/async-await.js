async function display() {
    let promise = new Promise(function (resolve) {
        setTimeout(function () { resolve("Async-Await") }, 5000)
    });
    document.getElementById("async-await").innerHTML = await promise;
}

display();