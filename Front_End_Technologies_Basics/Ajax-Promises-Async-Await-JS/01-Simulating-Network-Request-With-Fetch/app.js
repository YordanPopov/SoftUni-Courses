function fetchData() {
    fetch('https://swapi.dev/api/people/1')
        .then(res => res.json())
        .then(data => console.log(data));
}