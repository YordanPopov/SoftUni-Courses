async function fetchSequential() {
    const prom1 = await fetch('https://swapi.dev/api/people/1');
    const prom2 = await fetch('https://swapi.dev/api/people/2');

    const data1 = await prom1.json();
    const data2 = await prom2.json();

    console.log(data1);
    console.log(data2);
}

fetchSequential();