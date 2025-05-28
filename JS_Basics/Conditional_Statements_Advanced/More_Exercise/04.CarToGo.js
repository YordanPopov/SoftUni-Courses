function solve(budget, season) {
    const classes = [
        { max: 100, name: 'Economy class' },
        { max: 500, name: 'Compact class' },
        { max: Infinity, name: 'Luxury class' }
    ];

    const pricing = {
        'Economy class': {
            Summer: { type: 'Cabrio', percent: 0.35 },
            Winter: { type: 'Jeep', percent: 0.65 }
        },
        'Compact class': {
            Summer: { type: 'Cabrio', percent: 0.45 },
            Winter: { type: 'Jeep', percent: 0.80 }
        },
        'Luxury class': {
            Summer: { type: 'Jeep', percent: 0.90 },
            Winter: { type: 'Jeep', percent: 0.90 }
        },
    };

    const carClass = classes.find(c => budget <= c.max).name;
    const { type: carType, percent } = pricing[carClass][season];
    const carPrice = budget * percent;

    console.log(`${carClass}\n${carType} - ${carPrice.toFixed(2)}`);
}

solve(1010, 'Summer');