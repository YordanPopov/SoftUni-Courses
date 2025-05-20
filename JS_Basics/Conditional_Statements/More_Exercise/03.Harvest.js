function solve(vineYardArea, grapesPerSquareMeter, needWine, workers) {
    let totalGrapes = vineYardArea * grapesPerSquareMeter;
    let wineProduced = (totalGrapes * 0.4) / 2.5;

    if (wineProduced < needWine) {
        console.log(`It will be a tough winter! More ${Math.floor(needWine - wineProduced)} liters wine needed.`);
    } else {
        let winePerPerson = Math.ceil((wineProduced - needWine) / workers);

        console.log(`Good harvest this year! Total wine: ${Math.floor(wineProduced)} liters.`);
        console.log(`${Math.ceil(wineProduced - needWine)} liters left -> ${winePerPerson} liters per person.`);
    }
}

solve(1020, 1.5, 425, 4);