async function fetchDataWithErrorHandling() {
    const url = 'https://swapi.dev/api/people/10000';

    try {
        const response = await fetch(url);

        if (!response.ok) {
            throw new Error("HTTP error! Status: " + response.status);
        }

        const data = await response.json();
        console.log(data);
    } catch (error) {
        console.log(error.message);
    }
}