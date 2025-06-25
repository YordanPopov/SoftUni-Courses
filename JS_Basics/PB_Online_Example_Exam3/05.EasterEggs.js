function solve([eggsCount, ...colors]) {
    eggsCount = Number(eggsCount);
    let maxEggs = 0;
    let maxColor = 0;
    const paintedEggs = {
        red: 0,
        orange: 0,
        blue: 0,
        green: 0,
    }

    colors.forEach(c => paintedEggs[c]++);
    for (const key in paintedEggs) {
        if (paintedEggs[key] > maxEggs) {
            maxEggs = paintedEggs[key];
            maxColor = key;
        }
    }

    console.log(`Red eggs: ${paintedEggs['red']}`);
    console.log(`Orange eggs: ${paintedEggs['orange']}`);
    console.log(`Blue eggs: ${paintedEggs['blue']}`);
    console.log(`Green eggs: ${paintedEggs['green']}`);
    console.log(`Max eggs: ${maxEggs} -> ${maxColor}`);
}

solve(["7",
    "orange",
    "blue",
    "green",
    "green",
    "blue",
    "red",
    "green"]);
