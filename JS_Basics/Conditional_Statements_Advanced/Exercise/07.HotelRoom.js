function solve(month, nights) {
    let studioPrice;
    let apartmentPrice;

    switch (month) {
        case 'May':
        case 'October':
            studioPrice = 50;
            apartmentPrice = 65;
            break;
        case 'June':
        case 'September':
            studioPrice = 75.20;
            apartmentPrice = 68.70;
            break;
        case 'July':
        case 'August':
            studioPrice = 76;
            apartmentPrice = 77;
            break;
    }

    let totalStudioPrice = studioPrice * nights;
    let totalApartmentPrice = apartmentPrice * nights;

    if ((nights > 7 && nights <= 14) && (month === 'May' || month === 'October')) {
        totalStudioPrice *= 0.95;
    } else if (nights > 14 && (month === 'May' || month === 'October')) {
        totalStudioPrice *= 0.7;
    } else if (nights > 14 && (month === 'June' || month === 'September')) {
        totalStudioPrice *= 0.8;
    }

    if (nights > 14) {
        totalApartmentPrice *= 0.9;
    }

    console.log(`Apartment: ${totalApartmentPrice.toFixed(2)} lv.\nStudio: ${totalStudioPrice.toFixed(2)} lv.`);
}

solve('June', 14); 