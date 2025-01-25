async function fetchWithTimeout(url = "https://swapi.dev/api/people/1", timeout = 100) {
    try {
        const response = await Promise.race([
            fetch(url).then(res => res.json()),
            new Promise((_, reject) => {
                setTimeout(() => {
                    reject(new Error('Timeout'))
                }, timeout);
            })
        ]);
        console.log(response);
    } catch (error) {
        console.error(error.message);
    }
}