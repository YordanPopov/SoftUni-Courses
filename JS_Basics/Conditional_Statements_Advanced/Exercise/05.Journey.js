function solve(budget, season) {
    let amountSpent = 0;
    let destination = '';
    let typeOfVacation = '';

    if (budget <= 100) {
        if (season === 'summer') {
            amountSpent = budget * 0.3;
            typeOfVacation = 'Camp';
        } else if (season === 'winter') {
            amountSpent = budget * 0.7;
            typeOfVacation = 'Hotel';
        }

        destination = 'Bulgaria';
    } else if (budget <= 1000) {
        if (season === 'summer') {
            amountSpent = budget * 0.4;
            typeOfVacation = 'Camp';
        } else if (season === 'winter') {
            amountSpent = budget * 0.8;
            typeOfVacation = 'Hotel';
        }

        destination = 'Balkans';
    } else if (budget > 1000) {
        amountSpent = budget * 0.9;
        typeOfVacation = 'Hotel';
        destination = 'Europe';
    }

    console.log(`Somewhere in ${destination}\n${typeOfVacation} - ${amountSpent.toFixed(2)}`);
}

solve(1500, 'summer');