function solve(budget, season) {
    const accommodationType = [
        { max: 1000, name: 'Camp' },
        { max: 3000, name: 'Hut' },
        { max: Infinity, name: 'Hotel' }
    ];

    const pricing = {
        'Camp': {
            Summer: { location: 'Alaska', percent: 0.65 },
            Winter: { location: 'Morocco', percent: 0.45 }
        },
        'Hut': {
            Summer: { location: 'Alaska', percent: 0.80 },
            Winter: { location: 'Morocco', percent: 0.60 }
        },
        'Hotel': {
            Summer: { location: 'Alaska', percent: 0.90 },
            Winter: { location: 'Morocco', percent: 0.90 }
        }
    };

    const accomodation = accommodationType.find(a => a.max >= budget).name;
    const { location, percent } = pricing[accomodation][season];
    const accomodationPrice = budget * percent;

    console.log(`${location} - ${accomodation} - ${accomodationPrice.toFixed(2)}`);
}

solve(799.50, 'Winter');