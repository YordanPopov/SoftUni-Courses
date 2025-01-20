function racePromise() {
    const promise3 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Promise3");
        }, 3000);
    });

    const promise2 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Promise2");
        }, 2000);
    });

    const promise1 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Promise1");
        }, 1000);
    });

    Promise.race([promise3, promise1, promise2])
        .then(result => {
            console.log(result);
        });
}