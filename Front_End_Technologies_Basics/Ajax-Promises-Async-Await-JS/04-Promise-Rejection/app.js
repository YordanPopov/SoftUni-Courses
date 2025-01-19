function promiseRejection() {
    let prom = new Promise((resolve, reject) => {
        setTimeout(() => {
            reject("Something went wrong!");
        }, 1000);
    });

    prom.catch((err) => {
        console.log(err);
    });
}