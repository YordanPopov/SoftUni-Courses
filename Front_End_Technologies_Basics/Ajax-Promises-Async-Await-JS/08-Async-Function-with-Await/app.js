async function simplePromiseAsync() {
    console.log("Before promise!");
    let result = await waitTwoSeconds();
    console.log(result);
}

function waitTwoSeconds() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Async/Await is awesome!");
        }, 2000);
    });
}