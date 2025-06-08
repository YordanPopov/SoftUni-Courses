function solve([stadiumCapacity, fansCount, ...fans]) {
    stadiumCapacity = Number(stadiumCapacity);
    fansCount = Number(fansCount);

    let fansBySector = {
        'A': 0,
        'B': 0,
        'V': 0,
        'G': 0,
    };

    for (const fan of fans) {
        if (fan === 'A') fansBySector['A']++;
        else if (fan === 'V') fansBySector['V']++;
        else if (fan === 'G') fansBySector['G']++;
        else if (fan === 'B') fansBySector['B']++;
    }

    for (const key in fansBySector) {
        console.log(`${(fansBySector[key] / fansCount * 100).toFixed(2)}%`);
    }
    
    console.log(`${(fansCount / stadiumCapacity * 100).toFixed(2)}%`);
}

solve(["93",
"16",
"A",
"V",
"G",
"G",
"B",
"B",
"G",
"B",
"A",
"B",
"B",
"B",
"A",
"B",
"B",
"A"]);

