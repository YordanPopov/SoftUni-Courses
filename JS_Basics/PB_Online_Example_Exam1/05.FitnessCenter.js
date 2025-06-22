function solve([visitorsCount, ...activities]) {
    let training = 0;
    let byuing = 0;
    const visitors = {
        'back': 0,
        'chest': 0,
        'legs': 0,
        'abs': 0,
        'protein shake': 0,
        'protein bar': 0
    }

    for (const activity of activities) {
        switch (activity) {
            case 'Back': visitors['back']++; break;
            case 'Chest': visitors['chest']++; break;
            case 'Legs': visitors['legs']++; break;
            case 'Abs': visitors['abs']++; break;
            case 'Protein shake': visitors['protein shake']++; break;
            case 'Protein bar': visitors['protein bar']++; break;
        }
    }

    for (const key in visitors) {
        if (key === 'back' || key === 'chest' || key === 'legs' || key === 'abs') {
            training += visitors[key];
        } else {
            byuing += visitors[key];
        }

        console.log(`${visitors[key]} - ${key}`);
    }

    console.log(`${(training / visitorsCount * 100).toFixed(2)}% - work out`);
    console.log(`${(byuing / visitorsCount * 100).toFixed(2)}% - protein`);
}

solve(["10",
    "Back",
    "Chest",
    "Legs",
    "Abs",
    "Protein shake",
    "Protein bar",
    "Protein shake",
    "Protein bar",
    "Legs",
    "Abs"]);
