function solve([countOfNumbers, ...numbers]) {
    let counts = [0, 0, 0, 0, 0];

    for (const num of numbers) {
        if (num < 200) counts[0]++;
        else if (num < 400) counts[1]++;
        else if (num < 600) counts[2]++;
        else if (num < 800) counts[3]++;
        else counts[4]++;
    }

    counts.forEach(p => {
        console.log(`${((p / countOfNumbers) * 100).toFixed(2)}%`);
    })
}

solve([7, 800, 801, 250, 199, 399, 599, 799]);