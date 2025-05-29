function solve(season, groupType, studens, nights) {

    const pricing = {
        'boys': { Winter: 9.60, Spring: 7.20, Summer: 15 },
        'girls': { Winter: 9.60, Spring: 7.20, Summer: 15 },
        'mixed': { Winter: 10, Spring: 9.50, Summer: 20 }
    }

    const sports = {
        'girls': { Winter: 'Gymnastics', Spring: 'Athletics', Summer: 'Volleyball' },
        'boys': { Winter: 'Judo', Spring: 'Tennis', Summer: 'Football' },
        'mixed': { Winter: 'Ski', Spring: 'Cycling', Summer: 'Swimming' }
    }

    let totalAccommodationCost = studens * nights * pricing[groupType][season];

    if (studens >= 10 && studens < 20) {
        totalAccommodationCost *= 0.95;
    } else if (studens >= 20 && studens < 50) {
        totalAccommodationCost *= 0.85;
    } else if (studens >= 50) {
        totalAccommodationCost *= 0.50;
    }

    console.log(`${sports[groupType][season]} ${totalAccommodationCost.toFixed(2)} lv.`);
}

solve('Spring', 'mixed', 17, 14);