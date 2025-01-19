function simplePromise() {
    let prom = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Success!");
        }, 2000)
    });

    prom.then((res) => {
        console.log(res);
    });
}