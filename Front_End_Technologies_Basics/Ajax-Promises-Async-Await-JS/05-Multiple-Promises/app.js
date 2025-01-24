function multiplePromises() {
      Promise.allSettled([
            new Promise((resolve, reject) => {
                  setTimeout(() => {
                        resolve('Success after 1 sec.');
                  }, 1000);
            }),
            new Promise((resolve, reject) => {
                  setTimeout(() => {
                        resolve('Success after 2 sec.');
                  }, 2000);
            }),
            new Promise((_, reject) => {
                  setTimeout(() => {
                        reject('Failure after 3 sec.');
                  }, 3000);
            })
      ]).then((results) => {
            results.forEach((result) => {
                  if (result.status === "fulfilled") {
                        console.log(`Status: ${result.status}, value: ${result.value}`);
                  } else {
                        console.log(`Status: ${result.status}, value: ${result.reason}`);
                  }
            });
      });
}