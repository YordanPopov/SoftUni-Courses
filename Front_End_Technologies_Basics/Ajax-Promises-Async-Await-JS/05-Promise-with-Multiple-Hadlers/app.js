function promiseWithMultipleHandlers() {
    let prom = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Hello world");
        }, 2000);
    });

    prom.then((res) => {
        console.log(res + " This is first res...");
        return res;
    }).then((res) => {
        console.log(res + " This is second res...");
    });
}