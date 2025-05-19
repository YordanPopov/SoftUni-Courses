function solve(typeFuel, fuelQuantity, hasDiscountCard) {
    let fuelPrice;
    let finalPrice;

    switch (typeFuel) {
        case 'Gasoline':
            if (hasDiscountCard === 'Yes') {
                fuelPrice = 2.22 - 0.18;
            } else if (hasDiscountCard === 'No') {
                fuelPrice = 2.22;
            }
            break;
        case 'Diesel':
            if (hasDiscountCard === 'Yes') {
                fuelPrice = 2.33 - 0.12;
            } else if (hasDiscountCard === 'No') {
                fuelPrice = 2.33;
            }
            break;
        case 'Gas':
            if (hasDiscountCard === 'Yes') {
                fuelPrice = 0.93 - 0.08;
            } else if (hasDiscountCard === 'No') {
                fuelPrice = 0.93;
            }
            break;
    }

    finalPrice = fuelQuantity * fuelPrice;

    if (fuelQuantity >= 20 && fuelQuantity <= 25) {
        finalPrice *= 0.92;
    } else if (fuelQuantity > 25) {
        finalPrice *= 0.9;
    }

    console.log(`${finalPrice.toFixed(2)} lv.`);
}

solve('Diesel', 19, 'No');