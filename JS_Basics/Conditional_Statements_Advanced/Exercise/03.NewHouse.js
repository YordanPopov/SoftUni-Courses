function solve(flowers, quantity, budget) {
    const flowerPrices = {
        "Roses": 5.00,
        "Dahlias": 3.80,
        "Tulips": 2.80,
        "Narcissus": 3.00,
        "Gladiolus": 2.50
    };

    let totalCost = quantity * flowerPrices[flowers];

    if (flowers === 'Roses' && quantity > 80) {
        totalCost *= 0.90;
    } else if (flowers === 'Dahlias' && quantity > 90) {
        totalCost *= 0.85;
    } else if (flowers === 'Tulips' && quantity > 80) {
        totalCost *= 0.85;
    } else if (flowers === 'Narcissus' && quantity < 120) {
        totalCost *= 1.15;
    } else if (flowers === 'Gladiolus' && quantity < 80) {
        totalCost *= 1.20;
    } 

    if (budget >= totalCost) {
        console.log(`Hey, you have a great garden with ${quantity} ${flowers} and ${(budget - totalCost).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money, you need ${(totalCost - budget).toFixed(2)} leva more.`);   
    }
}

solve('Roses', 55, 250);