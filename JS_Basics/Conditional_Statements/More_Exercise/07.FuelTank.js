function solve(typeFuel, liters){
    let isDiesel = typeFuel === 'Diesel';
    let isGasoline = typeFuel === 'Gasoline';
    let isGas = typeFuel === 'Gas';

    if (isDiesel || isGasoline || isGas) {
        if (liters >= 25) {
            console.log(`You have enough ${typeFuel.toLowerCase()}.`);
        } else {
            console.log(`Fill your tank with ${typeFuel.toLowerCase()}!`);
        }
    } else {
        console.log(`Invalid fuel!`);
    }
}

solve('Diesel', 200);