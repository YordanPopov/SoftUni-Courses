async function throttlePromises() {
    const asyncTasks = [
        () => new Promise(resolve => setTimeout(() => { console.log("Task 1 done"); resolve("Task 1 done") }, 4000)),
        () => new Promise(resolve => setTimeout(() => { console.log("Task 2 done"); resolve("Task 2 done") }, 2500)),
        () => new Promise(resolve => setTimeout(() => { console.log("Task 3 done"); resolve("Task 3 done") }, 500)),
        () => new Promise(resolve => setTimeout(() => { console.log("Task 4 done"); resolve("Task 4 done") }, 50))
    ]

    async function throttle(tasks, limit) {
        const results = [];
        const executing = [];

        for (const task of tasks) {
            const currentPromise = task().then((result) => {
                executing.splice(executing.indexOf(currentPromise), 1);
                return result;
            });

            results.push(currentPromise);
            executing.push(currentPromise);

            if (executing.length >= limit) {
                await Promise.race(executing);
            }
        }

        return Promise.all(results);
    }

    const results = await throttle(asyncTasks, 2);
    console.log("All taks done: ", results);

}