function solve(juniorRiders, seniorRiders, trackType) {
    let juniorFee = 0;
    let seniorFee = 0;
    let totalRiders = juniorRiders + seniorRiders;

    switch (trackType) {
        case 'trail':
            juniorFee = 5.50;
            seniorFee = 7;
            break;
        case 'cross-country':
            juniorFee = 8;
            seniorFee = 9.50;
            break;
        case 'downhill':
            juniorFee = 12.25;
            seniorFee = 13.75;
            break;
        case 'road':
            juniorFee = 20;
            seniorFee = 21.50;
            break;
    }

    let totalAmount = (juniorRiders * juniorFee) + (seniorRiders * seniorFee);
    if (totalRiders >= 50 && trackType === 'cross-country') {
        totalAmount *= 0.75;
    }

    console.log(`${(totalAmount * 0.95).toFixed(2)}`);
}

solve(21, 26, 'cross-country');