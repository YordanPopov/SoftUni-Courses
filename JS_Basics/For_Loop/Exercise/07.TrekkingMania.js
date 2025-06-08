function solve([groups, ...peopleInGroup]) {
    peopleInGroup = peopleInGroup.map(Number);
    let groupSize = 0;

    let counts = {
        "musala": 0,
        "monblan": 0,
        "kilimandjaro": 0,
        "k2": 0,
        "everest": 0
    }

    for (const people of peopleInGroup) {
        if (people <= 5) counts["musala"] += people;
        else if (people <= 12) counts["monblan"] += people;
        else if (people <= 25) counts["kilimandjaro"] += people;
        else if (people <= 40) counts["k2"] += people;
        else counts["everest"] += people;

        groupSize += people;
    }

    for (const key in counts) {
        console.log(`${(counts[key] / groupSize * 100).toFixed(2)}%`);
    }
}

solve(["10",
    "10",
    "5",
    "1",
    "100",
    "12",
    "26",
    "17",
    "37",
    "40",
    "78"]);
