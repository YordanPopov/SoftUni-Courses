function solve(numberOfGuests, pricePerGuest, budget) {
    let cakeCost = budget * 0.10;

    if (numberOfGuests >= 10 && numberOfGuests <= 15) {
        pricePerGuest *= 0.85;
    } else if (numberOfGuests > 15 && numberOfGuests <= 20) {
        pricePerGuest *= 0.80;
    } else if (numberOfGuests > 20) {
        pricePerGuest *= 0.75;
    }

    let totalCost = numberOfGuests * pricePerGuest + cakeCost;

    if (budget >= totalCost) {
        console.log(`It is party time! ${(budget - totalCost).toFixed(2)} leva left.`);
    } else {
        console.log(`No party! ${(totalCost - budget).toFixed(2)} leva needed.`);
    }
}

solve(24, 35, 550);