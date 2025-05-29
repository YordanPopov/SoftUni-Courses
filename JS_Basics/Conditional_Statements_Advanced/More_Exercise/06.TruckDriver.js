function solve(season, kilometers) {
    const annualKilometers = kilometers * 4;

    const rates = {
        'Spring': [0.75, 0.95, 1.45],
        'Autumn': [0.75, 0.95, 1.45],
        'Summer': [0.90, 1.10, 1.45],
        'Winter': [1.05, 1.25, 1.45]
    };

    let rate = 0;
    if (kilometers <= 5000) {
        rate = rates[season][0];
    } else if (kilometers <= 10_000) {
        rate = rates[season][1];
    } else if (kilometers <= 20_000) {
        rate = rates[season][2];
    }

    const grossEarning = annualKilometers * rate;
    const netEarning = grossEarning * 0.9;

    console.log(netEarning.toFixed(2));
}

solve('Autumn', 8600);