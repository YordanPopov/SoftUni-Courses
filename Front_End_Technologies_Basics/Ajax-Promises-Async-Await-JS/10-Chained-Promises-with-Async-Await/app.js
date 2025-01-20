async function chainedPromisesAsync() {
    const promise1 = await new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Promise1");
        }, 1000);
    });

    const promise2 = await new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Promise2");
        }, 2000);
    });

    const promise3 = await new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Promise3");
        }, 3000);
    });

    console.log(promise1, promise2, promise3);
}