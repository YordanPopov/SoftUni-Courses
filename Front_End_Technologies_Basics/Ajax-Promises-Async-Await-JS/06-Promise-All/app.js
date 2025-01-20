function allPromise() {
    let firstPromise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Promise 1");
        }, 1000);
    });

    let secondPromise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Promise 2");
        }, 2000);
    });

    let thirdPromise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Promise 3");
        }, 3000);
    });

    Promise.all([firstPromise, secondPromise, thirdPromise])
        .then(result => {
            console.log(result);
        });
}