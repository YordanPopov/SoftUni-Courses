function solve(pricePerRacket, numberOfRackets, numberOfSneakers) {
    let totalRacketCost = pricePerRacket * numberOfRackets;
    let totalSneakersCost = ((1 / 6) * pricePerRacket) * numberOfSneakers;
    let equipmentCost = 0.2 * (totalRacketCost + totalSneakersCost);
    let totalCost = totalRacketCost + totalSneakersCost + equipmentCost;

    console.log(`Price to be paid by Djokovic ${Math.floor((1 / 8) * totalCost)} `);
    console.log(`Price to be paid by sponsors ${Math.ceil((7 / 8) * totalCost)}`);
}

solve(386, 7, 4);