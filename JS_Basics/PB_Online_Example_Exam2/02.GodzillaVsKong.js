function solve(movieBudget, people, clothingCost) {
    let decorCost = movieBudget * 0.1;

    if (people > 150) {
        clothingCost *= 0.9;
    }

    let totalCost = decorCost + people * clothingCost;

    if (totalCost > movieBudget) {
        console.log('Not enough money!');
        console.log(`Wingard needs ${(totalCost - movieBudget).toFixed(2)} leva more.`);
    } else {
        console.log('Action!');
        console.log(`Wingard starts filming with ${(movieBudget - totalCost).toFixed(2)} leva left.`)
    }
}

solve(20000, 120, 55.5);